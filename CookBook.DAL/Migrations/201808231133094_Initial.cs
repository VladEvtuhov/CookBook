namespace CookBook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        CookingMethodId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        IngredientTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.CookingMethods", t => t.CookingMethodId, cascadeDelete: true)
                .ForeignKey("dbo.СuisineСountry", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.IngredientTypes", t => t.IngredientTypeId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatorId)
                .Index(t => t.CookingMethodId)
                .Index(t => t.CountryId)
                .Index(t => t.IngredientTypeId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ImageUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        Information = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RecipeRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CookingMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.СuisineСountry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngredientTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecipeProducts", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Recipes", "IngredientTypeId", "dbo.IngredientTypes");
            DropForeignKey("dbo.Recipes", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "CountryId", "dbo.СuisineСountry");
            DropForeignKey("dbo.Recipes", "CookingMethodId", "dbo.CookingMethods");
            DropForeignKey("dbo.Comments", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecipeRatings", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeRatings", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecipeProducts", new[] { "ProductId" });
            DropIndex("dbo.RecipeProducts", new[] { "RecipeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RecipeRatings", new[] { "RecipeId" });
            DropIndex("dbo.RecipeRatings", new[] { "CreatorId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "RecipeId" });
            DropIndex("dbo.Comments", new[] { "CreatorId" });
            DropIndex("dbo.Recipes", new[] { "IngredientTypeId" });
            DropIndex("dbo.Recipes", new[] { "CountryId" });
            DropIndex("dbo.Recipes", new[] { "CookingMethodId" });
            DropIndex("dbo.Recipes", new[] { "CreatorId" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.RecipeProducts");
            DropTable("dbo.IngredientTypes");
            DropTable("dbo.СuisineСountry");
            DropTable("dbo.CookingMethods");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RecipeRatings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
        }
    }
}
