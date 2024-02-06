using AIProject.Application.Common.Constants;
using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models;
using AIProject.Application.Common.Models.BaseModels;
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

        public async Task<DataResponse<LoginResponse>> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByEmail(loginRequest.Email);
            // Kullanım
            DataResponse<LoginResponse> response = new DataResponse<LoginResponse>();


            if (user == null)
            {
                response.Status = HttpStatusCode.NotFound;
                response.Message = ResponseConst.UserNotFound;
                response.Data = null;
            }
            else
            {
                //Exception yazılacak 
                if (user.Email == loginRequest.Email && user.Password == loginRequest.Password)
                {
                    var tokenInfo = await _tokenService.GenerateToken(new GenerateTokenRequest() { Email = loginRequest.Email});
                  
                    LoginResponse loginResponse = new()
                    {
                        AccessToken = tokenInfo.Token,

                    };

                    response.Data = loginResponse;
                    response.Status = HttpStatusCode.OK;
                    response.Message = ResponseConst.LoginSuccess;
                }
                else
                {
                   

                    response.Data = null;
                    response.Status = HttpStatusCode.NotFound;
                    response.Message = ResponseConst.InvalidUsernameOrPassword;

                }

            }

            return response;

        }
    }
}
