using AutoMapper;
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

        private IMapper _mapper;
        public UserDetailsService(ILogger<UserDetailsService> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Response<List<UserDetailsDto>>> GetAllUsers()
        {
            var response = new Response<List<UserDetailsDto>>();
            try
            {
                var result = _repositoryWrapper.UserDetails.GetAllUsers();

                _logger.LogInformation($"Returned all Users from database.");
                var userList = new List<UserDetailsDto>();

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                response.ResponseInfo = _mapper.Map<List<UserDetailsDto>>(result);

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
