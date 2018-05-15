namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Library_Book", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Library_Book", "MemberId");
        }
    }
}
