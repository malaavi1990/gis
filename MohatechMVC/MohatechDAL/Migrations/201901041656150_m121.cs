namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m121 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.News", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Books", "CreateDate");
        }
    }
}
