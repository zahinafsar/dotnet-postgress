using System;
using System.Linq;
using dotnet.data;
using dotnet.data.Models;

namespace dotnet.service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserDbContext _db;
        public AuthService(UserDbContext db)
        {
            _db = db;
        }
        public ServiceResponse<UserRegister> Login(UserLogin credential)
        {
            try
            {
                var user = _db.UserRegister.FirstOrDefault(cred => cred.email == credential.email);
                return new ServiceResponse<UserRegister>
                {
                    Data = user,
                    IsSuccess = true,
                    Message = "Login Successful",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<UserRegister>
                {
                    Data = { },
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<UserRegister> Register(UserRegister user)
        {
            try
            {
                _db.UserRegister.Add(
                    new UserRegister
                    {
                        fullName = user.fullName,
                        email = user.email,
                        age = user.age,
                        country = user.country,
                        password = BCrypt.Net.BCrypt.HashPassword(user.password)
                    }
                );
                _db.SaveChanges();
                return new ServiceResponse<UserRegister>
                {
                    Data = user,
                    IsSuccess = true,
                    Message = "Registration Successful",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<UserRegister>
                {
                    Data = user,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
