using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Service.Services
{
    public class AuthService : IAuthService
    {
		private readonly IConfiguration _iconfiguration;
		private readonly IUserRepository _userRepository;
		public AuthService(IConfiguration iconfiguration, IUserRepository userRepository)
		{
			_iconfiguration = iconfiguration;
			_userRepository = userRepository;
		}
		public async Task<AuthTokenResponse> Authenticate(LoginRequestModel model)
		{
			var user = await _userRepository.GetUserByEmailAsync(model.Email);

			if(user == null)
            {
				return null;
            }

			var password = VerifyPassword(model.Password, user.StoredSalt, user.Password);

			if(!password)
            {
				return null;
            }

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, model.Email)
			  }),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new AuthTokenResponse { Token = tokenHandler.WriteToken(token) };

		}


		private bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword)
		{
			string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: enteredPassword,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 100000,
				numBytesRequested: 256 / 8
			));

			return encryptedPassw == storedPassword;
		}
	}
}
