namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Achievements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Requirements = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Class = c.String(),
                        Level = c.Int(nullable: false),
                        Boots_Id = c.Int(),
                        Chestplate_Id = c.Int(),
                        Helmet_Id = c.Int(),
                        Leggings_Id = c.Int(),
                        Weapon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armors", t => t.Boots_Id)
                .ForeignKey("dbo.Armors", t => t.Chestplate_Id)
                .ForeignKey("dbo.Armors", t => t.Helmet_Id)
                .ForeignKey("dbo.Armors", t => t.Leggings_Id)
                .ForeignKey("dbo.Weapons", t => t.Weapon_Id)
                .Index(t => t.Boots_Id)
                .Index(t => t.Chestplate_Id)
                .Index(t => t.Helmet_Id)
                .Index(t => t.Leggings_Id)
                .Index(t => t.Weapon_Id);
            
            CreateTable(
                "dbo.CharacterAchievements",
                c => new
                    {
                        Character_Id = c.Int(nullable: false),
                        Achievement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Character_Id, t.Achievement_Id })
                .ForeignKey("dbo.Characters", t => t.Character_Id, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.Achievement_Id, cascadeDelete: true)
                .Index(t => t.Character_Id)
                .Index(t => t.Achievement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Weapon_Id", "dbo.Weapons");
            DropForeignKey("dbo.Characters", "Leggings_Id", "dbo.Armors");
            DropForeignKey("dbo.Characters", "Helmet_Id", "dbo.Armors");
            DropForeignKey("dbo.Characters", "Chestplate_Id", "dbo.Armors");
            DropForeignKey("dbo.Characters", "Boots_Id", "dbo.Armors");
            DropForeignKey("dbo.CharacterAchievements", "Achievement_Id", "dbo.Achievements");
            DropForeignKey("dbo.CharacterAchievements", "Character_Id", "dbo.Characters");
            DropIndex("dbo.CharacterAchievements", new[] { "Achievement_Id" });
            DropIndex("dbo.CharacterAchievements", new[] { "Character_Id" });
            DropIndex("dbo.Characters", new[] { "Weapon_Id" });
            DropIndex("dbo.Characters", new[] { "Leggings_Id" });
            DropIndex("dbo.Characters", new[] { "Helmet_Id" });
            DropIndex("dbo.Characters", new[] { "Chestplate_Id" });
            DropIndex("dbo.Characters", new[] { "Boots_Id" });
            DropTable("dbo.CharacterAchievements");
            DropTable("dbo.Characters");
            DropTable("dbo.Achievements");
        }
    }
}
