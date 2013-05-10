using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal abstract partial class CandidateTest : ICandidateTest
    {


        public CandidateTest(Candidate candidate) : this()
        {
            Candidate = candidate;
            StateId = 1; //Set the state to be scheduled when a new object (instance) is first created
        }

    
        public void Activate()
        {
            _state.Activate(this); 
        }   

        public void Close()
        {
            _state.Close(this); 
        }


        partial void ObjectPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "StateId":
                    setState();
                    break; 

            }
        }


        public  void DoSomething()
        {
            _state.DoSomething(); 
        }

        #region State Machine

        private CandidateTestState _state; 
        
        private void setState()
        {
            switch (StateId)
            {
                case 1:
                    _state = new CandidateTestScheduled();
                    break; 
                case 2:
                    _state = new CandidateTestActive();
                    break; 
                case 3:
                    _state = new CandidateTestClosed();
                    break; 
            }
        }

        #endregion



        #region ICandidateTest Members

        IEnumerable<IAnswer> ICandidateTest.Answers
        {
            get { return Answers.AsEnumerable<IAnswer>();  }
        }

        ICandidate ICandidateTest.Candidate
        {
            get { return Candidate; }
        }

        ITestInstance ICandidateTest.TestInstance
        {
            get { return TestInstance; }
        }

        #endregion 
    }
}
