using System.Collections.Generic;
using RecAppAPI.Models;

namespace RecAppAPI.Services
{
    public interface ICandidatesService
    {
        IEnumerable<Candidate> GetAllCandidates();
        Candidate GetCandidate(int? id);
        void AddCandidate(Candidate candidate);
        void ChangeResult(int id);
        void EditCandidate(Candidate candidate);
        void DeleteCandidate(int? id);
    }
}