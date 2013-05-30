using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Test settings
    /// </summary>
    public interface ITestInstance
    {
        /// <summary>
        /// Administrator ID
        /// </summary>
        Guid AdministeredBy { get;   }

        /// <summary>
        /// Administrator details
        /// </summary>
        IAdministrator Administrator { get;   }

        /// <summary>
        /// Exams that has been created from the Test Instance
        /// </summary>
        IEnumerable<ICandidateTest> CandidateTests { get;   }

        /// <summary>
        /// Test Instance ID
        /// </summary>
        Guid Id { get;   }

        /// <summary>
        /// Exam mode (Practice or Actual)
        /// </summary>
        bool IsPractice { get;   }

        /// <summary>
        /// Test Template ID
        /// </summary>
        Guid TemplateId { get;   }

        /// <summary>
        /// Test Template information
        /// </summary>
        ITestTemplate TestTemplate { get;   }

        /// <summary>
        /// Date Created
        /// </summary>
        DateTime DateCreated { get; }

        /// <summary>
        /// Token ID which is also the access code.
        /// </summary>
        int TokenId { get;   }

        /// <summary>
        /// Exam's time limit (in minutes)
        /// </summary>
        int TimeLimit { get; }

        /// <summary>
        /// Test Instance is Open
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Test Instance is Closed
        /// </summary>
        bool IsClosed { get; }
    }
}
