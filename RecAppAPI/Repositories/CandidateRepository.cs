using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecAppAPI.Models;

namespace RecAppAPI.Repositories
{
    public interface ICandidateRepository
    {
        List<Candidate> GetCandidates();
    }

    public class CandidateRepository : ICandidateRepository
    {
        public List<Candidate> GetCandidates()
        {
            var candidatesList = new List<Candidate>
            {
                new Candidate()
                {
                    Id = 1,
                    FirstName = "Lukasz",
                    LastName = "Pieczonka",
                    InterviewDate = new DateTime(2020,01,10,10,10,10),
                    PositiveResult = true
                },
                new Candidate()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    InterviewDate = new DateTime(2020,01,10,10,10,10),
                    PositiveResult = false
                },
                new Candidate()
                {
                    Id = 3,
                    FirstName = "Mike",
                    LastName = "Smith",
                    InterviewDate = new DateTime(2020,01,10,10,10,10),
                    PositiveResult = false
                },
                new Candidate()
                {
                    Id = 4,
                    FirstName = "Chris",
                    LastName = "Bird",
                    InterviewDate = new DateTime(2020,02,12,13,10,10),
                    PositiveResult = true
                }
            };

            return candidatesList;
        }
    }
}
