using NikoraApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikoraApi.Core.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(NikDbContext dbContext) : base(dbContext)
        {

        }
    }
}
