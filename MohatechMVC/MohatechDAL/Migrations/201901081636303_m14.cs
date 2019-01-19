namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ActiveCode", c => c.String());
            AlterColumn("dbo.Users", "RegisterDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "RegisterDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "ActiveCode", c => c.String(nullable: false));
        }
    }
}
