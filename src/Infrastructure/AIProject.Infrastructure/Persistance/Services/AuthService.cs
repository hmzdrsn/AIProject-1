using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByEmail(loginRequest.Email);

            if(user ==null)
            {
                return new() { AccessToken = "" };
            }
            else
            {
                //Exception yazılacak 
                LoginResponse response = new();
                if (user.Email == loginRequest.Email && user.Password == loginRequest.Password)
                {
                    var tokenInfo = await _tokenService.GenerateToken(new GenerateTokenRequest() { Email = loginRequest.Email});
                    response.AccessToken = tokenInfo.Token;
                    
                }
                return response;
            }
        }
    }
}
