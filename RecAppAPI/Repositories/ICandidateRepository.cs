using System.Collections.Generic;
using RecAppAPI.Models;

namespace RecAppAPI.Repositories
{
    public interface ICandidateRepository
    {
        List<Candidate> GetCandidates();
    }
}