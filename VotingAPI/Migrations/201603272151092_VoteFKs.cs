namespace VotingAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.Votes", new[] { "Candidate_Id" });
            DropIndex("dbo.Votes", new[] { "Voter_Id" });
          // DropColumn("dbo.Votes", "Id");
           // RenameColumn(table: "dbo.Votes", name: "Voter_Id", newName: "Id");
            DropPrimaryKey("dbo.Votes");
         //  AlterColumn("dbo.Votes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Votes", "Candidate_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Votes", "Voter_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Votes", "Voter_Id");
            CreateIndex("dbo.Votes", "Voter_Id");
            CreateIndex("dbo.Votes", "Candidate_Id");
            AddForeignKey("dbo.Votes", "Candidate_Id", "dbo.Candidates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.Votes", new[] { "Candidate_Id" });
            DropIndex("dbo.Votes", new[] { "Id" });
            DropPrimaryKey("dbo.Votes");
            AlterColumn("dbo.Votes", "Id", c => c.Int());
            AlterColumn("dbo.Votes", "Candidate_Id", c => c.Int());
            AlterColumn("dbo.Votes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Votes", "Id");
            RenameColumn(table: "dbo.Votes", name: "Id", newName: "Voter_Id");
            AddColumn("dbo.Votes", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Votes", "Voter_Id");
            CreateIndex("dbo.Votes", "Candidate_Id");
            AddForeignKey("dbo.Votes", "Candidate_Id", "dbo.Candidates", "Id");
        }
    }
}
