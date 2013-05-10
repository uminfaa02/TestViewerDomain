using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ITestTemplate
    {
        Guid Id { get;   }
        string Name { get;   }
        IEnumerable<IQuestion> Questions { get;   }
        IEnumerable<ITestInstance> TestInstances { get;   }
        ITestViewer TestViewer { get;   }
        Guid TestViewerId { get;   }
    }
}
