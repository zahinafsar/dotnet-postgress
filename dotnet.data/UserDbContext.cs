using System;
using dotnet.data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet.data
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions option) : base(option) { }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
    }
}
