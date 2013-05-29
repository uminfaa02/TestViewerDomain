using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class CandidateTestStart : CandidateTestState
    {

        public override void Activate(CandidateTest test)
        {
            throw new BusinessRuleException("The test is already in progress");
        }

        public override void Start(CandidateTest test)
        {
            // NO-OP
        }

        public override void Close(CandidateTest test)
        {
            test.StateId = (int)ExamState.Closed;
        }
    }
}
