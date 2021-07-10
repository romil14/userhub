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
        public async Task<Response<List<UserDetailsDto>>> GetAllUsers()
        {
            var result = await this._userDetailsService.GetAllUsers();

            return result;
        }
    }
}
