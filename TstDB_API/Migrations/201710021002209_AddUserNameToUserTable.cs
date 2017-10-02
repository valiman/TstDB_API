namespace TstDB_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameToUserTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Users SET UserName='KniX' where Id_IdentityUser='cdb75b7d-abd6-4687-9b6e-33629fdfaa72'");
            Sql("UPDATE Users SET UserName='isSoCool' where Id_IdentityUser='9b76610e-3ab9-4b69-a5b2-337bdcd9378a'");
        }
        
        public override void Down()
        {
        }
    }
}
