using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// An Interface that contains Question Bank information
    /// </summary>
    public interface IQuestionBank
    {
        /// <summary>
        /// Collection of questions associated with the Question Bank
        /// </summary>
        IEnumerable<IQuestion> Questions { get; }

        /// <summary>
        /// Test Viewer where it is associated with
        /// </summary>
        ITestViewer TestViewer { get;  }

        /// <summary>
        /// Test Viewer ID
        /// </summary>
        Guid TestViewerId { get;  }
    }
}
