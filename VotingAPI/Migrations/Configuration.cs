namespace VotingAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VotingAPI.Models.VotingAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VotingAPI.Models.VotingAPIContext context)
        {
            if (!context.Voters.Any())
            {
                Voter kr = new Voter() { Name = "Kate Ramsey", Party = "Yes Please", Token = Guid.NewGuid() };
                Voter bw = new Voter() { Name = "Bruce Wills", Party = "IDK", Token = Guid.NewGuid() };
                Voter jt = new Voter() { Name = "Jennifer Tate", Party = "Mommy", Token = Guid.NewGuid() };
                Voter ar = new Voter() { Name = "Alice Ramsey", Party = "Nope", Token = Guid.NewGuid() };
                Voter st = new Voter() { Name = "Stephen Ramsey", Party = "Tea Party", Token = Guid.NewGuid() };

                Candidate joe = new Candidate() { Name = "Joe Joe", Party = "IDK", District = "AR", HomeTown = "Searcy" };
                Candidate bob = new Candidate() { Name = "Bob Bob", Party = "Nope", District = "AR", HomeTown = "Cabot" };
                Candidate tom = new Candidate() { Name = "Tom Tom", Party = "Tea Party", District = "AR", HomeTown = "Gravel Ridge"};
                Candidate scott = new Candidate() { Name = "Scott Scott",Party = "IDK", District = "AR", HomeTown = "Sherwood"};

                Vote krVote = new Vote() { Candidate = joe, Voter = kr };
                Vote jtVote = new Vote() { Candidate = tom, Voter = jt };
                Vote stVote = new Vote() { Candidate = bob, Voter = st };


                context.Voters.Add(kr);
                context.Voters.Add(bw);
                context.Voters.Add(jt);
                context.Voters.Add(ar);
                context.Voters.Add(st);

                context.Candidates.Add(joe);
                context.Candidates.Add(bob);
                context.Candidates.Add(tom);
                context.Candidates.Add(scott);

                context.Votes.Add(krVote);
                context.Votes.Add(jtVote);
                context.Votes.Add(stVote);

                context.SaveChanges();
            }
        }
    }
}
