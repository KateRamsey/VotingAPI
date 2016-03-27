using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class VoteCount
    {
        public Candidate Candidate { get; set; }
        public int Count { get; set; }
    }
}