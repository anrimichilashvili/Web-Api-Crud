using NikoraApi.Domain.Interfaces;
using NikoraApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikoraApi.Core.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User? GetByUserName(string userName);
    }
}
