using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Mappers_Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponseModel> Create(RegistrationRequestModel model)
        {
            var passwordObj = EncryptPassword(model.Password);
            var oModel = model.MapRequestToDomain(passwordObj.Hash, passwordObj.Salt);
            await _userRepository.AddAsync(oModel);
            _userRepository.Complete();
            return oModel.MapDomainToResponse();

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.Remove(user);
            _userRepository.Complete();
        }

        private HashSalt EncryptPassword(string password)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = RandomNumberGenerator.Create())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return new HashSalt { Hash = hashed, Salt = salt };
        }

        private struct HashSalt
        {
            public byte[] Salt;
            public string Hash;
        }

    }
}
