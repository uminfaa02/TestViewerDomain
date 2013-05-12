using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new Facade();

            try
            {

                
                // ADD CANDIDATE
                //*************************************************************************
                //facade.CreateCandidate("1");
                //facade.CreateCandidate("345434545345");
                //facade.CreateCandidate("634523545345");

                // FETCH CANDIDATE
                //*************************************************************************
                //IEnumerable<ICandidate> candidates = facade.Candidates;
                //foreach (var candidate in candidates)
                //{
                //    Console.WriteLine(candidate.Id + " " + candidate.StudentNumber);
                //}

                // UPDATING CANDIDATE WITH STATUES and number
                //*************************************************************************
                //facade.UpdateCandidate(new Guid ("94384455-5f7b-43d3-b76b-c88290d55035"), "1113659853", false);

                // UPDATING CANDIDATE statues
                //*************************************************************************
                //facade.UpdateCandidate(new Guid("94384455-5f7b-43d3-b76b-c88290d55035"), false);

                // UPDATING CANDIDATE number only
                //*************************************************************************
                //facade.UpdateCandidate(new Guid("94384455-5f7b-43d3-b76b-c88290d55035"), "22215655");

                // DELETE CANDIDATE
                //*************************************************************************
                //facade.DeleteCandidate(new Guid("de8532d9-4a26-4f0b-b651-cb468295a7f2"));

               
   
                // ADDING NEW QUESTION WITH CHOICES 
                //*************************************************************************
                //IQuestion newQuestion = facade.CreateQuestion("What's your mood today?", true);
                //facade.CreateQuestionChoice(newQuestion.Id, "25 deg", false);
                //facade.CreateQuestionChoice(newQuestion.Id, "26 deg", false);
                //facade.CreateQuestionChoice(newQuestion.Id, "45.5 deg", true);

                // UPDATING QUESTION 
                //*************************************************************************
                //try
                //{
                //    if (facade.CanQuestionBeModified(new Guid("52147ecf-a5a2-45ba-8ce7-1d75c8329c37")))
                //    {
                //        //facade.UpdateQuestion(new Guid("52147ecf-a5a2-45ba-8ce7-1d75c8329c37"),
                //        //                      "I just updated this question?",
                //        //                      true);
                        
                //        //facade.DeleteQuestion(new Guid("52147ecf-a5a2-45ba-8ce7-1d75c8329c37"));
                //    }
                //    else
                //    {
                //        // it exists only in the template
                //        Console.WriteLine("Question exists in the template. do you want to proceed ?");
                //    }
                //}
                //catch (BusinessRuleException bre)
                //{
                //    Console.WriteLine(bre.Message);
                //}

                // DELETING A QUESTION
                //*************************************************************************
                //facade.DeleteQuestion(new Guid("8a9b3c01-9cac-4024-a7a0-a3d4acfdd3ca"));

                // DELETING QUESTION CHOICE 
                //*************************************************************************
                //facade.DeleteQuestionChoice(new Guid("928fcf8f-1253-409c-a6d4-e0e8884eceeb"),
                //                            new Guid("c3693db3-512c-431b-998a-3d5a13ef2062"));
                

                // UPDATING QUESTION CHOICE 
                //*************************************************************************
                //facade.AddOrUpdateQuestionChoice(new Guid("928fcf8f-1253-409c-a6d4-e0e8884eceeb"),
                //                                 new Guid("1b9c0b36-3cae-4d9b-ae42-56cb1eba5378"), "Five", 
                //                                 false);

                // FETCH QUESTION
                //*************************************************************************
                //facade.FetchQuestion(new Guid("7b1760d9-b78b-4ad5-9490-af6974f187a8"));

                // DISPLAY ALL QUESTIONS WITH CHOICES
                //*************************************************************************
                //IEnumerable<IQuestion> questions = facade.Questions;
                //foreach (IQuestion question in questions)
                //{
                //    Console.WriteLine("Question: " + question.Text);
                //    Console.WriteLine("Choices: ");
                //    foreach (IChoice choice in question.Choices)
                //    {
                //        Console.WriteLine("\t" + choice.Text + (choice.IsCorrect ? " -> Correct Answer" : ""));
                //    }
                //    Console.WriteLine("=======================================================\n");
                //}
           

                // ADDING TEST TEMPLATE
                //*************************************************************************
                //facade.CreateTestTemplate("WE gotta change name!! again");
                

                // UPDATING TEST TEMPLATE
                //*************************************************************************
                //facade.UpdateTestTemplate(new Guid("195f1410-e10b-4068-bf51-3219be1319de"), "Updated Template");

                // ADDING QUESTION TO TEST TEMPLATE
                //*************************************************************************
                //facade.AddOrRemoveTemplateQuestion(new Guid("800e37fd-c7d2-48e0-bdd2-636f7af2dd4d"),
                //                                   new Guid("52147ecf-a5a2-45ba-8ce7-1d75c8329c37"),
                //                                   AddOrRemoveStatus.Add);

                // FETCH ALL TEMPLATES AND THERE QUESTIONS
                //*************************************************************************
                //IEnumerable<ITestTemplate> templates = facade.TestTemplates;
                //foreach (ITestTemplate template in templates)
                //{
                //    Console.WriteLine(template.Name);


                //    foreach (IQuestion question in template.Questions)
                //    {
                //        Console.WriteLine("Question: " + question.Text);
                //        Console.WriteLine("Choices: ");

                //        foreach (IChoice choice in question.Choices)
                //        {
                //            Console.WriteLine("\t" + choice.Text + (choice.IsCorrect ? " -> Correct Answer" : ""));
                //        }
                //        Console.WriteLine("=======================================================\n");
                //    }

                //    Console.WriteLine("=======================================================\n");
                //    Console.WriteLine("=======================================================\n");
                //    Console.WriteLine("=======================================================\n");
                //}


                // CREATE A NEW TEST INSTANCE
                //*************************************************************************
                //facade.CreateTestInstance(facade.Candidates, new Guid("c095c678-1828-41ed-91d0-1129105f5a3d"),
                //                          new Guid("7e45570d-bdf8-429c-8b9a-b2179e40535a"), true, 40);

                //facade.CreateTestInstance(facade.Candidates, new Guid("c095c678-1828-41ed-91d0-1129105f5a3d"), new Guid("68241242-c8e8-4d65-bd2b-074291b119e1"), false, 30);

                //facade.AddOrRemoveTemplateQuestion(new Guid("834fe354-6562-4a00-b8d2-37d9e1a47f18"), new Guid("928fcf8f-1253-409c-a6d4-e0e8884eceeb"), AddOrRemoveStatus.Remove);

                // LIST ALL CANDIDATES THAT START WITH NUMBER>>>
                //*************************************************************************
                //var result = facade.CandidatesStartsWith("345");
                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.StudentNumber);
                //    Console.WriteLine("=======================================================\n");
                //}

                //facade.DeleteTestTemplate(new Guid("834fe354-6562-4a00-b8d2-37d9e1a47f18"));

                facade.AddOrRemoveTemplateQuestion(new Guid("e3604062-537e-4915-9488-5069496754d1"), new Guid("7dd4b958-f838-407a-9618-74ec7f83a951"), AddOrRemoveStatus.Remove);
                
                Console.WriteLine("Done...");
                
            }

            catch (BusinessRuleException bre)
            {
                Console.WriteLine(bre.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\n" + e.ToString());
            }
            finally
            {
                facade.Dispose();
                Console.WriteLine("Facade object is disposed.");
                Console.ReadLine();
            }
   
        }
    }
}
