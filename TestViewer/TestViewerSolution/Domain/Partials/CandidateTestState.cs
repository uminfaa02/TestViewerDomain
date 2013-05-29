using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal abstract class CandidateTestState
    {
        public abstract void Activate(CandidateTest test);
        public abstract void Start(CandidateTest test);
        public abstract void Close(CandidateTest test); 

    }
}
