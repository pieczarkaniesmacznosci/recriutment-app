using System;
using RecAppAPI.Models;
using RecAppAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RecAppAPI.Services
{
    public interface ICandidateService
    {
        IEnumerable<Candidate> GetAllCandidates();
        Candidate GetCandidate(int? id);
        void AddCandidate(Candidate candidate);
        void ChangeResult(int id);
        void EditCandidate(int id, Candidate candidate);
        void DeleteCandidate(int id);
    }

    public class CandidateService : ICandidateService
    {
        private ICandidateRepository candidateRepository;
        private List<Candidate> candidates;

        public CandidateService(ICandidateRepository candidateRepository)
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
            
            dataEntryToEdit.PositiveResult = !dataEntryToEdit.PositiveResult;
        }
        public void EditCandidate(int id, Candidate candidate)
        {
            var dataEntryToEdit = this.candidates.SingleOrDefault(e => e.Id == id);

            if (dataEntryToEdit == null)
            {
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }
            
            dataEntryToEdit.FirstName = candidate.FirstName;
            dataEntryToEdit.LastName = candidate.LastName;
            dataEntryToEdit.InterviewDate = candidate.InterviewDate;
            dataEntryToEdit.PositiveResult = candidate.PositiveResult;
        }

        public void DeleteCandidate(int id)
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