namespace Movy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeActorToPersonInAct : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Acts", name: "Actor_Id", newName: "Person_Id");
            RenameIndex(table: "dbo.Acts", name: "IX_Actor_Id", newName: "IX_Person_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Acts", name: "IX_Person_Id", newName: "IX_Actor_Id");
            RenameColumn(table: "dbo.Acts", name: "Person_Id", newName: "Actor_Id");
        }
    }
}
