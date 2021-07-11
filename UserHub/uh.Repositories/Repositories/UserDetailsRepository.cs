using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uh.Entities.Context;
using uh.Entities.Models;
using uh.Repositories.Contracts;

namespace uh.Repositories.Repositories
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

        public async Task<bool> CheckUserNameExist(string userName, int userDetailsId)
        {                 
            var result = await GetAllUsers();

            if(userDetailsId == 0)
            {
                //Check while Create
                return result.Any(d => d.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            }

            //Check while Edit
            return result.Any(d => d.UserDetailsId != userDetailsId && d.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

       
    }
}
