namespace fish.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublicMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicMessages", "UserId", "dbo.Users");
            DropIndex("dbo.PublicMessages", new[] { "UserId" });
            DropTable("dbo.PublicMessages");
        }
    }
}
