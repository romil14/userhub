using System.Threading.Tasks;

namespace uh.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserDetailsRepository UserDetails { get; }

        Task Save();
    }
}
