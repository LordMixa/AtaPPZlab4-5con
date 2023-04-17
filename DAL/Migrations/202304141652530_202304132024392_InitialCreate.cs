namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202304132024392_InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBShows",
                c => new
                    {
                        DBShowId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                        CountSeats = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DBShowId);
            
            CreateTable(
                "dbo.DBTickets",
                c => new
                    {
                        DBTicketId = c.String(nullable: false, maxLength: 128),
                        NameShow = c.String(),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        NameOfOwner = c.String(),
                    })
                .PrimaryKey(t => t.DBTicketId);
            
            DropTable("dbo.Shows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                        CountSeats = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ShowId);
            
            DropTable("dbo.DBTickets");
            DropTable("dbo.DBShows");
        }
    }
}
