namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entities : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Weapons", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapons", "Type", c => c.String());
        }
    }
}
