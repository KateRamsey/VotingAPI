using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string Token { get; set; }
    }
}