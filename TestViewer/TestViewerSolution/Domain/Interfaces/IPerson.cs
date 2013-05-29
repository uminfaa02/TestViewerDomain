using System;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Person (Candidate and Administrator) information
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Person ID
        /// </summary>
        Guid Id { get;  }

        /// <summary>
        /// Test Viewer details
        /// </summary>
        ITestViewer TestViewer { get; }

        /// <summary>
        /// Test Viewer ID
        /// </summary>
        Guid TestViewerId { get;  }

        /// <summary>
        /// Person Status
        /// </summary>
        bool Active { get; }
        
    }
}
