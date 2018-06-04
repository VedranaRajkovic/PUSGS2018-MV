namespace RentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class implematedinitialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Manufactor = c.String(),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                        PricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unavailable = c.Boolean(nullable: false),
                        Type_Id = c.Int(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfVehicles", t => t.Type_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.TypeOfVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AppUsers", "Email", c => c.String());
            AddColumn("dbo.AppUsers", "Birthday", c => c.DateTime());
            AddColumn("dbo.AppUsers", "Activated", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppUsers", "PersonalDocument", c => c.String());
            AddColumn("dbo.Services", "Logo", c => c.String());
            AddColumn("dbo.Services", "Email", c => c.String());
            AddColumn("dbo.Services", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Vehicles", "Type_Id", "dbo.TypeOfVehicles");
            DropForeignKey("dbo.Branches", "Service_Id", "dbo.Services");
            DropIndex("dbo.Vehicles", new[] { "Service_Id" });
            DropIndex("dbo.Vehicles", new[] { "Type_Id" });
            DropIndex("dbo.Branches", new[] { "Service_Id" });
            DropColumn("dbo.Services", "Description");
            DropColumn("dbo.Services", "Email");
            DropColumn("dbo.Services", "Logo");
            DropColumn("dbo.AppUsers", "PersonalDocument");
            DropColumn("dbo.AppUsers", "Activated");
            DropColumn("dbo.AppUsers", "Birthday");
            DropColumn("dbo.AppUsers", "Email");
            DropTable("dbo.TypeOfVehicles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Branches");
        }
    }
}
