namespace ReactMusicStore.Core.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 160),
                        Price = c.Decimal(nullable: false, precision: 5, scale: 2),
                        AlbumArtUrl = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .Index(t => t.GenreId)
                .Index(t => t.ArtistId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FierstName = c.String(),
                        LastName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccountClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.UserAccountLogin",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.UserAccounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAccountsUserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserAccount_Id = c.Int(),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.AlbumId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Id = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        ModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.CreatedById)
                .ForeignKey("dbo.UserAccounts", t => t.ModifiedById)
                .Index(t => t.AlbumId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleDescription = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccountsUserRoles", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Cart", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Cart", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Cart", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Order", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.OrderDetail", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.OrderDetail", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.OrderDetail", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Album", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Genre", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Genre", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Album", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Artist", "ModifiedById", "dbo.UserAccounts");
            DropForeignKey("dbo.Artist", "CreatedById", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccountsUserRoles", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccountLogin", "UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccountClaim", "UserAccount_Id", "dbo.UserAccounts");
            DropIndex("dbo.Cart", new[] { "ModifiedById" });
            DropIndex("dbo.Cart", new[] { "CreatedById" });
            DropIndex("dbo.Cart", new[] { "AlbumId" });
            DropIndex("dbo.Order", new[] { "ModifiedById" });
            DropIndex("dbo.Order", new[] { "CreatedById" });
            DropIndex("dbo.OrderDetail", new[] { "ModifiedById" });
            DropIndex("dbo.OrderDetail", new[] { "CreatedById" });
            DropIndex("dbo.OrderDetail", new[] { "AlbumId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Genre", new[] { "ModifiedById" });
            DropIndex("dbo.Genre", new[] { "CreatedById" });
            DropIndex("dbo.UserAccountsUserRoles", new[] { "UserRole_Id" });
            DropIndex("dbo.UserAccountsUserRoles", new[] { "UserAccount_Id" });
            DropIndex("dbo.UserAccountLogin", new[] { "UserId" });
            DropIndex("dbo.UserAccountClaim", new[] { "UserAccount_Id" });
            DropIndex("dbo.Artist", new[] { "ModifiedById" });
            DropIndex("dbo.Artist", new[] { "CreatedById" });
            DropIndex("dbo.Album", new[] { "ModifiedById" });
            DropIndex("dbo.Album", new[] { "CreatedById" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropIndex("dbo.Album", new[] { "GenreId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Cart");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Genre");
            DropTable("dbo.UserAccountsUserRoles");
            DropTable("dbo.UserAccountLogin");
            DropTable("dbo.UserAccountClaim");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
