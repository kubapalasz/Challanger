using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GeekUp.Host.Handlers;
using GeekUp.Host.Models;
using Nancy;
using Nancy.Helpers;
using Newtonsoft.Json;
using Serilog;

namespace GeekUp.Host.Modules
{
    public class GeekModule : NancyModule
    {
        private readonly IEnumerable<IQueryHandler> _handlers;
        private readonly string[] _allowedIps =
        {
            "10.202.36.105", // local machine
            "10.202.36.93" // hossein's machine
        };

        public GeekModule()
        {
            Get["/"] = parameters => HandleQuery(parameters);

            _handlers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && typeof(IQueryHandler).IsAssignableFrom(t))
                .Select(t => (IQueryHandler)Activator.CreateInstance(t))
                .ToList();
        }

        internal string HandleQuery(dynamic parameters)
        {
            try { 
                var queryStr = Request.Url.Query;
                var requestIp = Request.UserHostAddress;

                Log.Information("Start processing {query} from {ip}...", queryStr, requestIp);

                if (_allowedIps.Contains(requestIp) == false)
                {
                    Log.Warning("Detected forged request from {ip}, aborting...", requestIp);
                    return "Fuck off!";
                }

                var query = HttpUtility.ParseQueryString(queryStr);
                var json = query["q"].Substring(10);

                var questionId = query["q"].Substring(0, 8);
                var question = JsonConvert.DeserializeObject<QuestionModel>(json);

                foreach (var handler in _handlers.Where(h => h.CanHandle(question)))
                {
                    Log.Information("Executing {handler} with parameters {parameters}", handler.GetType().Name, question.Parameters);

                    var result = handler.Handle(question, json);
                    if (result != null)
                    {
                        Log.Information("Successfully processed question {id} with {json}: {Result}", questionId, json, result);
                        return result;
                    }
                }

                Log.Error("Unable to handle question {id} with {json}", questionId, json);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unhandled error occurred");
            }

            return "Unable to handle query :(";
        }
    }
}
