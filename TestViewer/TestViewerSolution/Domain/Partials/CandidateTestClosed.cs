﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class CandidateTestClosed : CandidateTestState
    {

        public override void Activate(CandidateTest test)
        {
            throw new BusinessRuleException("The test has already been closed and can not be activated"); 
        }

        public override void Close(CandidateTest test)
        {
            //NO-OP
        }

        public override void Start(CandidateTest test)
        {
            throw new BusinessRuleException("The test has already been closed and can not be restarted"); 
        }
    }
}
