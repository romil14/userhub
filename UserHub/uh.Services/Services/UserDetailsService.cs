using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uh.Helpers;
using uh.Interfaces.Entities;
using uh.ServiceInterfaces.Entities;
using uh.ViewModels.BaseRequestResponse;
using uh.ViewModels.Models;

namespace uh.Services.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly ILogger<UserDetailsService> _logger;

        private readonly IRepositoryWrapper _repositoryWrapper;      
        public UserDetailsService(ILogger<UserDetailsService> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<Response<List<UserDetailsModel>>> GetAllUsers()
        {
            var response = new Response<List<UserDetailsModel>>();
            try
            {
                var result = _repositoryWrapper.UserDetails.GetAllUsers();

                _logger.LogInformation($"Returned all Users from database.");
                var userList = new List<UserDetailsModel>();

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                response.ResponseInfo = userList;

                return response;
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
          

        }
       

      
    }
}
