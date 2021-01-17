namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmorUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Armors", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Armors", "Type");
        }
    }
}
