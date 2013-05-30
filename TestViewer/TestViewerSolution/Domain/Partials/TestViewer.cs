using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestViewer : ITestViewer, IDisposable
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

        public void ThrowBusinessRuleViolationForAdministrator(Administrator administrator)
        {
            if (!administrator.Active)
                throw new BusinessRuleException("Unable to access or modify information because the Administrator status is Inactive.");
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

        public List<Candidate> CandidatesThatContains(string studentNumber, bool active)
        {
            return Candidates.Where(s => s.StudentNumber.Contains(studentNumber) && s.Active.Equals(active)).ToList();
        }

        public List<Candidate> FetchCandidates(IEnumerable<Guid> candidateIds)
        {
            var candidates = new List<Candidate>();
            foreach (var candidateId in candidateIds)
            {
                candidates.Add(FetchCandidate(candidateId));
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
            try
            {
               FetchCandidate(studentNumber);
               throw new BusinessRuleException("Candidate already exists");
            }
            catch (RecordNotFoundException)
            {
                var result = new Candidate(studentNumber);
                People.Add(result);
                return result;
            }
        }

        public void ThrowBusinessRuleViolationForCandidate(Candidate candidate)
        {
            if (candidate.HadTakenExam)
                throw new BusinessRuleException("Candidate is already in the Candidate Test. Cannot be modified.");
        }

        public Candidate UpdateCandidate(Guid id, string newStudentNumber)
        {
            var candidate = FetchCandidate(id);
            ThrowBusinessRuleViolationForCandidate(candidate);
            // Candidate exists
            try
            {
                //Check if the new student number already exist in the database
                // If new student number exists, it will throw a RecordNotFoundException
                var result = FetchCandidate(newStudentNumber);
                if (!result.Id.Equals(candidate.Id))
                {
                    throw new BusinessRuleException("Cannot change current candidate student number with '" +
                    newStudentNumber + "' because it is already being used by other candidate.");
                }
            }
            catch (RecordNotFoundException)
            {
                candidate.StudentNumber = newStudentNumber;
            }
            return candidate;
        }

        public Candidate UpdateCandidate(Guid id, string newStudentNumber, bool isActive)
        {
            var candidate = UpdateCandidate(id, newStudentNumber);
            ChangeCandidateStatus(candidate, isActive);

            return candidate;
        }

        public void ChangeCandidateStatus(Guid id)
        {
            var candidate = FetchCandidate(id);
            ChangeCandidateStatus(candidate, !candidate.Active);
        }

        private void ChangeCandidateStatus(Candidate candidate, bool isActive)
        {
            if (candidate.HasPendingExams || candidate.HasInProgressExams)
            {
                throw new BusinessRuleException("Unable to deactivate candidate while it has a pending or in progress exam.");
            }
            candidate.Active = isActive;
        }

        public void DeleteCandidate(Action action, Candidate candidate)
        {
            ThrowBusinessRuleViolationForCandidate(candidate);
            action();
        }


        #endregion

        #region Question Management


        //Gets a list of all questions
        public List<Question> Questions
        {
            get
            { return QuestionBank.Questions.ToList(); }
        }

        public Question FetchQuestion(Guid questionId)
        {
            return QuestionBank.FetchQuestion(questionId);
        }

        public List<Question> FetchQuestionThatContains(string questionTextPart)
        {
            return QuestionBank.FetchQuestionThatContains(questionTextPart);
        }

        public Question CreateQuestion(string text, bool isActive)
        {
            return QuestionBank.CreateQuestion(text, isActive);
        }

        public Question UpdateQuestion(Guid questionId, string text)
        {
            return QuestionBank.UpdateQuestion(questionId, text);
        }

        public Question UpdateQuestionStatus(Guid questionId, bool isActive)
        {
            return QuestionBank.UpdateQuestionStatus(questionId, isActive);
        }

        public void DeleteQuestion(Question question, Action action)
        {
            QuestionBank.DeleteQuestion(question, action);
        }

        public Choice CreateQuestionChoice(Guid questionId, string text, bool isCorrect)
        {
            return QuestionBank.CreateQuestionChoice(questionId, text, isCorrect);
        }

        public Choice UpdateQuestionChoice(Guid questionId, Guid choiceId, string text, bool isCorrect)
        {
            return QuestionBank.UpdateQuestionChoice(questionId, choiceId, text, isCorrect);
        }

        public void DeleteQuestionChoice(Action action, Question question, Choice choice)
        {
            QuestionBank.DeleteQuestionChoice(action, question, choice);
        }

        public List<Question> FetchQuestionsNotInTheTestTemplate(Guid templateId)
        {
            var template = FetchTestTemplate(templateId);
            return QuestionBank.FetchQuestionsNotInTheTestTemplate(template);
        }

        #endregion

        #region Test Template Management


        public TestTemplate  FetchTestTemplate(Guid templateId)
        {
            var result = TestTemplates.FirstOrDefault(t => t.Id.Equals(templateId));
            if (result != null)
                return result;
            throw new RecordNotFoundException("Test Template with ID '" + templateId + "' does not exist");
        }


        public List<TestTemplate> FetchTestTemplateThatContains(string name)
        {
            return TestTemplates.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
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
                return FetchTestTemplate(name);
                throw new BusinessRuleException("Test Template name already exists");
            }
            catch (RecordNotFoundException)
            {
                var template = new TestTemplate(name);
                TestTemplates.Add(template);
                return template;
            }
        }

        public TestTemplate UpdateTestTemplate(Guid templateId, string newName)
        {
            var template = FetchTestTemplate(templateId);

            if (template.IsUsedInAScheduledTestInstance)
                throw new BusinessRuleException("Unable to update Test Template because it is being used in a Test Instance");

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
            if (template.IsBeingUsedInTestInstance)
                throw new BusinessRuleException("Unable to update Test Template because it is being used in a Test Instance");
            action();
        }

        public void AddOrRemoveTemplateQuestion(Guid templateId, Guid questionId, AddOrRemoveStatus action)
        {
            var template = FetchTestTemplate(templateId);

            if (template.IsBeingUsedInTestInstance)
                throw new BusinessRuleException("Unable to update Test Template because it is being used in a Test Instance");

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
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            return administrator.TestInstances.ToList();
        }

        public TestInstance FetchTestInstanceFromAdministrator(Guid administratorId, Guid instanceId)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            return administrator.FetchTestInstance(instanceId);
        }

        public TestInstance FetchTestInstanceFromTestTemplate(Guid templateId, Guid instanceId)
        {
            return FetchTestTemplate(templateId).FetchTestInstance(instanceId);
        }

        public TestInstance CreateTestInstance(IEnumerable<Guid> candidateIds, Guid administratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            var candidates = FetchCandidates(candidateIds);
            foreach (var candidate in candidates)
            {
                if (!candidate.Active)
                    throw new BusinessRuleException("Candidate cannot be added to the Test Instance because the status is not active");
            }
            return FetchTestTemplate(templateId).CreateTestInstance(candidates, administrator, isPractice, timeLimit);
        }

        public TestInstance UpdateTestInstance(Guid administratorId, Guid instanceId, Guid templateId, bool isPractice, int timeLimit)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            var testTemplate = FetchTestTemplate(templateId);
            return administrator.UpdateTestInstance(instanceId, testTemplate, isPractice, timeLimit);     
        }

        public void DeleteTestInstance(Action action, Guid administratorId, TestInstance testInstance)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            administrator.DeleteTestInstance(action, testInstance);
        }

        public TestInstance AddCandidateToTestInstance(Guid currentTemplateId, Guid instanceId, Guid candidateId)
        {
            var result = FetchTestInstanceFromTestTemplate(currentTemplateId, instanceId);
            result.CreateCandidateTest(FetchCandidate(candidateId));

            return result;
        }

        public void DeleteCandidateTest(Action action, Guid templateId, Guid instanceId, CandidateTest candidateTest)
        {
            FetchTestTemplate(templateId).DeleteCandidateTest(action, instanceId, candidateTest);
        }

        public void OpenTestInstance(Guid instanceId, Guid administratorId)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            administrator.OpenTestInstance(instanceId);
        }

        public void CloseTestInstance(Guid instanceId, Guid administratorId)
        {
            var administrator = FetchAdministrator(administratorId);
            ThrowBusinessRuleViolationForAdministrator(administrator);

            administrator.CloseTestInstance(instanceId);
        }

        #endregion

        #region Candidate Test Management

        public CandidateTest FetchCandidateTest(Guid templateId, Guid instanceId, Guid candidateId)
        {
            return FetchTestTemplate(templateId).FetchCandidateTest(instanceId, candidateId);
        }

        public CandidateTest CreateCandidateTest(Guid templateId, Guid instanceId, Guid candidateId)
        {
            var candidate = FetchCandidate(candidateId);
            if (candidate.Active)
            {
                return FetchTestTemplate(templateId).CreateCandidateTest(instanceId, candidate);
            }
            throw new BusinessRuleException("Candidate cannot be added to the Test Instance because the status is not active");
        }

        #endregion

        #region Exam Management

        public CandidateTest GetExam(string studentNo, int tokenId)
        {
            try
            {
                var candidate = FetchCandidate(studentNo);
                return candidate.GetExamByTokenId(tokenId);
            }
            catch (RecordNotFoundException)
            {
                return null;
            }
        }

        public void BeginExam(Guid candidateId, Guid candidateTestId)
        {
            FetchCandidate(candidateId).BeginExam(candidateTestId);
        }

        public void SaveAnswer(Guid candidateId, Guid candidateTestId, Guid choiceId)
        {
            FetchCandidate(candidateId).SaveAnswer(candidateTestId, choiceId);
        }

        public void FinishExam(Guid candidateId, Guid candidateTestId)
        {
            FetchCandidate(candidateId).FinishExam(candidateTestId);
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


        public void Dispose()
        {
            People.Clear();
            TestTemplates.Clear();
            QuestionBank.Dispose();
        }
    }
}
