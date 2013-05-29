using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class QuestionBank : IQuestionBank, IDisposable
    {

        #region Question

        public Question FetchQuestion(Guid questionId)
        {
            var result = Questions.FirstOrDefault(q => q.Id.Equals(questionId));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Question with ID '" + questionId + "' does not exist");
        }

        public Question FetchQuestion(string questionText)
        {
            var result = Questions.FirstOrDefault(q => q.Text.Equals(questionText));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Question with text '" + questionText + "' does not exist");
        }

        public List<Question> FetchQuestionThatContains(string questionTextPart)
        {
            return Questions.Where(q => q.Text.ToLower().Contains(questionTextPart.ToLower())).ToList();
        }

        public Question CreateQuestion(string text, bool isActive)
        {
            var question = new Question(text, isActive);
            Questions.Add(question);
            return question;
        }

        public Question UpdateQuestionStatus(Guid questionId, bool isActive)
        {
            var question = FetchQuestion(questionId);

            if (question.Active == true)
            {
                if (question.IsBeingUsedInTestTemplate)
                {
                    throw new BusinessRuleException("Unable to set question to inactive while it is being used in the Test Template");
                }
            }
            question.Active = isActive;
            return question;
        }

        public Question UpdateQuestion(Guid questionId, string text)
        {
            var question = FetchQuestion(questionId);
            ThrowBusinessRuleViolation(question);

            question.Text = text;
            return question;
        }

        public void DeleteQuestion(Question question, Action action)
        {
            ThrowBusinessRuleViolation(question);
            action();
        }

        private void ThrowBusinessRuleViolation(Question question)
        {
            if (question.IsBeingUsedInTestInstance)
                throw new BusinessRuleException("Unable to update question because is it being used in the Test Instance");
            else if (question.IsBeingUsedInTestTemplate)
                throw new BusinessRuleException("Unable to update question because is it being used in the Test Template");
        }

        #endregion

        #region Choice

        public Choice CreateQuestionChoice(Guid questionId, string text, bool isCorrect)
        {
            var question = FetchQuestion(questionId);
            ThrowBusinessRuleViolation(question);
            
            return question.CreateChoice(text, isCorrect);
        }

        public Choice UpdateQuestionChoice(Guid questionId, Guid choiceId, string text, bool isCorrect)
        {
            var question = FetchQuestion(questionId);
            ThrowBusinessRuleViolation(question);

            return question.UpdateChoice(choiceId, text, isCorrect);
        }

        public void DeleteQuestionChoice(Action action, Question question, Choice choice)
        {
            ThrowBusinessRuleViolation(question);
            question.DeleteChoice(action, choice);
        }

        #endregion

        #region Test Template

        public void AddTemplateQuestion(TestTemplate template, Guid questionId)
        {
            var question = FetchQuestion(questionId);

            if (question.IsInTestTemplate(template))
                throw new BusinessRuleException("Question already exists in the test template");
            else if (!question.Isvalid)
                throw new BusinessRuleException("Question does not contain either at least 2 choices or 1 choice with answer");
            else
                question.AddToTemplate(template);
        }

        public void RemoveTemplateQuestion(TestTemplate template, Guid questionId)
        {
            var question = FetchQuestion(questionId);

            if (question.IsInTestTemplate(template))
                question.RemoveFromTemplate(template);
            else
                throw new RecordNotFoundException("Question does not exists in the template");
        }

        public List<Question> FetchQuestionsNotInTheTestTemplate(TestTemplate template)
        {
            return Questions.Where(q => !q.TestTemplates.Contains(template)).ToList();
        }

        #endregion

        #region IQuestionBank Members

        IEnumerable<IQuestion> IQuestionBank.Questions
        {
            get { return Questions; }
        }

        ITestViewer IQuestionBank.TestViewer
        {
            get { return TestViewer; }
        }

        #endregion

        public void Dispose()
        {
            Questions.Clear();
        }
    }
}
