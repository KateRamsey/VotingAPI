using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Candidate
    {
        public Candidate()
        {
            Votes = new List<Vote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public string District { get; set; }
        public string Party { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}