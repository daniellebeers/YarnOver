namespace YarnOver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ProjectName = c.String(nullable: false),
                        PatternLocation = c.String(nullable: false),
                        ProjectYarn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Project");
        }
    }
}
