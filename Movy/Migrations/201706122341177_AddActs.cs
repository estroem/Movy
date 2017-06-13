namespace Movy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Actor_Id = c.Int(),
                        Movie_Id = c.Int(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Actor_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.Character_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acts", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Acts", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Acts", "Actor_Id", "dbo.People");
            DropIndex("dbo.Acts", new[] { "Character_Id" });
            DropIndex("dbo.Acts", new[] { "Movie_Id" });
            DropIndex("dbo.Acts", new[] { "Actor_Id" });
            DropTable("dbo.Acts");
        }
    }
}
