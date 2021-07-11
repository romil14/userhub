using Microsoft.EntityFrameworkCore;
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

        public void CreateUser(UserDetails userDetails)
        {
            Create(userDetails);
        }

        public void DeleteUser(UserDetails userDetails)
        {
            Delete(userDetails);
        }

        public void UpdateUser(UserDetails userDetails)
        {
            Update(userDetails);
        }

        public async Task<IEnumerable<UserDetails>> GetAllUsers()
        {
            return await FindAll().OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<UserDetails> GetUserById(int id)
        {
            return await FindByCondition(d => d.UserDetailsId == id).FirstOrDefaultAsync();
        }

        public async Task<UserDetails> GetUserByUserName(string userName)
        {
            return await FindByCondition(d => string.Equals(d.UserName, userName, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();       
        }

       
    }
}
