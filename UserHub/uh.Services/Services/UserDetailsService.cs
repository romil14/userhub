using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uh.Entities.Models;
using uh.Helpers;
using uh.Repositories.Contracts;
using uh.Services.Contracts;
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

        public async Task<Response<object>> CreateUser(UserDetailsDto userDetailsDto)
        {
            var response = new Response<object>();

            try
            {
                if(userDetailsDto == null)
                {
                    _logger.LogError("User Details object sent from client is null.");

                    response.Message = "Failed";
                    response.ErrorInfo = new List<ErrorInfo>()
                    {
                        new ErrorInfo("EI01", "User Details is null")
                    };
                    response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);
                    return response;
                }

                var anyUserNameItem = await this._repositoryWrapper.UserDetails.CheckUserNameExist(userDetailsDto.UserName, userDetailsDto.UserDetailsId);
               
                if(anyUserNameItem)
                {
                    _logger.LogError($"User Name {userDetailsDto.UserName} sent from client is already exist.");
                   
                    response.Message = "Failed";
                    response.ErrorInfo = new List<ErrorInfo>()
                    {
                        new ErrorInfo("EI02", $"User Name '{userDetailsDto.UserName}' is already exist.")
                    };
                    response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);
                    return response;
                }

                var userEntity = _mapper.Map<UserDetails>(userDetailsDto);
                userEntity.CreatedOn = DateTime.UtcNow;
                userEntity.UpdatedOn = DateTime.UtcNow;
                this._repositoryWrapper.UserDetails.CreateUser(userEntity);
                await this._repositoryWrapper.Save();

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside CreateUser method: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
        }

        public async Task<Response<object>> DeleteUser(int id)
        {
            var response = new Response<object>();

            try
            {
                var existingUser = await _repositoryWrapper.UserDetails.GetUserById(id);
                if (existingUser == null)
                {
                    _logger.LogError($"User Id:{id} not exist.");

                    response.Message = "Failed";
                    response.ErrorInfo = new List<ErrorInfo>()
                    {
                        new ErrorInfo("EI03", "User not exist.")
                    };
                    response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);
                    return response;
                }

               
                this._repositoryWrapper.UserDetails.DeleteUser(existingUser);

                await this._repositoryWrapper.Save();

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside DeleteUser method: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
        }

        public async Task<Response<List<UserDetailsDto>>> GetAllUsers()
        {
            var response = new Response<List<UserDetailsDto>>();
            try
            {
                var result = await _repositoryWrapper.UserDetails.GetAllUsers();

                _logger.LogInformation($"Returned all Users from database.");               

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                response.ResponseInfo = _mapper.Map<List<UserDetailsDto>>(result);

                return response;
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers method: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
          

        }

        public async Task<Response<UserDetailsDto>> GetUserById(int id)
        {
            var response = new Response<UserDetailsDto>();
            try
            {
                var result = await _repositoryWrapper.UserDetails.GetUserById(id);

                if(result == null) 
                {
                    _logger.LogInformation($"Returned No Data for Id={id} from database.");
                    response.Message = "No Data";
                    response.StatusCode = Convert.ToInt32(ResponseStatus.NoData);
                    return response;
                }

                _logger.LogInformation($"Returned User Id={result.UserDetailsId} from database.");

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                response.ResponseInfo = _mapper.Map<UserDetailsDto>(result);

                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside GetUserById method: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
        }

        public async Task<Response<object>> UpdateUser(UserDetailsDto userDetailsDto)
        {
            var response = new Response<object>();

            try
            {
                var existingUser = await _repositoryWrapper.UserDetails.GetUserById(userDetailsDto.UserDetailsId);
                if (existingUser == null)
                {
                    _logger.LogError($"User Id:{userDetailsDto.UserDetailsId} not exist.");

                    response.Message = "Failed";
                    response.ErrorInfo = new List<ErrorInfo>()
                    {
                        new ErrorInfo("EI02", $"User Id:{userDetailsDto.UserDetailsId} not exist.")
                    };

                    response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                    return response;
                }

                var anyUserNameItem = await this._repositoryWrapper.UserDetails.CheckUserNameExist(userDetailsDto.UserName, userDetailsDto.UserDetailsId);
                if (anyUserNameItem)
                {
                    _logger.LogError($"User Name {userDetailsDto.UserName} sent from client is already exist.");

                    response.Message = "Failed";
                    response.ErrorInfo = new List<ErrorInfo>()
                    {
                        new ErrorInfo("EI02", $"User Name '{userDetailsDto.UserName}' is already exist.")
                    };

                    response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);
                    return response;
                }
               

                _mapper.Map(userDetailsDto, existingUser);
                this._repositoryWrapper.UserDetails.UpdateUser(existingUser);

                await this._repositoryWrapper.Save();

                response.Message = "Success";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Success);
                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside UpdateUser method: {ex.Message}");

                response.Message = "Failed";
                response.StatusCode = Convert.ToInt32(ResponseStatus.Failed);

                return response;
            }
        }
    }
}
