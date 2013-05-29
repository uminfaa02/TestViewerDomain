using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// Aggregate root of the system.
    /// </summary>
    public interface ITestViewer
    {  
        /// <summary>
        /// Collection of candidates
        /// </summary>
        IEnumerable<ICandidate> Candidates { get; }

        /// <summary>
        /// Developer of the system
        /// </summary>
        string DevelopedBy { get;  }

        /// <summary>
        /// TestViewer ID
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Collection of Candidates and Administrators
        /// </summary>
        IEnumerable<IPerson> People { get;  }

        /// <summary>
        /// Manages all questions
        /// </summary>
        IQuestionBank QuestionBank { get;  }

        /// <summary>
        /// Collection of questions
        /// </summary>
        IEnumerable<IQuestion> Questions { get; }

        /// <summary>
        /// Collection of Test Templates
        /// </summary>
        IEnumerable<ITestTemplate> TestTemplates { get;  }
    }
}
