using System.Collections.Generic;
using uh.Entities.Models;
using uh.Interfaces.Common;

namespace uh.Interfaces.Entities
{
    public interface IUserDetailsRepository : IGenericRepository<UserDetails>
    {
        IEnumerable<UserDetails> GetAllUsers();
    }
}
