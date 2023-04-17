namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202304132024392_202304132024392_InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DBShows");
            DropPrimaryKey("dbo.DBTickets");
            AlterColumn("dbo.DBShows", "DBShowId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DBTickets", "DBTicketId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DBShows", "DBShowId");
            AddPrimaryKey("dbo.DBTickets", "DBTicketId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DBTickets");
            DropPrimaryKey("dbo.DBShows");
            AlterColumn("dbo.DBTickets", "DBTicketId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DBShows", "DBShowId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DBTickets", "DBTicketId");
            AddPrimaryKey("dbo.DBShows", "DBShowId");
        }
    }
}
