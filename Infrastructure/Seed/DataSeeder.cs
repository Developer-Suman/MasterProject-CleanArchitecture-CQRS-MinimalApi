using Application.Static.Roles;
using Domain.Abstraction;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public DataSeeder(RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _context = applicationDbContext;
            
        }

        public async Task Seed()
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await SeedRole();
                    await SeedDepartment();

                    await transaction.CommitAsync();

                }catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        #region Roles
        private async Task SeedRole()
        {
            if(!await _roleManager.Roles.AnyAsync())
            {
                var roles = new List<IdentityRole>()
                {
                    new IdentityRole(){Name= Role.Superadmin},
                    new IdentityRole{Name= Role.Admin},
                    new IdentityRole{Name = Role.User},

                };

                foreach(var role in roles)
                {
                    await _roleManager.CreateAsync(role);
                }

            }
        }


        #endregion

        #region Department
        private async Task SeedDepartment()
        {
            if(!await _context.Departments.AnyAsync())
            {
                var departments = new List<Department>()
                {
                    new Department(1, "स्वास्थ शाखा","Health Department" ),
                    new Department(2, "शिक्षा शाखा","Education Department")
                };

                await _context.Departments.AddRangeAsync(departments);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
