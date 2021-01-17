namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterUser1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "User_Id" });
            AddColumn("dbo.Characters", "UserId", c => c.String());
            DropColumn("dbo.Characters", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Characters", "UserId");
            CreateIndex("dbo.Characters", "User_Id");
            AddForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
