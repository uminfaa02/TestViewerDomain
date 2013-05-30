using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Domain 
{
    /// <summary>
    /// This class is the main interface of the TestViewer
    /// </summary>
    public class Facade : IDisposable
    {
        private MailingSystem _mail;
        private TestViewerEntities _context = new TestViewerEntities();


        public Facade()
        {
            _mail = new MailingSystem(new MailAddress(TestViewer.Email, "TestViewer"), TestViewer.EmailPassword);
        }

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
                    .Include("TestTemplates.TestInstances.CandidateTests")
                    .First();
            }
        }


        #region Administrator Management

        /// <summary>
        /// Returns an administrator by Id.
        /// </summary>
        /// <param name="id">Administrator ID</param>
        /// <returns>Administrator</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Administrator is not found</exception>
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
        /// Returns a collection of all the candidates that starts with the specified number.
        /// </summary>
        /// <param name="studentNumberPart">Student number part that is contained in the whole student number</param>
        /// <param name="active">Candidate Status (True or False)</param>
        /// <returns>IEnumerable&lt;ICandidate&gt;</returns>
        public IEnumerable<ICandidate> CandidatesThatContains(string studentNumberPart, bool active = true)
        {
            return TestViewer.CandidatesThatContains(studentNumberPart, active);
        }

        /// <summary>
        /// Fetches a collection of active or inactive candidates
        /// </summary>
        /// <param name="onlyActive">Candidate Status</param>
        /// <returns>IEnumerable&lt;ICandidate&gt;</returns>
        public IEnumerable<ICandidate> FetchCandidates(bool onlyActive = true)
        {
            return TestViewer.FetchCandidates(onlyActive);
        }

        /// <summary>
        /// Retrieves the student with a matching Student number
        /// </summary>
        /// <param name="studentNumber">Student Number</param>
        /// <returns>ICandidate</returns>
        /// <exception cref="Domain.RecordNotFoundException">If no record found.</exception>
        public ICandidate FetchCandidate(string studentNumber)
        {
            return TestViewer.FetchCandidate(studentNumber);
        }

        /// <summary>
        /// Retrieves the student using the Candidate ID
        /// </summary>
        /// <param name="id">Candidate ID</param>
        /// <returns>ICandidate</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Candidate is not found</exception>
        public ICandidate FetchCandidate(Guid id)
        {
            return TestViewer.FetchCandidate(id);
        }

        /// <summary>
        /// Creates candidate information. Returns the candidate record if student number already exists.
        /// </summary>
        /// <param name="studentNumber">Student Number</param>
        /// <returns>ICandidate</returns>
        /// <exception cref="Domain.BusinessRuleException">When student number is not valid</exception>
        public ICandidate CreateCandidate(string studentNumber)
        { 
            var result = TestViewer.CreateCandidate(studentNumber);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates the candidate student number and status
        /// </summary>
        /// <param name="id">Candidate ID</param>
        /// <param name="newStudentNumber">Candidate New Student Number</param>
        /// <param name="active">Candidate Status</param>
        /// <returns>ICandidate</returns>
        /// <exception cref="Domain.BusinessRuleException">When Candidate cannot be updated due to some reason</exception>
        /// <exception cref="Domain.RecordNotFoundException">When the Candidate that is going to be updated is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When New Student Number is already being used by some Candidates</exception>
        public ICandidate UpdateCandidate(Guid id, string newStudentNumber, bool active)
        {
            var candidate = TestViewer.UpdateCandidate(id, newStudentNumber, active);
            _context.SaveChanges();
            return candidate;
        }

        /// <summary>
        /// Change Candidate's status into its opposite status
        /// </summary>
        /// <param name="candidateId">Candidate ID</param>
        /// <returns>IQUestion</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Candidate ID is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Candidate cannot be updated due to some reason</exception>
        public void ChangeCandidateStatus(Guid candidateId)
        {
            TestViewer.ChangeCandidateStatus(candidateId);
            _context.SaveChanges();
        }

        /// <summary>
        /// Change Candidate's status into its opposite status
        /// </summary>
        /// <param name="candidateIds">Collection of Candidate ID</param>
        /// <returns>IQUestion</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Candidate ID is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Candidate cannot be updated due to some reason</exception>
        public void ChangeCandidateStatus(List<Guid> candidateIds)
        {
            foreach (var candidateId in candidateIds)
            {
                TestViewer.ChangeCandidateStatus(candidateId);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the Candidate associated with the Candidate ID
        /// </summary>
        /// <param name="candidateId">Candidate ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When Candidate is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Candidate cannot be deleted due to some reason</exception>
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


        #endregion

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
        /// <param name="questionId">Question ID</param>
        /// <returns>IQuestion</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Question is not found</exception>
        public IQuestion FetchQuestion(Guid questionId)
        {
            return TestViewer.FetchQuestion(questionId);
        }

        /// <summary>
        /// Returns a list of Questions that contains the provided text in the question text.
        /// </summary>
        /// <param name="questionTextPart">Word or Part contained in the Question text</param>
        /// <returns>IEnumerable&lt;IQuestion&gt;</returns>
        public IEnumerable<IQuestion> FetchQuestionThatContains(string questionTextPart)
        {
            return TestViewer.FetchQuestionThatContains(questionTextPart);
        }

        /// <summary>
        /// Fetches a collection of questions that are not associated with the Test Template
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>IEnumerable&lt;IQuestion&gt;</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test template is not found</exception>
        public IEnumerable<IQuestion> FetchQuestionsNotInTheTestTemplate(Guid templateId)
        {
            return TestViewer.FetchQuestionsNotInTheTestTemplate(templateId);
        }

        /// <summary>
        /// Adds a new question to the Question Bank. Returns the question if Question text already exists in the Question Bank
        /// </summary>
        /// <param name="text">Question Text</param>
        /// <param name="isActive">Question status</param>
        /// <returns>IQuestion</returns>
        /// <exception cref="Domain.BusinessRuleException">When Question is empty or white space.</exception>
        public IQuestion CreateQuestion(string text, bool isActive=true)
        {
            var result = TestViewer.CreateQuestion(text, isActive);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates the question to the Question Bank
        /// </summary>
        /// <param name="questionId">Question Id</param>
        /// <param name="text">Question Text</param>
        /// <param name="isActive">Question Status</param>
        /// <returns>IQuestion</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Question is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Question has been used in the Test Template or Test Instance</exception>
        public IQuestion UpdateQuestion(Guid questionId, string text, bool isActive)
        {
            var result = TestViewer.UpdateQuestion(questionId, text);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates Question status to its opposite status.
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <param name="isActive">Question Status</param>
        /// <exception cref="Domain.RecordNotFoundException">When Question is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When setting the question to inactive while it is being used in the Test Template</exception>
        public void UpdateQuestionStatus(Guid questionId, bool isActive)
        {
            TestViewer.UpdateQuestionStatus(questionId, isActive);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the question from the Question Bank and all its choices.
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When question is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Question is unable to be deleted because it is being used in the test template or the test instance</exception>
        public void DeleteQuestion(Guid questionId)
        {
            var question = TestViewer.FetchQuestion(questionId);
            Action action = delegate() { deleteQuestion(question); };

            TestViewer.DeleteQuestion(question, action);
            _context.SaveChanges();
        }

        private void deleteQuestion(Question question)
        {
            deleteAllQuestionChoice(question.Choices.ToList());
            _context.Questions.Remove(question);
        }

        #endregion

        #region Choice Management

        /// <summary>
        /// Adds a new question choice
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <param name="text">Choice Text</param>
        /// <param name="isCorrect">Is the choice the correct answer</param>
        /// <returns>IChoice</returns>
        /// <exception cref="Domain.BusinessRuleException">When Choice text is empty or white space</exception>
        public IChoice CreateQuestionChoice(Guid questionId, string text, bool isCorrect)
        {
            var result = TestViewer.CreateQuestionChoice(questionId, text, isCorrect);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates a question choice
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <param name="choiceId">Choice ID</param>
        /// <param name="text">Choice Text</param>
        /// <param name="isCorrect">Is choice the correct answer</param>
        /// <returns>IChoice</returns>
        /// <exception cref="Domain.RecordNotFoundException">When either question or choice is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Question is being used in either the Test Template or Test Instance</exception>
        public IChoice UpdateQuestionChoice(Guid questionId, Guid choiceId, string text, bool isCorrect)
        {
            var result = TestViewer.UpdateQuestionChoice(questionId, choiceId, text, isCorrect);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Removes a question choice
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <param name="choiceId">Choice ID</param>
        /// <returns>bool</returns>
        /// <exception cref="Domain.RecordNotFoundException">When either Question or Choice is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Question is being used in either the Test Template or Test Instance</exception>
        public void DeleteQuestionChoice(Guid questionId, Guid choiceId)
        {
            //fetch the choice for that question
            var question = TestViewer.FetchQuestion(questionId);
            var choice = question.FetchChoice(choiceId);
            Action action = delegate() { deleteQuestionChoice(choice); };

            TestViewer.DeleteQuestionChoice(action, question, choice);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes all choices associated with the particular question
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When either Question or Choice is not found.</exception>
        public void DeleteAllChoices(Guid questionId)
        {
            var question = TestViewer.FetchQuestion(questionId);
            deleteAllQuestionChoice(question.Choices.ToList());
            _context.SaveChanges();
        }

        private void deleteAllQuestionChoice(List<Choice> choices)
        {
            foreach (Choice choice in choices)
            {
                deleteQuestionChoice(choice);
            }
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
        /// <param name="templateId">Test Template ID</param>
        /// <returns>ITestTemplate</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template is not found</exception>
        public ITestTemplate FetchTestTemplate(Guid templateId)
        {
            return TestViewer.FetchTestTemplate(templateId);
        }

        /// <summary>
        /// Fetches all Test Templates that contains a specified text in the test template name
        /// </summary>
        /// <param name="name">Part of the Test Template name</param>
        /// <returns>IEnumerable&lt;ITestTemplate&gt;</returns>
        public IEnumerable<ITestTemplate> FetchTestTemplateThatContains(string name)
        {
            return TestViewer.FetchTestTemplateThatContains(name);
        }

        /// <summary>
        /// Creates a Test Template
        /// </summary>
        /// <param name="name">Test Template Name</param>
        /// <returns>ITestTemplate</returns>
        /// <exception cref="Domain.BusinessRuleException">When Test Template name is empty or white space or exists</exception>
        public ITestTemplate CreateTestTemplate(string name)
        {
            var template = TestViewer.CreateTestTemplate(name);
            _context.SaveChanges();
            return template;
        }

        /// <summary>
        /// Updates Test Template name
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="newName">New Test Template Name</param>
        /// <returns>ITestTemplate</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test template is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Test Template is being used in a Test Instance</exception>
        public ITestTemplate UpdateTestTemplate(Guid templateId, string newName)
        {
            var template = TestViewer.UpdateTestTemplate(templateId, newName);
            _context.SaveChanges();
            return template;
        }

        /// <summary>
        /// Deletes Test Template, throws exception if its assocciated with a test instance or has questions.
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        public void DeleteTestTemplate(Guid templateId)
        {
            var template = TestViewer.FetchTestTemplate(templateId);
            Action action = delegate() { deleteTestTemplate(template); };

            TestViewer.DeleteTestTemplate(action, template);
           _context.SaveChanges();           
        }

        private void deleteTestTemplate(TestTemplate template)
        {
            template.Questions.Clear();
            _context.TestTemplates.Remove(template);
        }

        /// <summary>
        /// adds or removes question into the test template
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="questionId">Question ID</param>
        /// <param name="action">Add or Remove</param>
        public void AddOrRemoveTemplateQuestion(Guid templateId, Guid questionId, AddOrRemoveStatus action)
        {
            TestViewer.AddOrRemoveTemplateQuestion(templateId, questionId, action);
            _context.SaveChanges();
        }

        #endregion

        #region Test Instance Management

        /// <summary>
        /// Fetches all test instances asssociated with the administrator ID provided.
        /// </summary>
        /// <param name="administratorId">Administrator ID</param>
        /// <returns>IEnumerable&lt;ITestInstance&gt;</returns>
        public IEnumerable<ITestInstance> FetchTestInstances(Guid administratorId)
        {
            return TestViewer.FetchTestInstancesFromAdministrator(administratorId);
        }

        /// <summary>
        /// Fecthes a particular Test Instance associated with the administrator ID
        /// </summary>
        /// <param name="administratorId">Administrator ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <returns>ITestInstance</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Administrator or Test Instance is not found</exception>
        public ITestInstance FetchTestInstance(Guid administratorId, Guid instanceId)
        {
            return TestViewer.FetchTestInstanceFromAdministrator(administratorId, instanceId);
        }

        /// <summary>
        /// Creates a new Test Instance
        /// </summary>
        /// <param name="candidateIds">List of Candidate IDs that will be added into the Test Instance</param>
        /// <param name="administratorId">Administrator ID</param>
        /// <param name="templateId">Test Instance ID</param>
        /// <param name="isPractice">Exam mode (Practice or Actual Test)</param>
        /// <param name="timeLimit">Time Limit</param>
        /// <returns>ITestInstance</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template or one of the Candidates is not found.</exception>
        /// <exception cref="Domain.BusinessRuleException">When the Candidate status is not active</exception>
        public ITestInstance CreateTestInstance(List<Guid> candidateIds, Guid administratorId, Guid templateId, bool isPractice, int timeLimit)
        {
            var result = TestViewer.CreateTestInstance(candidateIds, administratorId, templateId, isPractice, timeLimit);
            string templateName = TestViewer.FetchTestTemplate(templateId).Name;
            
            //send mail
            _mail.SendMail(new MailAddress("dimitrios.missirlis@gmail.com"), "TestInstance has been created", "Test template: " + templateName + " has been created seccessfully on " + DateTime.Now);
            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates the Test Instance information
        /// </summary>
        /// <param name="administratorId">Administrator ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="isPractice">Exam mode (Practice or Actual Test)</param>
        /// <param name="timeLimit">Time Limit</param>
        /// <returns>ITestInstance</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template or Administrator or Test Instance is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When unable to update once Test Instance is Open.</exception>
        public ITestInstance UpdateTestInstance(Guid administratorId, Guid instanceId, Guid templateId, bool isPractice, int timeLimit)
        {
            var result = TestViewer.UpdateTestInstance(administratorId, instanceId, templateId, isPractice, timeLimit);

            _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Deletes the Test Instance
        /// </summary>
        /// <param name="administratorId">Administrator ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When Administrator or Test Instance is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When unable to delete once Test Instance is Open</exception>
        public void DeleteTestInstance(Guid administratorId, Guid instanceId)
        {
            var testInstance = TestViewer.FetchTestInstanceFromAdministrator(administratorId, instanceId);

            Action action = delegate() { deleteTestInstance(testInstance); };
            TestViewer.DeleteTestInstance(action, administratorId, testInstance);

            _context.SaveChanges();
        }

        private void deleteTestInstance(TestInstance testInstance)
        {
            //delete all candidate test before deleting the test Instance
            foreach (var candidateTest in testInstance.CandidateTests)
            {
                _context.CandidateTests.Remove(candidateTest);
            }

            _context.TestInstances.Remove(testInstance);
        }

        /// <summary>
        /// Opens the Test Instance and make it accessible to the candidates
        /// </summary>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="administratorId">Administrator ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When Administrator or Test Instance is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Test Instance cannot be opened due to Business Rule Violation</exception>
        public void OpenTestInstance(Guid instanceId, Guid administratorId)
        {
            TestViewer.OpenTestInstance(instanceId, administratorId);
            _context.SaveChanges();
        }

        /// <summary>
        /// Closes the Test Instance and make it inaccessible to the candidates
        /// </summary>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="administratorId">Administrator ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When Administrator or Test Instance is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When Test Instance cannot be closed due to Business Rule Violation</exception>
        public void CloseTestInstance(Guid instanceId, Guid administratorId)
        {
            TestViewer.CloseTestInstance(instanceId, administratorId);
            _context.SaveChanges();
        }

        #endregion

        #region Candidate Test Management

        /// <summary>
        /// Fetches a particular candidate test.
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="candidateId">Candidate ID</param>
        /// <returns>ICandidateTest</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template or Test Instance or Candidate Test is not found</exception>
        public ICandidateTest FetchCandidateTest(Guid templateId, Guid instanceId, Guid candidateId)
        {
            return TestViewer.FetchCandidateTest(templateId, instanceId, candidateId);
        }

        /// <summary>
        /// Add a candidate to the Test Instance
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="candidateId">Candidate ID</param>
        /// <returns>ICandidateTest</returns>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template or Test Instance or Candidate is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When the Candidate already exists in the Test Instance or status is not active</exception>
        public ICandidateTest AddCandidateToTestInstance(Guid templateId, Guid instanceId, Guid candidateId)
        {
            var result = TestViewer.CreateCandidateTest(templateId, instanceId, candidateId);

            _context.SaveChanges();
            return result;
        }
        
        /// <summary>
        /// Removes a particular candidate from the test instance
        /// </summary>
        /// <param name="templateId">Test Template ID</param>
        /// <param name="instanceId">Test Instance ID</param>
        /// <param name="candidateId">Candidate ID</param>
        /// <exception cref="Domain.RecordNotFoundException">When Test Template or Test Instance or Candidate Test is not found</exception>
        /// <exception cref="Domain.BusinessRuleException">When cannot remove Candidate Test because the Test Instance is already open</exception>
        public void RemoveCandidateFromTestInstance(Guid templateId, Guid instanceId, Guid candidateId)
        {
            var candidateTest = TestViewer.FetchTestInstanceFromTestTemplate(templateId, instanceId).FetchCandidateTest(candidateId);
            Action action = delegate() { deleteCandidateTest(candidateTest); };
            TestViewer.DeleteCandidateTest(action, templateId, instanceId, candidateTest);

            _context.SaveChanges();
        }

        private void deleteCandidateTest(CandidateTest candidateTest)
        {
            _context.CandidateTests.Remove(candidateTest);
        }

        #endregion

        #region Exam Management

        /// <summary>
        /// Returns the exam associated with the provided Student number and token ID
        /// </summary>
        /// <param name="studentNo"></param>
        /// <param name="tokenId"></param>
        /// <returns>ICandidateTest</returns>
        public ICandidateTest GetExam(string studentNo, int tokenId)
        {
            return TestViewer.GetExam(studentNo, tokenId);
        }

        /// <summary>
        /// Sets the exam status to "in progress"
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="candidateTestId"></param>
        public void BeginExam(Guid candidateId, Guid candidateTestId)
        {
            TestViewer.BeginExam(candidateId, candidateTestId);
            _context.SaveChanges();
        }

        /// <summary>
        /// Saves the exam answer
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="candidateTestId"></param>
        /// <param name="choiceId"></param>
        public void SaveAnswer(Guid candidateId, Guid candidateTestId, Guid choiceId)
        {
            TestViewer.SaveAnswer(candidateId, candidateTestId, choiceId);
            _context.SaveChanges();
        }

        /// <summary>
        /// Closes the exam
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="candidateTestId"></param>
        public void FinishExam(Guid candidateId, Guid candidateTestId)
        {
            TestViewer.FinishExam(candidateId, candidateTestId);
            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// A class responsible for sending an email.
        /// Source code from MailingSystem 1.5.10 which was supposed to be version 1.6
        /// </summary>
        internal class MailingSystem
        {
            SmtpClient _smtp;
            MailAddress _fromAddress;
            MailAddress _toAddress;
            string _fromPassword;


            public MailingSystem() { }

            /// <summary>
            /// Sends mail 
            /// </summary>
            /// <param name="fromAddress">The addres that the mail is going to be send by</param>
            /// <param name="fromPassword">The password for the address</param>
            /// <param name="toAddress">the addres its going to be send too</param>
            /// <param name="subject">subject</param>
            /// <param name="body">the body of the email</param>
            public MailingSystem(MailAddress fromAddress, string fromPassword)
            {
                _fromAddress = fromAddress;
                _fromPassword = fromPassword;

                _smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_fromAddress.Address, _fromPassword)
                };
            }

            public void SendMail(MailAddress toAddress, string subject, string body)
            {
                using (var message = new MailMessage(_fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    try
                    {
                        _smtp.Send(message);
                    }
                    catch (SmtpFailedRecipientException)
                    {

                        // need to implement treading here.
                        // ex.FailedRecipient and ex.GetBaseException()
                    }


                }
            }
        } 

        /// <summary>
        /// Disposes the facade and all its resources
        /// </summary>
        public void Dispose()
        {
            TestViewer.Dispose();
            _context.Dispose();
            
        }
    }
}
