using System.Collections.Generic;

namespace RecApp.Models.ViewModels
{
    public interface IHomeViewModel
    {
        List<Candidate> Candidates { get; }
        Result Result { get; }
    }
}