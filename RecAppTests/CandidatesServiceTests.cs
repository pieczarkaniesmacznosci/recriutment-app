using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using RecAppAPI.Models;
using RecAppAPI.Repositories;
using RecAppAPI.Services;

namespace RecAppTests
{
    [TestFixture]
    public class CandidatesServiceTests
    {
        private CandidatesService candidatesService;
        private Mock<ICandidatesRepository> data;

        [SetUp]
        public void SetUp()
        {
            this.data = new Mock<ICandidatesRepository>();
            this.data.Setup(x => x.GetCandidates()).Returns(
                new List<Candidate>
                {
                    new Candidate
                    {
                        Id = 1,
                        FirstName = "Lukasz",
                        LastName = "Pieczonka",
                        InterviewDate = new DateTime(2020, 01, 10, 12, 15, 00),
                        Result = Result.Positive
                    },
                    new Candidate
                    {
                        Id = 2,
                        FirstName = "Michael",
                        LastName = "Scott",
                        InterviewDate = new DateTime(2020, 01, 10, 14, 00, 00),
                        Result = Result.Positive
                    },
                    new Candidate
                    {
                        Id = 3,
                        FirstName = "Pam",
                        LastName = "Beesly",
                        InterviewDate = new DateTime(2020, 01, 13, 14, 30, 00),
                        Result = Result.Negative
                    },
                    new Candidate
                    {
                        Id = 4,
                        FirstName = "Jim",
                        LastName = "Helpert",
                        InterviewDate = new DateTime(2020, 01, 14, 16, 00, 10),
                        Result = Result.Negative
                    }
                });

            this.candidatesService = new CandidatesService(this.data.Object);

        }

        [Test]
        public void GetAllCandidates_CalledOnExampleJson_ConsistAllElements()
        {
            var result = this.candidatesService.GetAllCandidates();

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void GetCandidate_CalledWithValidId_ReturnsElement()
        {
            var result = this.candidatesService.GetCandidate(2);

            Assert.AreEqual(result.FirstName, "Michael");
        }

        [Test]
        public void GetCandidate_CalledWithInvalidId_ThrowsKeyNotFoundError()
        {
            Assert.Throws<KeyNotFoundException>(() => this.candidatesService.GetCandidate(122121));
        }

        [Test]
        public void AddCandidate_Called_AddsToTheCollectionWithNextAvailableId()
        {
            this.candidatesService.AddCandidate(
                new Candidate
                {
                    Id = 4,
                    FirstName = "Ron",
                    LastName = "Weasley",
                    InterviewDate = new DateTime(2020, 01, 14, 16, 00, 10),
                    Result = Result.Negative
                });

            var result = this.candidatesService.GetAllCandidates();

            Assert.AreEqual(5,result.ElementAt(4).Id);
        }

        [Test]
        public void ChangeResult_CalledWithInvalidId_ThrowsKeyNotFoundError()
        {
            Assert.Throws<KeyNotFoundException>(() => this.candidatesService.ChangeResult(122121));
        }

        [Test]
        public void ChangeResult_CalledWithValidId_ChangesResult()
        {
            this.candidatesService.ChangeResult(2);
            var result = this.candidatesService.GetAllCandidates();
            Assert.AreEqual(Result.Negative, result.ElementAt(1).Result);
        }
        
        [Test]
        public void EditCandidate_CalledWithInvalidId_ThrowsKeyNotFoundException()
        {
            var candidateToEdit =
                new Candidate
                {
                    Id = 1111111112,
                    FirstName = "Ron",
                    LastName = "Weasley",
                    InterviewDate = new DateTime(2020, 01, 14, 16, 00, 10),
                    Result = Result.Negative
                };

            var result = this.candidatesService.GetAllCandidates();

            Assert.Throws<KeyNotFoundException>(()=>this.candidatesService.EditCandidate(candidateToEdit));
        }

        [Test]
        public void EditCandidate_CalledWithValidId_EditsEntry()
        {
            var editedEntry = new Candidate
            {
                Id = 2,
                FirstName = "Michael",
                LastName = "Scottish",
                InterviewDate = new DateTime(2020, 01, 10, 14, 00, 00),
                Result = Result.Positive
            };
            // Act
            this.candidatesService.EditCandidate(editedEntry);

            var result = this.candidatesService.GetAllCandidates();
            // Assert
            Assert.AreEqual(result.ElementAt(1).LastName, "Scottish");
        }

        [Test]
        public void DeleteCandidate_CalledWithInvalidId_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => this.candidatesService.DeleteCandidate(122121));
        }

        [Test]
        public void DeleteCandidate_CalledWithValidId_DeletesEntry()
        {
            // Act
            this.candidatesService.DeleteCandidate(2);
            var result = this.candidatesService.GetAllCandidates();

            // Assert
            Assert.AreEqual(3,result.Count());
        }
    }
}
