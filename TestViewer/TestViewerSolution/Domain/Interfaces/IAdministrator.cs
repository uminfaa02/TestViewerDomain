using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IAdministrator : IPerson
    {
        string GivenName { get;  }
        string LastName { get;  }
        IEnumerable<ITestInstance> TestInstances { get;  }
    }
}
