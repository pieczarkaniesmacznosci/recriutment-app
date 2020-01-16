using System;
using System.Collections.Generic;

namespace RecApp.Models.ViewModels
{
    public interface IHomeViewModel
    {
        List<Candidate> Candidates { get; }
        Result Result { get; }
    }
    public enum Result
    {
        Positive = 1,
        Negative = 2
    }

    public class HomeViewModel : IHomeViewModel
    {
        public List<Candidate> Candidates =>
            new List<Candidate>
            {
                new Candidate
                {
                    Id = 1,
                    FirstName = "Lukasz",
                    LastName = "Pieczonka",
                    InterviewDate = new DateTime(2020,01,10,12,15,00),
                    Result = Result.Positive
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "Michael",
                    LastName = "Scott",
                    InterviewDate = new DateTime(2020,01,10,14,00,00),
                    Result = Result.Positive
                },
                new Candidate
                {
                    Id = 3,
                    FirstName = "Pam",
                    LastName = "Beesly",
                    InterviewDate = new DateTime(2020,01,13,14,30,00),
                    Result = Result.Negative
                },
                new Candidate
                {
                    Id = 4,
                    FirstName = "Jim",
                    LastName = "Helpert",
                    InterviewDate = new DateTime(2020,01,14,16,00,10),
                    Result = Result.Negative
                },
                new Candidate
                {
                    Id = 5,
                    FirstName = "Andy",
                    LastName = "Bernard",
                    InterviewDate = new DateTime(2020,02,07,13,30,00),
                    Result = Result.Negative
                },
                new Candidate
                {
                    Id = 6,
                    FirstName = "Kevin",
                    LastName = "Malone",
                    InterviewDate = new DateTime(2020,02,14,13,30,00),
                    Result = Result.Positive
                },
                new Candidate
                {
                    Id = 7,
                    FirstName = "John",
                    LastName = "Doe",
                    InterviewDate = new DateTime(2020,01,13,15,30,00),
                    Result = Result.Negative
                },
                new Candidate
                {
                    Id = 8,
                    FirstName = "Mike",
                    LastName = "Smith",
                    InterviewDate = new DateTime(2020,01,14,16,00,10),
                    Result = Result.Negative
                }
            };

        public Result Result { get; }
    }
}
