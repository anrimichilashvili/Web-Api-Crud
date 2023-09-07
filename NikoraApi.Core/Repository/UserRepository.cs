using NikoraApi.Domain.Models;

namespace NikoraApi.Core.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(NikDbContext dbContext) : base(dbContext)
        {

        }

        public User CheckValidUser(User user)
        {
            return _dbSet.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
