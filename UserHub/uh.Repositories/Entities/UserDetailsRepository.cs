using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uh.Entities.Context;
using uh.Entities.Models;
using uh.Interfaces.Entities;
using uh.Repositories.Common;

namespace uh.Repositories.Entities
{
    public class UserDetailsRepository : GenericRepository<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<UserDetails> GetAllUsers()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }
    }
}
