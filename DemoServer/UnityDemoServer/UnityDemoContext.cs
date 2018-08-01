using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDemoServer.DbEntity;

namespace UnityDemoServer
{
    class UnityDemoContext : DbContext
    {
		public DbSet<UserInfo> UserInfo { get; set; }
		public UnityDemoContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:DefaultSchema", "dbo");
			modelBuilder.Entity<UserInfo>();
		}
	}
}
