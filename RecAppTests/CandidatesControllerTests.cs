using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RecAppAPI.Controllers;
using RecAppAPI.Models;
using RecAppAPI.Services;

namespace RecAppTests
{
    [TestFixture]
    public class CandidatesControllerTests
    {
        private Mock<ICandidateService> candidateService;
        private CandidatesController candidatesController;

        [SetUp]
        public void SetUp()
        {
            this.candidateService = new Mock<ICandidateService>();
            this.candidatesController = new CandidatesController(this.candidateService.Object);
        }

        [Test]
        public void Get_CalledWithoutId_ResultContainsAllElements()
        {
            // Arrange
            this.candidateService.Setup(x => x.GetAllCandidates()).Returns(new List<Candidate>
            {
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
                }
            });

            // Act
            var result = this.candidatesController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.ElementAt(0).Id, 2);
        }

        [Test]
        public void Get_CalledWithId_ResultContainsElements()
        {
            // Arrange
            this.candidateService.Setup(x => x.GetCandidate(2))
                .Returns(
                    new Candidate
                    {
                        Id = 2,
                        FirstName = "Michael",
                        LastName = "Scott",
                        InterviewDate = new DateTime(2020, 01, 10, 14, 00, 00),
                        Result = Result.Positive
                    });

            // Act
            var result = candidatesController.Get(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.LastName, "Scott");
        }

        [Test]
        public void Post_CalledWithNullArgument_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => candidatesController.Post(""));
        }

        [Test]
        public void Post_CalledWithInvalidArgument_ThrowsArgumentException()
        {
            var objToAdd = "sdafscxzcvcxzxcv";

            // Assert
            Assert.Throws<ArgumentException>(() => candidatesController.Post(objToAdd));
        }


        [Test]
        public void Post_CalledWithValidArgument_DoesNotThrowException()
        {
            // Arrange
            var candidateToAdd =
                    new Candidate
                    {
                        Id = 2,
                        FirstName = "Michael",
                        LastName = "Scott",
                        InterviewDate = new DateTime(2020, 01, 10, 14, 00, 00),
                        Result = Result.Positive
                    };

            var candidateJson = JsonConvert.SerializeObject(candidateToAdd);

            // Assert
            Assert.DoesNotThrow(() => candidatesController.Post(candidateJson));
        }

        [Test]
        public void Put_CalledWithNullArgument_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => candidatesController.Put(""));
        }

        [Test]
        public void Put_CalledWithInvalidCandidateArgument_ThrowsArgumentException()
        {
            var objToAdd = "sdafscxzcvcxzxcv";

            // Assert
            Assert.Throws<ArgumentException>(() => candidatesController.Put(objToAdd));
        }


        [Test]
        public void Put_CalledWithValidCandidateArgument_DoesNotThrowException()
        {
            // Arrange
            var candidateToAdd =
                new Candidate
                {
                    Id = 2,
                    FirstName = "Michael",
                    LastName = "Scottish",
                    InterviewDate = new DateTime(2020, 01, 10, 14, 00, 00),
                    Result = Result.Positive
                };

            var candidateJson = JsonConvert.SerializeObject(candidateToAdd);

            // Assert
            Assert.DoesNotThrow(() => candidatesController.Put(candidateJson));
        }
    }
}