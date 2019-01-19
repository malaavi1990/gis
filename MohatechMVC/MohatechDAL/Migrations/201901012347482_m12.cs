namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ImageName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ImageName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
