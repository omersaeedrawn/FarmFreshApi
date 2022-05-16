using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Models.Domain_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FarmFreshDbContext conetxt) : base(conetxt)
        { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Find(user => user.Email.Equals(email))
            .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await Find(user => user.Id.Equals(id))
            .FirstOrDefaultAsync();
        }
    }
}
