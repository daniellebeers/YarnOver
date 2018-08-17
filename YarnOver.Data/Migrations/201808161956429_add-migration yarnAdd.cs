namespace YarnOver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationyarnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yarn", "Fiber", c => c.String(nullable: false));
            AddColumn("dbo.Yarn", "YarnType", c => c.String());
            AlterColumn("dbo.Yarn", "WherePurchased", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Yarn", "WherePurchased", c => c.String());
            DropColumn("dbo.Yarn", "YarnType");
            DropColumn("dbo.Yarn", "Fiber");
        }
    }
}
