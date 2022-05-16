using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IServices
{
    public interface IUserService
    {
        Task<UserResponseModel> Create(RegistrationRequestModel model);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task DeleteUserAsync(User user);
    }
}
