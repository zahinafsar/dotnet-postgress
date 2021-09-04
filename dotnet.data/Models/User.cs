using System;

namespace dotnet.data.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime created { get; set; }
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public Profile Profile { get; set; }
    }
}
