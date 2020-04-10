using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FurnitureStore.Models;
using System.Collections;

namespace FurnitureStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private object options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(object options)
        {
            this.options = options;
        }

        public DbSet<FurnitureStore.Models.Items> Items { get; set; }
        public DbSet<FurnitureStore.Models.Manufacture> Manufacture { get; set; }
        public IEnumerable Products { get; internal set; }
    }
}
