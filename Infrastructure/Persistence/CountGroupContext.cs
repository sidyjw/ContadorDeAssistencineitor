using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CountGroupContext : DbContext
    {
        public DbSet<CountGroup> CountGroups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        
        public CountGroupContext(DbContextOptions<CountGroupContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountGroup>()
                .HasKey(e => e.Guid);
        }
    }

   
}
