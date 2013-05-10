using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class QuestionBank : IQuestionBank
    {

        public Question FetchQuestion(Guid questionId)
        {
            return Questions.FirstOrDefault(q => q.Id.Equals(questionId));
        }

        public Question CreateQuestion(string text, bool isActive)
        {
            var question = new Question(text, isActive);
            Questions.Add(question);
            return question;
        }

        public void CanQuestionBeModified(Question question)
        {
            if (question == null)
                throw new BusinessRuleException("Question does not exists.");

            // A list of templates that contain this question
            List<TestTemplate> templates = question.TestTemplates.ToList();

            if (templates.Count > 0)
            {
                // Test templates that has been used in the test instance
                var result = templates.Where(t => t.TestInstances.Count > 0).ToList();
                if (result.Count > 0)
                {
                    throw new BusinessRuleException("Question has been used in the Test Instance. Cannot be modified.");
                }
                else
                {
                    // question only exists in the test template
                    //TODO: fix me
                    // if false (massege box - question is in the test tamplate only , do you still want to continue)
                    throw new WarningBeforeProceedException("Question has been used in test Template");
                }
            }
        }

        public Question UpdateQuestion(Guid questionId, string text, bool isActive, bool ignoreValidation)
        {
            var question = FetchQuestion(questionId);
            if (!ignoreValidation)
            {
                CanQuestionBeModified(question);
            }
            question.Text = text;
            question.Active = isActive;

            return question;
        }

        public void DeleteQuestion(Action action, Question question)
        {
            //TODO: Put Check for Test Instance before deleting question
         
            if (question == null)
            {
                throw new BusinessRuleException("Could not find question with Question ID " + question);
            } 
                action();    
        }

        public void DeleteQuestionChoice(Action action, Choice choice)
        {
            CanQuestionBeModified(choice.Question);
            choice.Question.DeleteChoice(action, choice);
        }

        public void AddTemplateQuestion(TestTemplate template, Guid questionId)
        {
            var question = FetchQuestion(questionId);

            if (questionAssociatedWithTemplate(template, question))
                throw new BusinessRuleException("Question already exists in the test template");  
            else
                question.AddToTemplate(template);    
        }

        public void RemoveTemplateQuestion(TestTemplate template, Guid questionId)
        {
            var question = FetchQuestion(questionId);

            if (questionAssociatedWithTemplate(template, question))
                question.RemoveFromTemplate(template);
            else
                throw new BusinessRuleException("Question does not exists in the template");    
        }

        private bool questionAssociatedWithTemplate(TestTemplate template, Question question)
        {
            var result = question.TestTemplates.Where(t => t.Id.Equals(template.Id)).ToList();
            if (result.Count > 0)
                return true;
            return false;
        }



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
    }
}
