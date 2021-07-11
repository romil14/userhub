using System.Collections.Generic;
using System.Threading.Tasks;
using uh.ViewModels.BaseRequestResponse;
using uh.ViewModels.Models;

namespace uh.Services.Contracts
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
