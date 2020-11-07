using catalina.Core.Extensions;
using catalina.Core.Interfaces;
using catalina.Repositories;
using catalina.Repositories.Entities;
using catalina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace catalina.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User PostUser(UserPostVM user)
        {
            if(!string.IsNullOrEmpty(user.UserId))
            {
                //update
                var existingUser = _userRepository.GetById(new Guid(user.UserId));
                if(existingUser != null)
                {
                    existingUser.Email = user.Email.ToLower();
                    existingUser.FullName = user.FullName;
                    existingUser.Phone = user.Phone;
                    existingUser.FirebaseToken = user.FirebaseToken;
                    existingUser.ShippingAddress = user.ShippingAddress;
                    existingUser.ShippingCountry = user.ShippingCountry;
                    existingUser.UpdatedOnUTC = DateTime.UtcNow;
                    if (!string.IsNullOrEmpty(user.Password))
                        existingUser.PasswordEncrypt = user.Password.MD5Hash();

                    _userRepository.Update(existingUser);
                    return existingUser;
                }
                else
                {
                    throw new Exception("User does not exist");
                }
            }
            else
            {
                //create user if email not registered
                var existingUser = _userRepository.Query().Where(x => x.Email.Equals(user.Email.ToLower())).FirstOrDefault();
                if(existingUser == null && user.Phone != null)
                {
                    var newUser = new User()
                    {
                        UserId = Guid.NewGuid(),
                        Email = user.Email.ToLower(),
                        CreatedOnUTC = DateTime.UtcNow,
                        FullName = user.FullName,
                        PasswordEncrypt = user.Password.MD5Hash(),
                        Phone = user.Phone,
                        FirebaseToken = user.FirebaseToken,
                        ShippingAddress = user.ShippingAddress,
                        ShippingCountry = user.ShippingCountry
                    };
                    _userRepository.Add(newUser);
                    return newUser;
                }
                else
                {
                    //login user if password and email match
                    var _user = _userRepository.Query().Where(x => x.Email.Equals(user.Email.ToLower()) && x.PasswordEncrypt.Equals(user.Password.MD5Hash())).FirstOrDefault();
                    if(_user != null)
                    {
                        return _user;
                    }
                    throw new Exception($"Reset password to recover profile");
                }
            }
        }
    }
}
