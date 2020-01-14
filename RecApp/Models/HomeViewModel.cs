using System;
using System.Collections.Generic;

namespace RecApp.Models.ViewModels
{
    public interface IHomeViewModel
    {
        List<Candidate> Candidates { get; }
    }

    public class HomeViewModel : IHomeViewModel
    {
        public List<Candidate> Candidates =>
            new List<Candidate>
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
    }
}
