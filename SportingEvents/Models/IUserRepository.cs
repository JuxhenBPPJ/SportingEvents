using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingEvents.Models
{
    public interface IUserRepository
    {
        IQueryable<Responses> Responses { get; }
    }
}
 