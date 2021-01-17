namespace PlainsOfPrimus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Characters", "User_Id");
            AddForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "User_Id" });
            DropColumn("dbo.Characters", "User_Id");
        }
    }
}
