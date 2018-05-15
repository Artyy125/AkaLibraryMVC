namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingoutValue2 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AvailableBookModels");
        }
    }
}
