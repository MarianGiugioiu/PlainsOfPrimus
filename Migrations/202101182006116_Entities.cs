namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Achievements", "Requirements", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Achievements", "Requirements", c => c.String());
        }
    }
}
