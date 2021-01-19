namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Problem = c.String(),
                        Solution = c.String(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Tickets", new[] { "Character_Id" });
            DropTable("dbo.Tickets");
        }
    }
}
