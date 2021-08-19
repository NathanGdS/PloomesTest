using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SalesAPI.Repository.implementations
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly MSSQLContext _context;

        public UserRepositoryImplementation(MSSQLContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public User FindByID(long id)
        {
            return _context.Users.SingleOrDefault(u => u.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User ValidateCredentials(AuthDTO user)
        {
            string pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(
                u => (u.UserName == user.UserName) &&
                     (u.Password == pass)
                );
        }

        public User ValidateCredentials(string username)
        {
            return _context.Users.SingleOrDefault(
                u => (u.UserName == username)
                );
        }

        public bool RevokeToken(string username)
        {
            User user = _context.Users.SingleOrDefault(
                u => (u.UserName == username)
                );

            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public User RefreshUserInfo(User user)
        {

            if (!_context.Users.Any(p => p.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private static string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
