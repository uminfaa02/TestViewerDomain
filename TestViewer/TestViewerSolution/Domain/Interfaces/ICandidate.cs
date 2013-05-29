using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Candidate information
    /// </summary>
    public interface ICandidate : IPerson
    {
        /// <summary>
        /// Collection of Candidate Tests it is associated with
        /// </summary>
        IEnumerable<ICandidateTest> CandidateTests { get;  }

        /// <summary>
        /// Student Number
        /// </summary>
        string StudentNumber { get; }

        /// <summary>
        /// Had taken Exam (All Exams associated with the candidate)
        /// </summary>
        bool HadTakenExam { get; }

        /// <summary>
        /// Exams that has not been taken yet
        /// </summary>
        bool HasPendingExams { get; }

        /// <summary>
        /// Exams that is being taken by the candidate
        /// </summary>
        bool HasInProgressExams { get; }

        /// <summary>
        /// Collection of Pending Exams (Exams that has not been taken yet)
        /// </summary>
        IEnumerable<ICandidateTest> PendingExams { get; }

        /// <summary>
        /// Collection of In-Progress Exams (Exams that is being taken by the candidate)
        /// </summary>
        IEnumerable<ICandidateTest> InProgressExams { get; }
    }
}
