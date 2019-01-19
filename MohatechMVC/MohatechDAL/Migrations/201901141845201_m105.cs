namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m105 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "ParentId", c => c.Int(nullable: false));
        }
    }
}
