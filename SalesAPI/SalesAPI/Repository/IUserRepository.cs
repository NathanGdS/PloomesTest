using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;

namespace SalesAPI.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(AuthDTO user);
        User ValidateCredentials(string username);
        bool RevokeToken(string username);
        User RefreshUserInfo(User user);
        User Create(User user);
        List<User> FindAll();
        User FindByID(long id);
        void Delete(long id);
    }
}
