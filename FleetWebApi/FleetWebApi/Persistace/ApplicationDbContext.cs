﻿using FleetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetWebApi.Persistace
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
