namespace EF_Audit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAudits",
                c => new
                    {
                        BankAuditId = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Account = c.String(),
                        ClientId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        Audited = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankAuditId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ClientAudits",
                c => new
                    {
                        ClientAuditId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        Audited = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientAuditId);
            
            CreateTable(
                "dbo.OrderAudits",
                c => new
                    {
                        OrderAuditId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        Audited = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderAuditId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ProductAudits",
                c => new
                    {
                        ProductAuditId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        Audited = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductAuditId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.StorageAudits",
                c => new
                    {
                        StorageAuditId = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        Name = c.String(),
                        OrderId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        Audited = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageAuditId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Banks", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Banks", "UpdateUser", c => c.String());
            AddColumn("dbo.Clients", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "UpdateUser", c => c.String());
            AddColumn("dbo.Orders", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "UpdateUser", c => c.String());
            AddColumn("dbo.Products", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdateUser", c => c.String());
            AddColumn("dbo.Storages", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Storages", "UpdateUser", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorageAudits", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ProductAudits", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderAudits", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.BankAudits", "ClientId", "dbo.Clients");
            DropIndex("dbo.StorageAudits", new[] { "OrderId" });
            DropIndex("dbo.ProductAudits", new[] { "OrderId" });
            DropIndex("dbo.OrderAudits", new[] { "ClientId" });
            DropIndex("dbo.BankAudits", new[] { "ClientId" });
            DropColumn("dbo.Storages", "UpdateUser");
            DropColumn("dbo.Storages", "Updated");
            DropColumn("dbo.Products", "UpdateUser");
            DropColumn("dbo.Products", "Updated");
            DropColumn("dbo.Orders", "UpdateUser");
            DropColumn("dbo.Orders", "Updated");
            DropColumn("dbo.Clients", "UpdateUser");
            DropColumn("dbo.Clients", "Updated");
            DropColumn("dbo.Banks", "UpdateUser");
            DropColumn("dbo.Banks", "Updated");
            DropTable("dbo.StorageAudits");
            DropTable("dbo.ProductAudits");
            DropTable("dbo.OrderAudits");
            DropTable("dbo.ClientAudits");
            DropTable("dbo.BankAudits");
        }
    }
}
