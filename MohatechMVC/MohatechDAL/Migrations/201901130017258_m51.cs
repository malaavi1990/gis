namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Text", c => c.String(nullable: false));
        }
    }
}
