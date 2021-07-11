using System.Collections.Generic;
using System.Threading.Tasks;
using uh.Entities.Models;

namespace uh.Repositories.Contracts
{
    public interface IUserDetailsRepository 
    {
        Task<IEnumerable<UserDetails>> GetAllUsers();

        Task<UserDetails> GetUserById(int id);

        void CreateUser(UserDetails userDetails);
        void UpdateUser(UserDetails userDetails);
        void DeleteUser(UserDetails userDetails);

        Task<bool> CheckUserNameExist(string userName, int userDetailsId);
    }
}
