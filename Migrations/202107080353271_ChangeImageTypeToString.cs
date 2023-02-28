namespace MemberApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageTypeToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PhotoPath", c => c.String());
            DropColumn("dbo.Members", "ProfileImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "ProfileImage", c => c.Binary());
            DropColumn("dbo.Members", "PhotoPath");
        }
    }
}
