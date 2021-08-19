using SalesAPI.Data.Converter.Implementations;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Repository;
using SalesAPI.Repository.Generic;
using System.Collections.Generic;

namespace SalesAPI.Services.Implementations
{
    public class UserServicesImplementation : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _converter;

        public UserServicesImplementation(IUserRepository repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }
        public UserDTO Create(UserDTO user)
        {
            var categoryEntity = _converter.Parse(user);
            categoryEntity = _repository.Create(categoryEntity);
            return _converter.Parse(categoryEntity);
        }

        
        public List<UserDTO> FindAll()
        {
            var result = _converter.Parse(_repository.FindAll());
            return result;
        }

        public UserDTO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        /*


        public User Update(User user)
        {
            return _repository.Update(user);

        }


        */
    }
}
