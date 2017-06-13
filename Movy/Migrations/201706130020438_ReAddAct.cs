namespace Movy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddAct : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acts", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Acts", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Acts", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Acts", new[] { "Person_Id" });
            DropIndex("dbo.Acts", new[] { "Movie_Id" });
            DropIndex("dbo.Acts", new[] { "Character_Id" });
            DropTable("dbo.Acts");
        }
    }
}
