using System.Linq;

namespace SportingEvents.Models
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDBContext context;
        public UserRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Responses> Responses => context.UserInfo;
    }
}
