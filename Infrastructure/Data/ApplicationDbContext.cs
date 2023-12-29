using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //configure the model that is used by Entity Framework to construct the database schema
            //have the option to override this method to provide additional configuration for your model.
            // you can add your own custom model configuration. This is where you can use the builder parameter to configure things like entity relationships, indexes, constraints, and other aspects of the database schema.
            //builder.Entity<YourEntity>().Property(e => e.YourProperty).IsRequired();
            base.OnModelCreating(builder);
        }

    }
}
