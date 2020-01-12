using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecAppAPI.Models;
using RecAppAPI.Repositories;
using RecAppAPI.Services;

namespace RecAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        public ValuesController(ICandidateService candidateService)
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
        public void Put(int id, [FromBody] string candidateJson)
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
            this.candidateService.EditCandidate(id,candidateToAdd);
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
