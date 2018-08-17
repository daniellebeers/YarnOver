namespace YarnOver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hook",
                c => new
                    {
                        HookId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        NumberSize = c.Int(nullable: false),
                        LetterSize = c.String(),
                        Material = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hook");
        }
    }
}
