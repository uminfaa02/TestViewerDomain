using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class CandidateTestScheduled :CandidateTestState, ICandidateTestScheduled
    {

        public override void DoSomething()
        {
            throw new BusinessRuleException("I'm still scheduled and not ready to do anything yet");
        }

        public override void Activate(CandidateTest test)
        {
            test.StateId = 2; 
        }

        public override void Close(CandidateTest test)
        {
            throw new BusinessRuleException("The test must be activated prior to closing");
        }
    }
}
