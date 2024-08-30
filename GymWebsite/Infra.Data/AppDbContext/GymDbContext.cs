using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.AppDbContext
{
    public class GymDbContext : DbContext
    {

        #region Ctor
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }
        #endregion

        #region Db Sets
        
        public DbSet<User> Users { get; set; }


        #endregion


        #region Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
