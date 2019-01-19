namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "FullText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "FullText");
        }
    }
}
