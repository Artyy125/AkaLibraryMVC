namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberIdremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Library_Book", "MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Library_Book", "MemberId", c => c.Int(nullable: false));
        }
    }
}
