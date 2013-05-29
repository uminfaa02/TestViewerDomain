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

        public int TokenId
        {
            get { return TestInstance.TokenId; }
        }

        public List<Question> Questions
        {
            get { return TestInstance.TestTemplate.Questions.ToList(); }
        }

        public int correctAnswers
        {
            get { return Answers.Where(a => a.Choice.IsCorrect).Count(); }
        }

        public int inCorrectAnswers
        {
            get { return Answers.Where(a => !a.Choice.IsCorrect).Count(); }
        }

        public int TimeLimit
        {
            get { return TestInstance.TimeLimit; }
        }


        public void SaveAnswer(Guid choiceId)
        {
            Answer answer = new Answer(choiceId);
            Answers.Add(answer);
        }

        public void Activate()
        {
            _state.Activate(this); 
        }

        public void Start()
        {
            _state.Start(this);
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


        //public  void DoSomething()
        //{
        //    _state.DoSomething(); 
        //}


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
                    _state = new CandidateTestStart();
                    break; 
                case 4:
                    _state = new CandidateTestClosed();
                    break;
            }
        }

        #endregion



        #region ICandidateTest Members

        ICandidate ICandidateTest.Candidate
        {
            get { return Candidate; }
        }

        ITestInstance ICandidateTest.TestInstance
        {
            get { return TestInstance; }
        }

        IEnumerable<IQuestion> ICandidateTest.Questions
        {
            get { return TestInstance.TestTemplate.Questions.AsEnumerable<IQuestion>(); }
        }

        #endregion 
    

    }
}
