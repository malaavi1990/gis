namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig109 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "FullDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "FullDescription", c => c.String(nullable: false));
        }
    }
}
