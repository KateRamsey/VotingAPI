using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Votes
    {
        public int Id { get; set; }
        public Voter Voter { get; set; }
        public Candidate Candidate { get; set; }
    }
}