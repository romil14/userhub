using System.Collections.Generic;
using System.Threading.Tasks;
using uh.Entities.Models;
using uh.Interfaces.Common;

namespace uh.Interfaces.Entities
{
    public interface IUserDetailsRepository : IGenericRepository<UserDetails>
    {
        Task<IEnumerable<UserDetails>> GetAllUsers();

        Task<UserDetails> GetUserById(int id);

        void CreateUser(UserDetails userDetails);
        void UpdateUser(UserDetails userDetails);
        void DeleteUser(UserDetails userDetails);

        Task<UserDetails> GetUserByUserName(string userName);
    }
}
