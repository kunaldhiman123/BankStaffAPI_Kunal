using System;
using System.Collections.Generic;
using System.Text;
using BankStaffAPI_Kunal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankStaffAPI_Kunal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}
