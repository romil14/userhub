using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uh.ViewModels.BaseRequestResponse;
using uh.ViewModels.Models;

namespace uh.ServiceInterfaces.Entities
{
    public interface IUserDetailsService 
    {
        Task<Response<List<UserDetailsDto>>> GetAllUsers();

        Task<Response<UserDetailsDto>> GetUserById(int id);

        Task<Response<object>> CreateUser(UserDetailsDto userDetailsDto);
        Task<Response<object>> UpdateUser(UserDetailsDto userDetailsDto);
        Task<Response<object>> DeleteUser(int id);
    }
}
