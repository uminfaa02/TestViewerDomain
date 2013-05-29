using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Test Template details
    /// </summary>
    public interface ITestTemplate
    {
        /// <summary>
        /// Test Template ID
        /// </summary>
        Guid Id { get;   }

        /// <summary>
        /// Test Template Name
        /// </summary>
        string Name { get;   }

        /// <summary>
        /// Collection of questions in the test template
        /// </summary>
        IEnumerable<IQuestion> Questions { get;   }

        /// <summary>
        /// Collection of Test Instances that uses the test template
        /// </summary>
        IEnumerable<ITestInstance> TestInstances { get;   }

        /// <summary>
        /// TestViewer where it is associated with
        /// </summary>
        ITestViewer TestViewer { get;   }

        /// <summary>
        /// TestViewer ID
        /// </summary>
        Guid TestViewerId { get;   }
    }
}
