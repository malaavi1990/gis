namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Settings", "NavIcon");
            DropColumn("dbo.Settings", "WorkTime");
            DropColumn("dbo.Settings", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Logo", c => c.String(maxLength: 200));
            AddColumn("dbo.Settings", "WorkTime", c => c.String(maxLength: 100));
            AddColumn("dbo.Settings", "NavIcon", c => c.String(maxLength: 200));
        }
    }
}
