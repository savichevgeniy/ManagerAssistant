using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ManagerAssistant.Models;

namespace ManagerAssistant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<TableForEmployee> TableForEmployee { get; set; }
        public DbSet<TableForDesigners> TableForDesigners { get; set; }
        public DbSet<TableForDeveloper> TableForDevelopers { get; set; }
        public DbSet<TableForTester> TableForTesters { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<OtherEmloyee> OtherEmloyees { get; set; }
        public DbSet<AllProject> AllProjects { get; set; }
        public DbSet<ManagerAssistant.Models.FeedBack> FeedBack { get; set; }
    }
}
