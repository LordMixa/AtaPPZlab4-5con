namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DBShows", newName: "Shows");
            RenameTable(name: "dbo.DBTickets", newName: "Tickets");
            AlterColumn("dbo.Shows", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Shows", "Author", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Shows", "Genre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Tickets", "NameShow", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tickets", "NameOfOwner", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "NameOfOwner", c => c.String());
            AlterColumn("dbo.Tickets", "NameShow", c => c.String());
            AlterColumn("dbo.Shows", "Genre", c => c.String());
            AlterColumn("dbo.Shows", "Author", c => c.String());
            AlterColumn("dbo.Shows", "Name", c => c.String());
            RenameTable(name: "dbo.Tickets", newName: "DBTickets");
            RenameTable(name: "dbo.Shows", newName: "DBShows");
        }
    }
}
