namespace Lightning_Rewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalModifiedDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cards", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
