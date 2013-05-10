using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ITestInstance
    {
        Guid AdministeredBy { get;   }
        IAdministrator Administrator { get;   }
        IEnumerable<ICandidateTest> CandidateTests { get;   }
        Guid Id { get;   }
        bool IsPractice { get;   }
        Guid TemplateId { get;   }
        ITestTemplate TestTemplate { get;   }
        int TokenId { get;   }
    }
}
