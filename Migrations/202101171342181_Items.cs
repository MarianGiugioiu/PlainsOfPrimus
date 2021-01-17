namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Items : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        ArmorValue = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Intellect = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Agility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        AttackDamage = c.Int(nullable: false),
                        SpecialBonus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weapons");
            DropTable("dbo.Armors");
        }
    }
}
