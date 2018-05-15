namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingoutValue3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Library_Book", "Signout", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Library_Book", "Signout", c => c.Int(nullable: false));
        }
    }
}
