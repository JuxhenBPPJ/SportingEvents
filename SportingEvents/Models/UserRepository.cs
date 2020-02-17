using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingEvents.Models
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDBContext context;
        public UserRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Responses> Responses => context.Responses;
    }
}
