using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingEvents.Models
{
    public class TempUserRepository : IUserRepository
    {
        public IQueryable<Responses> Responses => new List<Responses>
        {
            new Responses { Name = "Juxhen", Gender ="Male"},
            new Responses { Name = "Jamshid", Gender="Male" },
            new Responses { Name = "Jayna", Gender ="Female"}

        }.AsQueryable<Responses>();
    }
}
