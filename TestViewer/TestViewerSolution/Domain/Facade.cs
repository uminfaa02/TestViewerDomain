using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class Facade : IDisposable
    {

        private TestViewerEntities _context = new TestViewerEntities();


        private TestViewer TestViewer
        {
            get
            {
                return _context.TestViewers
                    .Include("People")
                    .Include("QuestionBank")
                    .Include("QuestionBank.Questions")
                    .Include("QuestionBank.Questions.Choices")
                    .Include("TestTemplates")
                    .Include("TestTemplates.Questions")
                    .Include("TestTemplates.TestInstances")
                    .First();
            }
        }


        #region Administrator Management

        /// <summary>
        /// Returns an administrator by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Administrator</returns>
        public IAdministrator FetchAdministrator(Guid id)
        {
            return TestViewer.FetchAdministrator(id);
        }

        #endregion

        #region Candidate Management

        /// <summary>
        /// Returns a list of candidates
        /// </summary>
        public IEnumerable<ICandidate> Candidates
        {
            get { return TestViewer.Candidates; }
        }

        /// <summary>
        /// Returns a list of all the candidates that start with the specified number.
        /// </summary>
        /// <param name="studentNumber"></param>
        /// <returns>IEnumerable&lt;ICandidate&gt;</returns>
        public IEnumerable<ICandidate> CandidatesStartsWith(string studentNumber)
        {
            return TestViewer.CandidatesStartsWith(studentNumber);
        }


        /// <summary>
        /// Returns a list of active or inactive candidates
        /// </summary>
        public IEnumerable<ICandidate> FetchCandidates(bool onlyActive)
        {
            return TestViewer.FetchCandidates(onlyActive);
        }

        /// <summary>
        /// Retrieves the student with a matching Student number
        /// </summary>
        /// <param name="studentNumber">Student Number</param>
        /// <returns>ICandidate</returns>
        /// <exception cref="RecordNotFoundException">If no record found.</exception>
        public ICandidate FetchCandidate(string studentNumber)
        {
            return TestViewer.FetchCandidate(studentNumber);
        }

        /// <summary>
        /// Retrieves the student using the Candidate ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Candidate</returns>
        public ICandidate FetchCandidate(Guid id)
        {
            return TestViewer.FetchCandidate(id);
        }

        /// <summary>
        /// Creates and returns candidate information. Throws BusinessRuleException if candidate does not exist"
        /// </summary>
        /// <param name="studentNumber"></param>
        /// <exception cref="Domain.BusinessRuleException"></exception>
        /// <returns>ICandidate</returns>
        public ICandidate CreateCandidate(string studentNumber)
        { 
            var result = TestViewer.CreateCandidate(studentNumber);

            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates the candidate student number and statues
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStudentNumber"></param>
        /// <param name="active"></param>
        /// <returns>ICandidate</returns>
        public ICandidate UpdateCandidate(Guid id, string newStudentNumber, bool active)
        {
            var candidate = TestViewer.UpdateCandidate(id, newStudentNumber, active);
            _context.SaveChanges();
            return candidate;
        }

        /// <summary>
        /// Updates the candidate student number. Returns a BusinessRuleException if newStudentNumber exists.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStudentNumber"></param>
        /// <returns>ICandidate</returns>
        public ICandidate UpdateCandidate(Guid id, string newStudentNumber)
        {
            var candidate = TestViewer.UpdateCandidate(id, newStudentNumber);
            _context.SaveChanges();
            return candidate;
        }

        /// <summary>
        /// Updates Candidates statues (True/False)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="active"></param>
        /// <returns>ICandidate</returns>
        public ICandidate UpdateCandidate(Guid id, bool active)
        {
            var candidate = TestViewer.UpdateCandidate(id, active);
            _context.SaveChanges();
            return candidate;
        }

        /// <summary>
        /// Deletes the candidate from the database using the id.
        /// </summary>
        /// <param name="candidateId"></param>
        public void DeleteCandidate(Guid candidateId)
        {
            var candidate = TestViewer.FetchCandidate(candidateId);
            Action action = delegate() { deleteCandidate(candidate); };

            TestViewer.DeleteCandidate(action, candidate);

             _context.SaveChanges();
            
        }

        private void deleteCandidate(Candidate candidate)
        {
            _context.People.Remove(candidate);
        }

        //TODO: Create a CanBeModified method for Candidate


        #endregion // done

        #region Question Mangement


        /// <summary>
        /// Returns a list of questions
        /// </summary>
        public IEnumerable<IQuestion> Questions
        {
            get { return TestViewer.Questions; }
        }

        /// <summary>
        /// Returns the question associated with the questionId
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns>IQuestion</returns>
        public IQuestion FetchQuestion(Guid questionId)
        {
            return TestViewer.FetchQuestion(questionId);
        }

        /// <summary>
        /// Adds a new question to the Question Bank, throws Exception
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isActive"></param>
        /// <returns>IQuestion</returns>
        public IQuestion CreateQuestion(string text, bool isActive=true)
        {
            var result = TestViewer.CreateQuestion(text, isActive);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates the question to the Question Bank
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="text"></param>
        /// <param name="isActive"></param>
        /// <param name="ignoreValidation"></param>
        /// <exception cref="BusinessRuleException"></exception>
        /// <returns>IQuestion</returns>
        public IQuestion UpdateQuestion(Guid questionId, string text, bool isActive, bool ignoreValidation = false)
        {
            var result = TestViewer.UpdateQuestion(questionId, text, isActive, ignoreValidation);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Deletes the question from the Question Bank and all its choices.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns>void</returns>
        public void DeleteQuestion(Guid questionId)
        {
            var question = TestViewer.FetchQuestion(questionId);

            Action action = delegate() { deleteQuestion(question); };
            TestViewer.DeleteQuestion(action, question);

            _context.SaveChanges();
        }

        private void deleteQuestion(Question question)
        {
           
            //delete all choices associated with the question
            List<Choice> choices = question.Choices.ToList();
            foreach (Choice choice in choices)
            {
                deleteQuestionChoice(choice);
            }
            //delete question
            _context.Questions.Remove(question);
        }

        #endregion

        #region Choice Management

        /// <summary>
        /// Adds a new question choice
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="text"></param>
        /// <param name="isCorrect"></param>
        /// <returns>IChoice</returns>
        public IChoice CreateQuestionChoice(Guid questionId, string text, bool isCorrect)
        {
            var result = TestViewer.CreateQuestionChoice(questionId, text, isCorrect);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates a question choice
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="choiceId"></param>
        /// <param name="text"></param>
        /// <param name="isCorrect"></param>
        /// <returns>IChoice</returns>
        public IChoice UpdateQuestionChoice(Guid questionId, Guid choiceId, string text, bool isCorrect)
        {
            var result = TestViewer.UpdateQuestionChoice(questionId, choiceId, text, isCorrect);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Removes a question choice
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="choiceId"></param>
        /// <returns>bool</returns>
        public void DeleteQuestionChoice(Guid questionId, Guid choiceId)
        {
            //fetch the choice for that question
            var choice = TestViewer.FetchQuestion(questionId).FetchChoice(choiceId);

            Action action = delegate() { deleteQuestionChoice(choice); };

            TestViewer.DeleteQuestionChoice(action, choice);

            _context.SaveChanges();
        }

        private void deleteQuestionChoice(Choice choice)
        {
            _context.Choices.Remove(choice);
        }

        #endregion

        #region Test Template Management

        /// <summary>
        /// Returns all test templates.
        /// </summary>
        public IEnumerable<ITestTemplate> TestTemplates
        {
            get
            {
                return TestViewer.TestTemplates;
            }
        }
        /// <summary>
        /// Fetch's a specific test template according to its Guid Template ID
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>ITestTemplate</returns>
        public ITestTemplate FetchTestTemplate(Guid templateId)
        {
            return TestViewer.FetchTestTemplate(templateId);
        }

        /// <summary>
        /// Creates a Test Template
        /// </summary>
        /// <param name="name"></param>
        /// <returns>ITestTemplate</returns>
        public ITestTemplate CreateTestTemplate(string name)
        {
            var template = TestViewer.CreateTestTemplate(name);
            _context.SaveChanges();
            return template;
        }

        /// <summary>
        /// Updates Test Template name
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="name"></param>
        /// <returns>ITestTemplate</returns>
        public ITestTemplate UpdateTestTemplate(Guid templateId, string name)
        {
            var template = TestViewer.UpdateTestTemplate(templateId, name);
            _context.SaveChanges();
            return template;
        }

        /// <summary>
        /// Deletes Test Template, throws exception if its assocciated with a test instance or has questions.
        /// </summary>
        /// <param name="templateId"></param>
        public void DeleteTestTemplate(Guid templateId)
        {
            var template = TestViewer.FetchTestTemplate(templateId);

            Action action = delegate() { deleteTestTemplate(template); };

            TestViewer.DeleteTestTemplate(action, template);

           _context.SaveChanges();           
        }

        private void deleteTestTemplate(TestTemplate template)
        {
            _context.TestTemplates.Remove(template);
        }

        /// <summary>
        /// add or remove question into the test template
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="questionId"></param>
        /// <param name="action"></param>
        public void AddOrRemoveTemplateQuestion(Guid templateId, Guid questionId, AddOrRemoveStatus action)
        {
            TestViewer.AddOrRemoveTemplateQuestion(templateId, questionId, action);
            _context.SaveChanges();
        }

        #endregion

        #region Test Instance Management

     
        public IEnumerable<ITestInstance> FetchTestInstances(Guid administratorId)
        {
            return TestViewer.FetchTestInstancesFromAdministrator(administratorId);
        }

        public ITestInstance FetchTestInstance(Guid administratorId, Guid instanceId)
        {
            return TestViewer.FetchTestInstanceFromAdministrator(administratorId, instanceId);
        }

        public ITestInstance CreateTestInstance(IEnumerable<Guid> candidateIds, Guid administratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            var result = TestViewer.CreateTestInstance(candidateIds, administratorId, templateId, isPractice, timeLimit);
            _context.SaveChanges();
            return result;
        }

        public ITestInstance UpdateTestInstance(Guid adminitratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            var result = TestViewer.UpdateTestInstance(adminitratorId, templateId, isPractice, timeLimit);

            _context.SaveChanges();
            return result;
            

        }

        #endregion

        #region Candidate Test Management
        
        //public ICandidateTest CreateActualTest(string studentId, Guid templateId, Guid instanceId)
        //{
        //    return TestViewer.CreateActualTest(studentId, templateId, instanceId);
        //}

        #endregion


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
