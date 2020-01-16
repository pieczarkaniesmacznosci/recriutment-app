using System;
using RecAppAPI.Models;
using RecAppAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecAppAPI.Services
{
    public class CandidatesService : ICandidatesService
    {
        private readonly ICandidatesRepository candidateRepository;
        private readonly List<Candidate> candidates;

        public CandidatesService(ICandidatesRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
            candidates = this.candidateRepository.GetCandidates();
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return this.candidates;
        }

        public Candidate GetCandidate(int? id)
        {
            var dataEntry = this.candidates.SingleOrDefault(e => e.Id == id);

            if (dataEntry == null)
            {
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }

            return dataEntry;
        }

        public void AddCandidate(Candidate candidate)
        {
            if (candidate.Id != null)
            {
                candidate.Id = null;
            }

            var intSublist = this.candidates.Select(e => e.Id).OrderBy(e=>e.Value);
            var nextAvailableId = intSublist.LastOrDefault() + 1;
            candidate.Id = nextAvailableId;

            candidates.Add(candidate);
        }

        public void ChangeResult(int id)
        {
            var dataEntryToEdit = this.candidates.SingleOrDefault(e => e.Id == id);

            if (dataEntryToEdit == null)
            {
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }

            dataEntryToEdit.Result = dataEntryToEdit.Result == Result.Positive ? Result.Negative : Result.Positive;
        }

        public void EditCandidate(Candidate candidate)
        {
            var dataEntryToEdit = this.candidates.SingleOrDefault(e => e.Id == candidate.Id);

            if (dataEntryToEdit == null)
            {
                throw new KeyNotFoundException($"Data entry not found");
            }
            
            dataEntryToEdit.FirstName = candidate.FirstName;
            dataEntryToEdit.LastName = candidate.LastName;
            dataEntryToEdit.InterviewDate = candidate.InterviewDate;
            dataEntryToEdit.Result = candidate.Result;
        }

        public void DeleteCandidate(int? id)
        {
            var dataEntryToDelete = this.candidates.SingleOrDefault(e => e.Id == id);

            if (dataEntryToDelete == null)
            {
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }

            this.candidates.Remove(dataEntryToDelete);
        }
    }
}