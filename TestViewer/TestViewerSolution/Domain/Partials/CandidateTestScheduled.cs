using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class CandidateTestScheduled :CandidateTestState
    {

        public override void Activate(CandidateTest test)
        {
            test.StateId = (int)ExamState.Active; 
        }

        public override void Close(CandidateTest test)
        {
            throw new BusinessRuleException("The test must be activated prior to closing");
        }

        public override void Start(CandidateTest test)
        {
            throw new BusinessRuleException("The test must be activated prior to starting");
        }
    }
}
