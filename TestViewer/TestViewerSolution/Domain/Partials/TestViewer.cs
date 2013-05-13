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
            var result = Administrators.FirstOrDefault(a => a.Id.Equals(id));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Administrator with ID '" + id + "' does not exist");
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

        public List<Candidate> CandidatesStartsWith(string studentNumber)
        {
            return Candidates.Where(s => s.StudentNumber.StartsWith(studentNumber)).ToList();
        }

        public List<Candidate> FetchCandidates(IEnumerable<Guid> candidateIds)
        {
            var candidates = new List<Candidate>();
            foreach (var candidateId in candidateIds)
            {
                var result = FetchCandidate(candidateId);
                candidates.Add(result);
            }
            return candidates;
        }

        public List<Candidate> FetchCandidates(bool onlyActive)
        {
            return Candidates.Where(a => a.Active.Equals(onlyActive)).ToList(); 
        }

        public Candidate FetchCandidate(string studentNumber)
        {
            var result = Candidates.FirstOrDefault(c => c.StudentNumber.Equals(studentNumber));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Candidate with student number '" + studentNumber + "' does not exist");
        }

        public Candidate FetchCandidate(Guid id)
        {
            var result = Candidates.FirstOrDefault(c => c.Id.Equals(id));       
            if (result != null)
                return result;

            throw new RecordNotFoundException("Candidate with ID '" + id + "' does not exist"); 
        }

        public Candidate CreateCandidate(string studentNumber)
        {
            Candidate candidate;
            try
            {
                FetchCandidate(studentNumber);
                throw new RecordAlreadyExistsException("Student number already exists.");
            }
            catch (RecordNotFoundException)
            {
                candidate = new Candidate(studentNumber);
                People.Add(candidate);
            }
            return candidate;
        }

        public void CanCandidateBeModified(Candidate candidate)
        {
            if (candidate.CandidateTests.Count <= 0)
                throw new BusinessRuleException("Candidate has already been taken an exam. Cannot be modified.");
        }

        // update candidates number
        public Candidate UpdateCandidate(Guid id, string newStudentNumber)
        {
            var candidate = FetchCandidate(id);
            CanCandidateBeModified(candidate);
            // Candidate exists
            try
            {
                //Check if the new student number already exist in the database
                // If new student number exists, it will throw a RecordNotFoundException
                var result = FetchCandidate(newStudentNumber);
                if (!result.Id.Equals(candidate.Id))
                {
                    throw new RecordAlreadyExistsException("Cannot change current candidate student number with '" +
                    newStudentNumber + "' because it is already being used by someone.");
                }
            }
            catch (RecordNotFoundException)
            {
                // Update with the new student number
                candidate.StudentNumber = newStudentNumber;
            }
            return candidate;
        }

        // update candidates student number and statues
        public Candidate UpdateCandidate(Guid id, string newStudentNumber, bool active)
        {
            var candidate = UpdateCandidate(id, newStudentNumber);
            candidate.Active = active;

            return candidate;
        }

        // update Candidates status (true/false)
        public Candidate UpdateCandidate(Guid id, bool active)
        {
            var candidate = FetchCandidate(id);
            CanCandidateBeModified(candidate);
            // Candidate exists
            candidate.Active = active;
            return candidate;
        }

        public void DeleteCandidate(Action action, Candidate candidate)
        {
            //TODO: (DONE) Put Check for Test Instance before deleting Candidate 
            CanCandidateBeModified(candidate);
            action();
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
            var result = TestTemplates.FirstOrDefault(t => t.Id.Equals(templateId));
            if (result != null)
                return result;
            throw new RecordNotFoundException("Test Template with ID '" + templateId + "' does not exist");
        }


        public TestTemplate FetchTestTemplate(string name)
        {
            var result = TestTemplates.FirstOrDefault(t => t.Name.Equals(name));
            if (result != null)
                return result;
            throw new RecordNotFoundException("Test Template with name '" + name + "', does not exist");
        }


        public TestTemplate CreateTestTemplate(string name)
        {
            try
            {
                FetchTestTemplate(name);
                throw new RecordAlreadyExistsException("Test Template with a name '" + name + "' already exists");
            }
            catch (RecordNotFoundException)
            {
                TestTemplate template = new TestTemplate(name);
                TestTemplates.Add(template);
                return template;
            }
        }

        public void CanTemplateBeModified(TestTemplate template)
        {
            //This method won't return FALSE result. only TRUE and BusinessRuleException
            // checks if theres any test instance 
            if (template.TestInstances.Count > 0)
                throw new BusinessRuleException("Test Template has been used in the Test Instance. Cannot add or remove questions, and delete this template.");
        }

        public TestTemplate UpdateTestTemplate(Guid templateId, string newName)
        {
            var template = FetchTestTemplate(templateId);
            try
            {
                FetchTestTemplate(newName);
            }
            catch (RecordNotFoundException)
            {
                template.Name = newName;
            }
            return template;
        }

        public void DeleteTestTemplate(Action action, TestTemplate template)
        {
            CanTemplateBeModified(template);
            action();
        }

        public void AddOrRemoveTemplateQuestion(Guid templateId, Guid questionId, AddOrRemoveStatus action)
        {
            var template = FetchTestTemplate(templateId);
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


        public List<TestInstance> FetchTestInstancesFromAdministrator(Guid administratorId)
        {
            return FetchAdministrator(administratorId).TestInstances.ToList();
        }

        public TestInstance FetchTestInstanceFromAdministrator(Guid administratorId, Guid instanceId)
        {
            return FetchAdministrator(administratorId).FetchTestInstance(instanceId);
        }

        public TestInstance FetchTestInstanceFromTestTemplate(Guid templateId, Guid instanceId)
        {
            return FetchTestTemplate(templateId).FetchTestInstance(instanceId);
        }

        public TestInstance CreateTestInstance(IEnumerable<Guid> candidateIds, Guid administratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            return FetchTestTemplate(templateId).CreateTestInstance(FetchCandidates(candidateIds), administratorId, isPractice, timeLimit);
        }

        public TestInstance UpdateTestInstance(Guid currentTemplateId, Guid instanceId, Guid newTemplateId, bool isPractice, int timeLimit)
        {
            var newTestTemplate = FetchTestTemplate(newTemplateId);
            return FetchTestTemplate(currentTemplateId).UpdateTestInstance(instanceId, newTestTemplate, isPractice, timeLimit);
        }

        public TestInstance AddCandidateToTestInstance(Guid currentTemplateId, Guid instanceId, Guid candidateId)
        {
            var result = FetchTestInstanceFromTestTemplate(currentTemplateId, instanceId);
            result.CreateCandidateTest(FetchCandidate(candidateId));

            return result;
        }

        public void DeleteCandidateTest(Action action, Guid templateId, Guid instanceId, CandidateTest candidateTest)
        {
            var testInstance = FetchTestInstanceFromTestTemplate(templateId, instanceId);
            testInstance.DeleteCandidateTest(action, candidateTest);
        }

        #endregion

        #region Candidate Test Management

        public CandidateTest FetchCandidateTest(Guid templateId, Guid instanceId, Guid candidateId)
        {
            return FetchTestInstanceFromTestTemplate(templateId, instanceId).FetchCandidateTest(candidateId);
        }

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
