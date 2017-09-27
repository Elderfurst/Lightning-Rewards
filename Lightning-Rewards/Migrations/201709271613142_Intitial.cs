namespace Lightning_Rewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LetterValue = c.String(),
                        CreatedByUserId = c.Long(nullable: false),
                        RecipientUserId = c.Long(nullable: false),
                        ManagerUserId = c.Long(nullable: false),
                        CardStatus = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        User_Id = c.Long(),
                        User_Id1 = c.Long(),
                        User_Id2 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id2)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1)
                .Index(t => t.User_Id2);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        IsManager = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Cards", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Cards", "User_Id", "dbo.Users");
            DropIndex("dbo.Cards", new[] { "User_Id2" });
            DropIndex("dbo.Cards", new[] { "User_Id1" });
            DropIndex("dbo.Cards", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Cards");
        }
    }
}
