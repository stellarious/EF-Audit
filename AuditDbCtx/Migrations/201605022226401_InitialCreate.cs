namespace EF_Audit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Account = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Sum = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storages", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Banks", "ClientId", "dbo.Clients");
            DropIndex("dbo.Storages", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.Banks", new[] { "ClientId" });
            DropTable("dbo.Storages");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
            DropTable("dbo.Banks");
        }
    }
}
