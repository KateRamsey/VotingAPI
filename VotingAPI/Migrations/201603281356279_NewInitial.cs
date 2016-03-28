namespace VotingAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HomeTown = c.String(),
                        District = c.String(),
                        Party = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Candidate_Id = c.Int(nullable: false),
                        Voter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id, cascadeDelete: true)
                .ForeignKey("dbo.Voters", t => t.Voter_Id, cascadeDelete: true)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Voter_Id);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Party = c.String(),
                        Token = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Voter_Id", "dbo.Voters");
            DropForeignKey("dbo.Votes", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.Votes", new[] { "Voter_Id" });
            DropIndex("dbo.Votes", new[] { "Candidate_Id" });
            DropTable("dbo.Voters");
            DropTable("dbo.Votes");
            DropTable("dbo.Candidates");
        }
    }
}
