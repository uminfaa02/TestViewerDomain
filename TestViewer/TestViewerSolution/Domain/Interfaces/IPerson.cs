using System;
namespace Domain
{
    public interface IPerson
    {
        Guid Id { get;  }
        ITestViewer TestViewer { get; }
        Guid TestViewerId { get;  }
        bool Active { get; }
        
    }
}
