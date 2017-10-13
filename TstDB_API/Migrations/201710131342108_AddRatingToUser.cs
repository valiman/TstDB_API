namespace TstDB_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Rating");
        }
    }
}
