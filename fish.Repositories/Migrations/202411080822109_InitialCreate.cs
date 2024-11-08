namespace fish.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        DiaChi = c.String(),
                        Email = c.String(),
                        NgayHen = c.DateTime(nullable: false),
                        GioHen = c.Time(nullable: false, precision: 7),
                        MoTa = c.String(),
                        GiaTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        ServiceId = c.Int(),
                        DoctorId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.DoctorId)
                .ForeignKey("dbo.ServiceModels", t => t.ServiceId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ServiceId)
                .Index(t => t.DoctorId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(),
                        MoTaDichVu = c.String(),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "ServiceId", "dbo.ServiceModels");
            DropForeignKey("dbo.Bookings", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "User_Id", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "User_Id" });
            DropIndex("dbo.Bookings", new[] { "DoctorId" });
            DropIndex("dbo.Bookings", new[] { "ServiceId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropTable("dbo.ServiceModels");
            DropTable("dbo.Users");
            DropTable("dbo.Bookings");
        }
    }
}
