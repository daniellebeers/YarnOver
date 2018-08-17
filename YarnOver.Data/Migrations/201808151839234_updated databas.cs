namespace YarnOver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yarn", "TotalYardage", c => c.Int(nullable: false));
            AlterColumn("dbo.Yarn", "WherePurchased", c => c.String());
            DropColumn("dbo.Yarn", "TotalYards");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yarn", "TotalYards", c => c.Int(nullable: false));
            AlterColumn("dbo.Yarn", "WherePurchased", c => c.String(nullable: false));
            DropColumn("dbo.Yarn", "TotalYardage");
        }
    }
}
