namespace Repository.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        //To store user data in Database
        public DbSet<RegisterModel> Users { get; set; }
    }
}
