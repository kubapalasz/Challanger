using NancySelfHosting.Answers;
using Newtonsoft.Json;

namespace NancySelfHosting
{
    using Nancy;
    using System;
    using System.Diagnostics;
    using System.Web;
    using Nancy.Helpers;
    using System.Runtime.Serialization.Json;
    using System.IO;
    using System.Text;

    public class Question
    {
        public string questionType;
        public string question;
		public Object parameters;
		public int points;
    }

    //{"questionType":"ExtremeStartup::TranslationQuestion","question":"What area means in German? (Bereich)","parameters":["area","de","German"],"points":60}

    public class Module : NancyModule
    {
        public Module()
        {
            Get["/"] = parameters => { return handleQuery(parameters); }; //"Hello World";
        }

        private String handleQuery(dynamic parameters)
        {
            String query = "";
            query += HttpUtility.UrlDecode(Request.Url.Query);
            String answer = "Hoss";
            try
            {


                if (query.Length > 0)
                {
                    query = query.Substring(13, query.Length - 13);
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof (Question));
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(query));
                    Question q = (Question) js.ReadObject(stream);
                    Console.WriteLine(q.question);
                    Console.WriteLine(q.points);
                    Console.WriteLine(q.question);
                    var stringSerialized =
                        JsonConvert.SerializeObject(q.parameters);
                    Console.WriteLine(stringSerialized);

                    
                    switch (q.questionType)
                    {
                        case "ExtremeStartup::TranslationQuestion":
                            answer = new Translator(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::WarmupQuestion":
                            answer = "Team3";
                            break;
                        case "ExtremeStartup::MaximumQuestion":
                            answer = new MaxAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::AdditionQuestion":
                            answer = new AdditionAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::AdditionAdditionQuestion":
                            answer = new AdditionAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::MultiplicationQuestion":
                            answer = new MultiplicationAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::AdditionMultiplicationQuestion":
                            answer = new AddMultiplyAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::MultiplicationAdditionQuestion":
                            answer = new MultiplyAddAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::GeneralKnowledgeQuestion":
                            answer = new GeneralAnswer(q.question).GetAnswer();
                            break;
                        case "ExtremeStartup::PrimesQuestion":
                            answer = new PrimesAnswer().GetAnswer();
                            break;
                        case "ExtremeStartup::SubtractionQuestion":
                            answer = new SubtAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::SquareCubeQuestion":
                            answer = new SqueareQubeAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::FibonacciQuestion":
                            answer = new FibonacciAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::PowerQuestion":
                            answer = new FibonacciAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::ScrabbleQuestion":
                            answer = new ScrabbleAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::AnagramQuestion":
                            answer = new AnagramAnswer(stringSerialized).GetAnswer();
                            break;
                        case "ExtremeStartup::ForecastQuestion":
                            if (q.question.Contains("Helsinki")) answer = "15";
                            else answer = "22";
                            break;
                        default:
                            answer = q.questionType;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                answer = ex.Message + "\n" + ex.StackTrace + "\n";
            }

            Console.WriteLine(answer);
            return answer;
        }
    }
}

/*
 * String query = "";
            query += HttpUtility.UrlDecode(Request.Url.Query);

            if (query.Length > 0)
            {
                query = query.Substring(13, query.Length - 13);
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Question));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(query));
                Question q = (Question)js.ReadObject(stream);
                Debug.WriteLine(q.question);
            }

            String answer = "Hoss";

            return answer;*/
