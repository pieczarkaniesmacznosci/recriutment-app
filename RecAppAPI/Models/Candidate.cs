using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecAppAPI.Models
{
    public class Candidate
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime InterviewDate { get; set; }
        public bool PositiveResult { get; set; }
    }
}
