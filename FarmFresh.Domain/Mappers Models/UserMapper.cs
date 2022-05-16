using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Mappers_Models
{
    public static class UserMapper
    {
        public static User MapRequestToDomain(this RegistrationRequestModel source, string password,
            byte[] salt)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                Password = password,
                StoredSalt = salt
            };
        }

        public static UserResponseModel MapDomainToResponse(this User source)
        {
            return new UserResponseModel
            {
                Id =source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email
            };
        }
    }
}
