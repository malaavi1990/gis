namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "ImageName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
