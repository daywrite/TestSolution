using L.Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data
{
    /// <summary>
    ///     EF数据访问上下文
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("default") { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserExtend> UserExtends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserCreate());
            modelBuilder.Configurations.Add(new UserExtendCreate());
        }
    }
}
