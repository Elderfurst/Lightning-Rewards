using Lightning_Rewards.Models;

namespace Lightning_Rewards.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lightning_Rewards.Models.Lightning_RewardsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lightning_Rewards.Models.Lightning_RewardsContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Users.AddOrUpdate(
                u => u.Email,
                new User() { Password = "training", FirstName = "Nick", LastName = "Anderson", Email = "nanderson@reliaslearning.com", IsManager = false, IsAdmin = false, DateCreated = DateTime.Now, DateModified = null },
                new User() { Password = "training", FirstName = "William", LastName = "Coleman", Email = "wcoleman@reliaslearning.com", IsManager = false, IsAdmin = false, DateCreated = DateTime.Now, DateModified = null },
                new User() { Password = "training", FirstName = "Lindsey", LastName = "Adams", Email = "ladams@reliaslearning.com", IsManager = false, IsAdmin = false, DateCreated = DateTime.Now, DateModified = null },
                new User() { Password = "training", FirstName = "Dave", LastName = "Long", Email = "dlong@reliaslearning.com", IsManager = true, IsAdmin = false, DateCreated = DateTime.Now, DateModified = null },
                new User() { Password = "training", FirstName = "Shaun", LastName = "Blair", Email = "sblair@reliaslearning.com", IsManager = true, IsAdmin = false, DateCreated = DateTime.Now, DateModified = null }
                );
            context.Cards.AddOrUpdate(
                c => c.Message,
                new Card() { LetterValue = "R", Message = "To Nick R", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now},
                new Card() { LetterValue = "E", Message = "To Nick E", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "L", Message = "To Nick L", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "I", Message = "To Nick I", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "A", Message = "To Nick A", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "S", Message = "To Nick S", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "ACC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "E", Message = "To Nick Again", CreatedByUserId = 3, RecipientUserId = 1, ManagerUserId = 5, CardStatus = "PAC", DateCreated = DateTime.Now },
                new Card() { LetterValue = "L", Message = "To William", CreatedByUserId = 1, RecipientUserId = 3, ManagerUserId = 5, CardStatus = "PAP", DateCreated = DateTime.Now }
                );
        }
    }
}
