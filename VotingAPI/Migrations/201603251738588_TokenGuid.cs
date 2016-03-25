namespace VotingAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenGuid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voters", "Token", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voters", "Token", c => c.String());
        }
    }
}
