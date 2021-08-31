using System;
using System.Collections.Generic;
using dotnet.data.Models;

namespace dotnet.service.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int Id);
        ServiceResponse<User> CreateUser(User user);
        ServiceResponse<User> DeleteUser(int Id);
    }
}
