using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.data;
using dotnet.data.Models;

namespace dotnet.service.UserService
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _db;

        public UserService(UserDbContext db)
        {
            _db = db;
        }


        public List<User> GetAllUsers()
        {
            return _db.User.ToList();
        }

        public User GetUser(int id)
        {
            return _db.User.Find(id);

        }

        public ServiceResponse<User> CreateUser(User user)
        {
            try
            {
                _db.User.Add(user);
                _db.SaveChanges();

                return new ServiceResponse<User>
                {
                    IsSuccess = true,
                    Message = "User Created Seccessfuly",
                    Data = user,
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<User>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = { },
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<User> DeleteUser(int Id)
        {
            var user = _db.User.Find(Id);
            if (user == null)
            {
                return new ServiceResponse<User>
                {
                    Data = { },
                    IsSuccess = false,
                    Message = "User Not Found",
                    Time = DateTime.UtcNow
                };
            }
            try
            {
                _db.User.Remove(user);
                _db.SaveChanges();

                return new ServiceResponse<User>
                {
                    Data = { },
                    IsSuccess = true,
                    Message = "User has been Deleted Succesfully",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<User>
                {
                    Data = { },
                    IsSuccess = false,
                    Message = e.StackTrace.ToString(),
                    Time = DateTime.UtcNow
                };
            }
        }
    }

}
