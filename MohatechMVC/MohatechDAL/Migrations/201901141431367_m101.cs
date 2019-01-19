namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m101 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Text", c => c.String());
        }
    }
}
