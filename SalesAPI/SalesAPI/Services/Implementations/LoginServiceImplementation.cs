using SalesAPI.Configurations;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;

namespace SalesAPI.Services.Implementations
{
    public class LoginServiceImplementation : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly TokenConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginServiceImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenDTO ValidateCredentials(AuthDTO userCredential)
        {
            // valida no banco de dados as credenciais
            User user = _repository.ValidateCredentials(userCredential);

            if (user == null) return null;

            // gerar as claims
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            // generate access and refresh Token
            string accessToken = _tokenService.GenerateAcessToken(claims);
            string refreshToken = _tokenService.GenerateRefreshToken();


            DateTime createDate = DateTime.Now;
            // set in User recovery from dB
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = createDate.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user); //update user's data

            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes); // when the token expires

            // set token informations
            return new TokenDTO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }

        public TokenDTO ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;


            var user = _repository.ValidateCredentials(username);
            
            if (
                user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now
                )
            {
                return null;
            }

            accessToken = _tokenService.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user); //update user's data

            DateTime createDate = DateTime.Now; // when the token was created
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes); // when the token expires

            // set token informations
            return new TokenDTO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }
        public bool RevokeToken(string username)
        {
            return _repository.RevokeToken(username);
        }
    }
}
