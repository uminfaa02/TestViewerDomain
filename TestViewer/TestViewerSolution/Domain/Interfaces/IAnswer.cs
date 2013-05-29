using System;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Answer information
    /// </summary>
    public interface IAnswer
    {
        /// <summary>
        /// Candidate Test or the exam it is associated with
        /// </summary>
        ICandidateTest CandidateTest { get;  }

        /// <summary>
        /// Candidate Test ID
        /// </summary>
        Guid CandidateTestId { get;  }

        /// <summary>
        /// Choice details
        /// </summary>
        IChoice Choice { get;  }

        /// <summary>
        /// Choice ID
        /// </summary>
        Guid ChoiceId { get;  }

        /// <summary>
        /// Date and time when it has been answered
        /// </summary>
        DateTime DateTime { get;  }

        /// <summary>
        /// Answer ID
        /// </summary>
        Guid Id { get;  }
    }
}
