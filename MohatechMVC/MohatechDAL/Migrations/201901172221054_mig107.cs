namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig107 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "FullText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "FullText", c => c.String(nullable: false));
        }
    }
}
