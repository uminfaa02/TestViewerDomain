using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestViewer : ITestViewer
    {

        #region Administrator Management

        public List<Administrator> Administrators
        {
            get { return People.OfType<Administrator>().ToList(); }
        }

        public Administrator FetchAdministrator(Guid id)
        {
            return Administrators.FirstOrDefault(a => a.Id.Equals(id));
        }

        #endregion

        #region Candidate Management

        // Gets a List of all Candidates
        public List<Candidate> Candidates
        {
            get
            {
                return People.OfType<Candidate>().ToList();
            }
        }

        public IEnumerable<ICandidate> CandidatesStartsWith(string studentNumber)
        {

            return Candidates.Where(s => s.StudentNumber.StartsWith(studentNumber)).AsEnumerable<ICandidate>();

        }

        public Candidate FetchCandidate(string studentNumber)
        { 
            return Candidates.FirstOrDefault(c => c.StudentNumber.Equals(studentNumber));
        }

        public Candidate FetchCandidate(Guid id)
        {
           return Candidates.FirstOrDefault(c => c.Id.Equals(id));        
        }

        public Candidate CreateCandidate(string studentNumber)
        {
            //first we will attempt to find an existing candidate with a matching student number
            var candidate = FetchCandidate(studentNumber);
            //If a candidate with a matching number is found simply return the result
            if (candidate != null)
            {
                throw new BusinessRuleException("Student number already exists.");
            }
            candidate = new Candidate {StudentNumber = studentNumber};
            People.Add(candidate);
            return candidate;
        }
        
        // update candidates number
        public Candidate UpdateCandidate(Guid id, string newStudentNumber)
        {

            var candidate = FetchCandidate(id);
            // Candidate exists
            if (candidate != null) 
            {
                var result = FetchCandidate(newStudentNumber);
                // New student number does not exists.
                if (result == null)
                {
                    // Update to the new student number
                    candidate.StudentNumber = newStudentNumber;
                }
                else if (candidate.Id != result.Id)
                    throw new BusinessRuleException("New student number already exists.");

                return candidate;
            }
            throw new BusinessRuleException("Student number does not exists.");
        }

        // update candidates student number and statues
        public Candidate UpdateCandidate(Guid id, string newStudentNumber, bool active)
        {
            var candidate =  UpdateCandidate(id, newStudentNumber);
            candidate.Active = active;

            return candidate;
        }
        // update Candidates statues (true/false)
        public Candidate UpdateCandidate(Guid id, bool active)
        {
            var candidate = FetchCandidate(id);
            // Candidate exists
            if (candidate != null)
            {
                    candidate.Active = active;
                    return candidate;
                }
            throw new BusinessRuleException("Student number does not exists.");
        }

        public void DeleteCandidate(Action action, Candidate candidate)
        {
            //TODO: Put Check for Test Instance before deleting Candidate 
            if (candidate != null)
            {
                action();
            }
            else
            {
                throw new BusinessRuleException("Candidate Id Not found");
            }


        }



        #endregion

        #region Question Management


        //Gets a list of all questions
        public List<Question> Questions
        {
            get
            {
                return QuestionBank.Questions.ToList();
            }
        }

        public Question FetchQuestion(Guid questionId)
        {
            return QuestionBank.FetchQuestion(questionId);
        }

        public Question CreateQuestion(string text, bool isActive)
        {
            return QuestionBank.CreateQuestion(text, isActive); 
        }

        public void CanQuestionBeModified(Question question)
        {
            QuestionBank.CanQuestionBeModified(question);
        }


        public Question UpdateQuestion(Guid questionId, string text, bool isActive, bool ignoreValidation)
        {
            return QuestionBank.UpdateQuestion(questionId, text, isActive, ignoreValidation);
        }

        public void DeleteQuestion(Action action, Question question)
        {
           QuestionBank.DeleteQuestion(action, question);
        }


        public Choice CreateQuestionChoice(Guid questionId, string text, bool isCorrect)
        {
            return FetchQuestion(questionId).CreateChoice(text, isCorrect);
        }

        public Choice UpdateQuestionChoice(Guid questionId, Guid choiceId, string text, bool isCorrect)
        {
            return FetchQuestion(questionId).UpdateChoice(choiceId, text, isCorrect);
        }

        public void DeleteQuestionChoice(Action action, Choice choice)
        {
            QuestionBank.DeleteQuestionChoice(action, choice);
        }

        #endregion

        #region Test Template Management


        public TestTemplate FetchTestTemplate(Guid templateId)
        {
            return TestTemplates.FirstOrDefault(t => t.Id.Equals(templateId));
        }


        public TestTemplate FetchTestTemplate(string name)
        {
            return TestTemplates.FirstOrDefault(t => t.Name.Equals(name));
        }


        public TestTemplate CreateTestTemplate(string name)
        {
            var result = FetchTestTemplate(name);
            if (result != null)
                throw new BusinessRuleException("Test Template already exists.");

            TestTemplate template = new TestTemplate { Name = name };
            TestTemplates.Add(template);
            return template;
        }

        public void CanTemplateBeModified(TestTemplate template)
        {
            //This method won't return FALSE result. only TRUE and BusinessRuleException
            // checks if theres any test instance 
            if (template.TestInstances.Count > 0)
                throw new BusinessRuleException("Test Template has been used in the Test Instance. Cannot add or remove questions, and delete this template.");
        }

        public TestTemplate UpdateTestTemplate(Guid templateId, string name)
        {
            TestTemplate template = FetchTestTemplate(templateId);
            if (template == null)
            {
                throw new BusinessRuleException("Could not find the Test Template using the Template ID " +
                                                templateId);
            }
            template.Name = name;
            return template;
        }

        public void DeleteTestTemplate(Action action, TestTemplate template)
        {

            if (template == null)
                    throw new BusinessRuleException("Test Template does not exists");

            CanTemplateBeModified(template);
            action();
                
            
        }

        //public void AddTemplateQuestion(Guid templateId, Guid questionId)
        //{
        //    TestTemplate template = FetchTestTemplate(templateId);
        //    if (template == null)
        //        throw new BusinessRuleException("Test Template does not exists");

        //    CanTemplateBeModified(template);
        //    QuestionBank.AddTemplateQuestion(template, questionId);
        //}

        //public void RemoveTemplateQuestion(Guid templateId, Guid questionId)
        //{
        //    TestTemplate template = FetchTestTemplate(templateId);
        //    if (template == null)
        //        throw new BusinessRuleException("Test Template does not exists");

        //    CanTemplateBeModified(template);
        //    QuestionBank.RemoveTemplateQuestion(template, questionId);
        //}

        public void AddOrRemoveTemplateQuestion(Guid templateId, Guid questionId, AddOrRemoveStatus action)
        {
            var template = FetchTestTemplate(templateId);
            if (template == null)
                throw new BusinessRuleException("Test Template does not exists");

            CanTemplateBeModified(template);

            if (action == AddOrRemoveStatus.Add)
            {
                QuestionBank.AddTemplateQuestion(template, questionId);
            }
            else if (action == AddOrRemoveStatus.Remove)
            {
                QuestionBank.RemoveTemplateQuestion(template, questionId);
            }
           
        }

        #endregion

        #region Test Instance Management

        public List<TestInstance> FetchTestInstances(Guid administratorId)
        {
            return FetchAdministrator(administratorId).TestInstances.ToList();
        }

        // Gets all Test Instance for that Administrator
        public TestInstance FetchTestInstance(Guid administratorId, Guid templateId, Guid instanceId)
        {
            return FetchAdministrator(administratorId).TestInstances.Where(i => i.Id.Equals(instanceId)).First();
        }

        //Gets a Specific Test Instance 
        public TestInstance FetchTestInstance(Guid templateId, Guid instanceId)
        {
            return FetchTestTemplate(templateId).FetchTestInstance(instanceId);
        }

        //Creates a Test Instance 
        public TestInstance CreateTestInstance(IEnumerable<ICandidate> candidates, Guid administratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            return FetchTestTemplate(templateId).CreateTestInstance(candidates, administratorId, isPractice, timeLimit);
        }

        public TestInstance UpdateTestInstance(Guid templateId, Guid testInstanceId, bool isPractice, int timeLimit)
        {
            var testInstance = FetchTestTemplate(templateId).FetchTestInstance(testInstanceId);
            testInstance.IsPractice = isPractice;
            testInstance.TimeLimit = timeLimit;
            

            return testInstance;
        }

        #endregion

        #region Candidate Test Management

        #endregion

        #region ITestViewer Members

        IEnumerable<ICandidate> ITestViewer.Candidates
        {
            get { return Candidates.AsEnumerable<ICandidate>();  }
        }

        IEnumerable<IPerson> ITestViewer.People
        {
            get { return People.AsEnumerable<IPerson>(); }
        }

        IQuestionBank ITestViewer.QuestionBank
        {
            get { return QuestionBank; }
        }

        IEnumerable<IQuestion> ITestViewer.Questions
        {
            get { return Questions.AsEnumerable<IQuestion>(); }
        }

        IEnumerable<ITestTemplate> ITestViewer.TestTemplates
        {
            get { return TestTemplates.AsEnumerable<ITestTemplate>();  }
        }

        #endregion

    }
}
