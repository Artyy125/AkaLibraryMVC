namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberIdremoved2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableBookModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Library_Book", "Signout", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Library_Book", "Signout");
            DropTable("dbo.AvailableBookModels");
        }
    }
}
