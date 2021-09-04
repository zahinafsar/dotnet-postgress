using System;

namespace dotnet.data.Models
{
    public class UserRegister
    {
        public int Id { get; set; }
        public DateTime created { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string country { get; set; }
        public string password { get; set; }
    }
}
