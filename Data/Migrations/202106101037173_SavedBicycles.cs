namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedBicycles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bicycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearOfManufacture = c.DateTime(nullable: false),
                        Sex = c.String(),
                        SerialNumber = c.Int(nullable: false),
                        Type = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BicycleId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        DeliveryService = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                        Address = c.String(),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bicycles", t => t.BicycleId, cascadeDelete: true)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BicycleId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Sex = c.String(),
                        Email = c.String(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Orders", "BicycleId", "dbo.Bicycles");
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Orders", new[] { "BicycleId" });
            DropTable("dbo.Buyers");
            DropTable("dbo.Orders");
            DropTable("dbo.Bicycles");
        }
    }
}
