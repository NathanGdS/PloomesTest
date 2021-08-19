using SalesAPI.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Services
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(AuthDTO user);
        TokenDTO ValidateCredentials(TokenDTO token);
        bool RevokeToken(string username);
    }
}
