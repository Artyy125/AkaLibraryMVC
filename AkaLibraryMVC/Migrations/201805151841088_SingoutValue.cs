namespace AkaLibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingoutValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("Library_Book", "Signout", c => c.Int());

        }
        
        public override void Down()
        {
            DropColumn("Library_Book", "Signout");
        }
    }
}
