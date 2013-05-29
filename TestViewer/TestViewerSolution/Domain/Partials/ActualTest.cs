using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class ActualTest : CandidateTest, IActualTest
    {
        public ActualTest() { }
        public ActualTest(Candidate candidate)
            :base(candidate)
        {
        }

    }
}
