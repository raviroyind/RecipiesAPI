namespace MealService.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YourMigrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipieName = c.String(nullable: false),
                        Description = c.String(),
                        PreparationTime = c.Int(nullable: false),
                        Serves = c.Int(nullable: false),
                        OriginCountry = c.String(),
                        ChefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chefs", t => t.ChefId, cascadeDelete: true)
                .Index(t => t.ChefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipies", "ChefId", "dbo.Chefs");
            DropIndex("dbo.Recipies", new[] { "ChefId" });
            DropTable("dbo.Recipies");
            DropTable("dbo.Chefs");
        }
    }
}
