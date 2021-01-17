namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Character : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weapons", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weapons", "Type");
        }
    }
}
