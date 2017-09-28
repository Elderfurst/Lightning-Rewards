namespace Lightning_Rewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCardForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cards", new[] { "User_Id" });
            DropIndex("dbo.Cards", new[] { "User_Id1" });
            DropIndex("dbo.Cards", new[] { "User_Id2" });
            DropColumn("dbo.Cards", "CreatedByUserId");
            DropColumn("dbo.Cards", "ManagerUserId");
            DropColumn("dbo.Cards", "RecipientUserId");
            RenameColumn(table: "dbo.Cards", name: "User_Id", newName: "CreatedByUserId");
            RenameColumn(table: "dbo.Cards", name: "User_Id1", newName: "ManagerUserId");
            RenameColumn(table: "dbo.Cards", name: "User_Id2", newName: "RecipientUserId");
            AlterColumn("dbo.Cards", "CreatedByUserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Cards", "ManagerUserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Cards", "RecipientUserId", c => c.Long(nullable: false));
            CreateIndex("dbo.Cards", "CreatedByUserId");
            CreateIndex("dbo.Cards", "RecipientUserId");
            CreateIndex("dbo.Cards", "ManagerUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cards", new[] { "ManagerUserId" });
            DropIndex("dbo.Cards", new[] { "RecipientUserId" });
            DropIndex("dbo.Cards", new[] { "CreatedByUserId" });
            AlterColumn("dbo.Cards", "RecipientUserId", c => c.Long());
            AlterColumn("dbo.Cards", "ManagerUserId", c => c.Long());
            AlterColumn("dbo.Cards", "CreatedByUserId", c => c.Long());
            RenameColumn(table: "dbo.Cards", name: "RecipientUserId", newName: "User_Id2");
            RenameColumn(table: "dbo.Cards", name: "ManagerUserId", newName: "User_Id1");
            RenameColumn(table: "dbo.Cards", name: "CreatedByUserId", newName: "User_Id");
            AddColumn("dbo.Cards", "RecipientUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Cards", "ManagerUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Cards", "CreatedByUserId", c => c.Long(nullable: false));
            CreateIndex("dbo.Cards", "User_Id2");
            CreateIndex("dbo.Cards", "User_Id1");
            CreateIndex("dbo.Cards", "User_Id");
        }
    }
}
