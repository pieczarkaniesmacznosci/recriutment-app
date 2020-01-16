using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecAppAPI.Models;
using RecAppAPI.Services;

namespace RecAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Candidate> Get()
        {
            return this.candidateService.GetAllCandidates();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Candidate Get(int? id)
        {
            return this.candidateService.GetCandidate(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string candidateJson)
        {
            if (string.IsNullOrWhiteSpace(candidateJson))
            {
                throw new ArgumentNullException("No object to post.");
            }

            Candidate candidateToAdd;
            try
            {
                candidateToAdd = JsonConvert.DeserializeObject<Candidate>(candidateJson);
            }
            catch (JsonReaderException)
            {
                throw new ArgumentException($"Invalid json provided: {candidateJson}");
            }
            this.candidateService.AddCandidate(candidateToAdd);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] string candidateJson)
        {
            Candidate candidateToAdd;
            try
            {
                candidateToAdd = JsonConvert.DeserializeObject<Candidate>(candidateJson);
            }
            catch (JsonReaderException)
            {
                throw new ArgumentException($"Invalid json provided: {candidateJson}");
            }
            this.candidateService.EditCandidate(candidateToAdd);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void ChangeResult(int id)
        {
            this.candidateService.ChangeResult(id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int? id)
        {
            this.candidateService.DeleteCandidate(id);
        }
    }
}