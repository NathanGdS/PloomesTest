using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface IUserService
    {
        UserDTO Create(UserDTO user);
        List<UserDTO> FindAll();
        UserDTO FindByID(long id);
        void Delete(long id);
        /*
        
        User Update(User user);
        */
    }
}
