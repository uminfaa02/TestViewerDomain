using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    internal partial class Question : IQuestion
    {

        public Question(string text, bool isActive) : this()
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                throw new BusinessRuleException("Question cannot be empty or white space.");
            }
            
            Text = text;
            Active = isActive;
        }

        public bool Isvalid
        {
            get {  return (Choices.Count > 1) && (Choices.FirstOrDefault(c => c.IsCorrect) != null); }
        }

        public bool IsBeingUsedInTestInstance
        {
            get 
            {
                return TestTemplates.FirstOrDefault(t => t.IsBeingUsedInTestInstance) != null ? true : false;
            }
        }

        public bool IsInTestTemplate(TestTemplate template)
        {
            return TestTemplates.FirstOrDefault(t => t.Id.Equals(template.Id)) != null ? true : false;
        }

        public bool IsBeingUsedInTestTemplate
        {
            get { return TestTemplates.Count > 0; }
        }

        #region Question Choice

        public Choice FetchChoice(Guid choiceId)
        {
            var result = Choices.FirstOrDefault(c => c.Id.Equals(choiceId));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Choice with ID '" + choiceId + "' does not exist");
        }

        public Choice FetchChoice(string text)
        {
            var result = Choices.FirstOrDefault(c => c.Text.Equals(text));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Choice with text '" + text + "' does not exist");
        }

        public Choice CreateChoice(string text, bool isCorrect)
        {
            var choice = new Choice(text, isCorrect);
            Choices.Add(choice);
            return choice;
        }

        public Choice UpdateChoice(Guid choiceId, string text, bool isCorrect)
        {
            var choice = FetchChoice(choiceId);

            choice.Text = text;
            choice.IsCorrect = isCorrect;

            return choice;
        }

        public void DeleteChoice(Action action, Choice choice)
        {
            action();
        }

        #endregion


        #region Test Template

        public void AddToTemplate(TestTemplate template)
        {
            TestTemplates.Add(template);
        }

        public void RemoveFromTemplate(TestTemplate template)
        {
            TestTemplates.Remove(template);
        }

        public void RemoveFromAllTemplate()
        {
            foreach (var template in TestTemplates)
            {
                RemoveFromTemplate(template);
            }
        }

        #endregion


        #region IQuestion Members

        IEnumerable<IChoice> IQuestion.Choices
        {
            get { return Choices.AsEnumerable<IChoice>(); }
        }

        IQuestionBank IQuestion.QuestionBank
        {
            get { return QuestionBank; }
        }

        IEnumerable<ITestTemplate> IQuestion.TestTemplates
        {
            get { return TestTemplates; }
        }

        #endregion
    }
}