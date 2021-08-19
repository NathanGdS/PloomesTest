using SalesAPI.Data.Converter.Contract;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Data.Converter.Implementations
{
    public class UserConverter : IParser<UserDTO, User>, IParser<User, UserDTO>
    {
        public User Parse(UserDTO origin)
        {
            if (origin == null) return null;
            return new User
            {
                Id = origin.Id,
                CompleteName = origin.CompleteName,
                UserName = origin.UserName,
                Password = origin.Password,
            };
        }

        public UserDTO Parse(User origin)
        {
            if (origin == null) return null;
            return new UserDTO
            {
                Id = origin.Id,
                CompleteName = origin.CompleteName,
                UserName = origin.UserName,
                Password = origin.Password,
            };
        }

        public List<User> Parse(List<UserDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserDTO> Parse(List<User> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
