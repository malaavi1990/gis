namespace MohatechDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        SoftwareId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 400),
                        Text = c.String(),
                        Visit = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.SoftwareId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Softwares");
        }
    }
}
