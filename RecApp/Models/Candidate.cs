using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecApp.Models.ViewModels;

namespace RecApp.Models
{
    public class Candidate
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime InterviewDate { get; set; }
        public Result? Result { get; set; }
    }
}
