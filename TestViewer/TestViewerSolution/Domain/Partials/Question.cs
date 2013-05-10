using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    internal partial class Question : IQuestion
    {

        public Question(string text, bool isActive)
        {
            if (text.Equals(string.Empty))
            {
                throw new BusinessRuleException("The question must have text specified");
            }
            Text = text;
            Active = isActive;
        }

        public Choice FetchChoice(Guid choiceId)
        {
            return Choices.FirstOrDefault(c => c.Id.Equals(choiceId));
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
            if (choice == null)
            {
                throw new BusinessRuleException("Could not find choice in the given question");
            }
            choice.Text = text;
            choice.IsCorrect = isCorrect;

            return choice;
        }

        public void DeleteChoice(Action action, Choice choice)
        {
            action();
        }

        public void AddToTemplate(TestTemplate template)
        {
            TestTemplates.Add(template);
        }

        public void RemoveFromTemplate(TestTemplate template)
        {
            TestTemplates.Remove(template);
        }

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
