namespace Movy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acts", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Acts", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Acts", "Person_Id", "dbo.People");
            DropIndex("dbo.Acts", new[] { "Character_Id" });
            DropIndex("dbo.Acts", new[] { "Movie_Id" });
            DropIndex("dbo.Acts", new[] { "Person_Id" });
            DropTable("dbo.Acts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Acts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Character_Id = c.Int(),
                        Movie_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Acts", "Person_Id");
            CreateIndex("dbo.Acts", "Movie_Id");
            CreateIndex("dbo.Acts", "Character_Id");
            AddForeignKey("dbo.Acts", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Acts", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Acts", "Character_Id", "dbo.Characters", "Id");
        }
    }
}
