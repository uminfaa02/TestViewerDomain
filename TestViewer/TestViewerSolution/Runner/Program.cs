using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Diagnostics;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //var facade = new Facade();
            
            try
            {
                //facade.DeleteTestTemplate(new Guid("867075c7-4d62-4e71-96ef-9600477f6425"));

                ///*********************************
                // * EXECUTE ONLY FOR UNIT TESTING *
                //// *********************************/
                //var c1 = facade.CreateCandidate("1111111111");
                //var c2 = facade.CreateCandidate("2222222222");
                //var c3 = facade.CreateCandidate("3333333333");
                //var c4 = facade.CreateCandidate("4444444444");
                //var c5 = facade.CreateCandidate("5555555555");



                //IQuestion q1 = facade.CreateQuestion("An information system is an arrangement of people, data, processes, and information technology that interact to collect, process, store, and provide as output the information needed to support the organization.");
                //facade.CreateQuestionChoice(q1.Id, "True", true);
                //facade.CreateQuestionChoice(q1.Id, "False", false);
                //IQuestion q1set = facade.FetchQuestion(q1.Id);

                //IQuestion q2 = facade.CreateQuestion("An information system must have computer hardware and software to be valid.");
                //facade.CreateQuestionChoice(q2.Id, "True", false);
                //facade.CreateQuestionChoice(q2.Id, "False", true);
                //IQuestion q2set = facade.FetchQuestion(q2.Id);

                //IQuestion q3 = facade.CreateQuestion("A management information system can use data provided by a transaction processing system.");
                //facade.CreateQuestionChoice(q3.Id, "True", true);
                //facade.CreateQuestionChoice(q3.Id, "False", false);
                //IQuestion q3set = facade.FetchQuestion(q3.Id);


                //var t1 = facade.CreateTestTemplate("SAD Chapter 1");

                //facade.AddOrRemoveTemplateQuestion(new Guid("867075c7-4d62-4e71-96ef-9600477f6425"), new Guid("aaf04141-6d73-4067-b5a2-6c7aea071170"), AddOrRemoveStatus.Add);
                //facade.AddOrRemoveTemplateQuestion(new Guid("867075c7-4d62-4e71-96ef-9600477f6425"), new Guid("d825602d-7390-4b09-a653-ca57a458c130"), AddOrRemoveStatus.Add);
                //facade.AddOrRemoveTemplateQuestion(new Guid("867075c7-4d62-4e71-96ef-9600477f6425"), new Guid("de747da0-2365-4425-9205-fe2d0427dda2"), AddOrRemoveStatus.Add);
                //var tquestions = facade.FetchTestTemplate(new Guid("867075c7-4d62-4e71-96ef-9600477f6425"));

                //var candidates = facade.FetchCandidates();
                //List<Guid> ids = new List<Guid>();
                //foreach (var item in candidates)
                //{
                //    ids.Add(item.Id);
                //}
                //var ti = facade.CreateTestInstance(ids, new Guid("ac513d6c-c0f9-4c10-a538-85a6c38d6052"), new Guid("867075c7-4d62-4e71-96ef-9600477f6425"), false, 50);

                //facade.OpenTestInstance(new Guid("0e8b57a3-40ba-467e-92a2-086ccae9f69b"), 
                //                        new Guid("ac513d6c-c0f9-4c10-a538-85a6c38d6052"));

                //Stopwatch sw = new Stopwatch();
                //sw.Start();
                //var exam = facade.GetExam("1111111111", 1001);
                //sw.Stop();
                //Console.WriteLine("Method GetExam Processing time: {0}", sw.Elapsed);
                //facade.SaveAnswer(exam.CandidateId, exam.Id, 

                //facade.UpdateCandidate(new Guid("6d7511da-40b3-490e-9a5a-558c1c71ef7c"), "3334445556", true);
                




                //facade.OpenTestInstance(new Guid("bf10810f-9f81-4949-a9bd-1fb85075994c"), new Guid("c095c678-1828-41ed-91d0-1129105f5a3d"));
                //IEnumerable<ICandidate> cands = facade.CandidatesThatContains("", false);
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
                //facade.Dispose();
                Console.WriteLine("Facade object is disposed.");
                Console.ReadLine();
            }
   
        }
    }
}
