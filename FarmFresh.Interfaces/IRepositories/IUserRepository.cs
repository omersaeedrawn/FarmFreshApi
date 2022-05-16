using FarmFresh.Models.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetUserByIdAsync(Guid ownerId);
        Task<User> GetUserByEmailAsync(string email);
    }
}
