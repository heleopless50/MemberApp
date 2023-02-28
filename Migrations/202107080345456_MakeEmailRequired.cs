namespace MemberApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeEmailRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Email", c => c.String());
        }
    }
}
