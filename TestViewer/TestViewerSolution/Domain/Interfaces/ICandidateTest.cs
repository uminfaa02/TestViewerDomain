using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Candidate Exam information.
    /// </summary>
    public interface ICandidateTest
    {
        /// <summary>
        /// Candidate Information
        /// </summary>
        ICandidate Candidate { get; }

        /// <summary>
        /// Candidate ID
        /// </summary>
        Guid CandidateId { get;   }

        /// <summary>
        /// Date and Time when the test has been created
        /// </summary>
        DateTime DateTime { get;   }

        /// <summary>
        /// Candidate Test ID
        /// </summary>
        Guid Id { get;   }

        /// <summary>
        /// Exam's State
        /// </summary>
        int StateId { get;   }

        /// <summary>
        /// The Test Instance information
        /// </summary>
        ITestInstance TestInstance { get;   }

        /// <summary>
        /// Test Instance ID
        /// </summary>
        Guid TestInstanceId { get;   }

        /// <summary>
        /// Exam Questions
        /// </summary>
        IEnumerable<IQuestion> Questions { get; }
        
        /// <summary>
        /// Exam time limit
        /// </summary>
        int TimeLimit { get; }

        /// <summary>
        /// Number of correct answers
        /// </summary>
        int correctAnswers { get; }

        /// <summary>
        /// Number of incorrect answers
        /// </summary>
        int inCorrectAnswers { get; }

        /// <summary>
        /// Exam State
        /// </summary>
        string State { get; }
    }
}
