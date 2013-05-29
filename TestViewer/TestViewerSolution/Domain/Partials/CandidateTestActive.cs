using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class CandidateTestActive : CandidateTestState
    {

        public override void Activate(CandidateTest test)
        {
           //NO-OP
        }

        public override void Close(CandidateTest test)
        {
            test.StateId = (int)ExamState.Closed; 
        }

        public override void Start(CandidateTest test)
        {
            test.StateId = (int)ExamState.InProgress;
        }
    }
}
