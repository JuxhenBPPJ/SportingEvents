using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingEvents.Models
{
    public class Repository
    {
        public static List<Responses> responses = new List<Responses>();

        public static IEnumerable<Responses> Responses
        {
            get { return responses; }
        }

        public static void AddResponse(Responses response) 
        {
            responses.Add(response);
        }
    }
}
