using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<AuthTokenResponse> Authenticate(LoginRequestModel model);

    }
}
