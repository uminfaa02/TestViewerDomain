using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An Interface that contains Administrator information
    /// </summary>
    public interface IAdministrator : IPerson
    {
        /// <summary>
        /// First or Given Name
        /// </summary>
        string GivenName { get;  }

        /// <summary>
        /// Last name
        /// </summary>
        string LastName { get;  }

        /// <summary>
        /// Collection of Test Instances associated with the Administrator
        /// </summary>
        IEnumerable<ITestInstance> TestInstances { get;  }
    }
}
