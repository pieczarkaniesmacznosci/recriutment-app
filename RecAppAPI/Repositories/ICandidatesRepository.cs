using System.Collections.Generic;
using RecAppAPI.Models;

namespace RecAppAPI.Repositories
{
    public interface ICandidatesRepository
    {
        List<Candidate> GetCandidates();
    }
}