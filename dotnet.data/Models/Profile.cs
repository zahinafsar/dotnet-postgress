using System;

namespace dotnet.data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public DateTime created { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string country { get; set; }
    }
}
