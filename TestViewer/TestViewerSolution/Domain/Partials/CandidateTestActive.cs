using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class CandidateTestActive : CandidateTestState, ICandidateTestActive
    {
        public override void DoSomething()
        {
            Console.WriteLine("Something is being done"); 
        }

        public override void Activate(CandidateTest test)
        {
           //NO-OP
        }

        public override void Close(CandidateTest test)
        {
            test.StateId = 3; 
        }
    }
}
