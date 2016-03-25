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
            context.Voters.Add(new Voter() {Name = "Kate Ramsey", Party = "Yes Please", Token = Guid.NewGuid().ToString()});
            context.SaveChanges();
        }
    }
}
