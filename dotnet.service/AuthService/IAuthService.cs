using System;
using dotnet.data.Models;

namespace dotnet.service.AuthService
{
    public interface IAuthService
    {
        public ServiceResponse<UserRegister> Register(UserRegister user);
        public ServiceResponse<UserRegister> Login(UserLogin credential);
    }
}
