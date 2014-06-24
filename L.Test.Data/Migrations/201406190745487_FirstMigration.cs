namespace L.Test.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        PassWord = c.String(nullable: false, maxLength: 200),
                        RealName = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 10),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
