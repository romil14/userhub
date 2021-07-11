using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uh.ServiceInterfaces.Entities;
using uh.ViewModels.BaseRequestResponse;
using uh.ViewModels.Models;

namespace UserHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {

        private readonly IUserDetailsService _userDetailsService;
        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }


        [HttpGet]
        [Route("~/api/GetAllUsers")]
        public async Task<Response<List<UserDetailsDto>>> GetAllUsers()
        {
            var result = await this._userDetailsService.GetAllUsers();

            return result;
        }

        [HttpGet]
        [Route("~/api/GetUserById/{id}")]
        public async Task<Response<UserDetailsDto>> GetUserById(int id)
        {
            var result = await this._userDetailsService.GetUserById(id);

            return result;
        }

        [HttpPost]
        [Route("~/api/CreateUser")]
        public async Task<Response<object>> CreateUser([FromBody] UserDetailsDto userDetailsDto)
        {
            var result = await this._userDetailsService.CreateUser(userDetailsDto);

            return result;
        }

        [HttpPost]
        [Route("~/api/UpdateUser")]
        public async Task<Response<object>> UpdateUser([FromBody] UserDetailsDto userDetailsDto)
        {
            var result = await this._userDetailsService.UpdateUser(userDetailsDto);

            return result;
        }

        [HttpDelete]
        [Route("~/api/DeleteUser/{id}")]
        public async Task<Response<object>> DeleteUser(int id)
        {
            var result = await this._userDetailsService.DeleteUser(id);

            return result;
        }
    }
}
