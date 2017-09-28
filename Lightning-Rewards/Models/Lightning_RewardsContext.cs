using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    public class Lightning_RewardsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Lightning_RewardsContext() : base("name=Lightning_RewardsContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasRequired(x => x.CreatedByUser)
                .WithMany(u => u.CreatedCards)
                .HasForeignKey(x => x.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Card>()
                .HasRequired(x => x.ReceivedByUser)
                .WithMany(u => u.ReceivedCards)
                .HasForeignKey(x => x.RecipientUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Card>()
                .HasRequired(x => x.ManagedByUser)
                .WithMany(u => u.ManagedCards)
                .HasForeignKey(x => x.ManagerUserId)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<Lightning_Rewards.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Lightning_Rewards.Models.Card> Cards { get; set; }
    }
}
