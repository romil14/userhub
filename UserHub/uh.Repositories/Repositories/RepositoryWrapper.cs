using System.Threading.Tasks;
using uh.Entities.Context;
using uh.Repositories.Contracts;

namespace uh.Repositories.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IUserDetailsRepository _userDetails;

        public IUserDetailsRepository UserDetails
        {
            get
            {
                if(_userDetails == null)
                {
                    _userDetails = new UserDetailsRepository(_repositoryContext);
                }

                return _userDetails;
            }
        }
        

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
