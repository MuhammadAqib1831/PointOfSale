namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.orderMasters",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        CreatiomTime = c.DateTime(nullable: false),
                        TotalSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status = c.Int(nullable: false),
                        Synchronized = c.Boolean(nullable: false),
                        OrderDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_Id)
                .Index(t => t.OrderDetail_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Updated = c.DateTime(nullable: false),
                        OrderDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_Id)
                .Index(t => t.OrderDetail_Id);
            
            CreateTable(
                "dbo.SyncLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OrderDetail_Id", "dbo.OrderDetails");
            DropForeignKey("dbo.orderMasters", "OrderDetail_Id", "dbo.OrderDetails");
            DropIndex("dbo.Products", new[] { "OrderDetail_Id" });
            DropIndex("dbo.orderMasters", new[] { "OrderDetail_Id" });
            DropTable("dbo.SyncLogs");
            DropTable("dbo.Products");
            DropTable("dbo.orderMasters");
            DropTable("dbo.OrderDetails");
        }
    }
}
