using System;
using RecAppAPI.Models;

namespace RecAppAPI.Models
{
    public class Candidate
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime InterviewDate { get; set; }
        public Result Result { get; set; }
    }
}
