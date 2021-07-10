using System.Threading.Tasks;

namespace uh.Interfaces.Entities
{
    public interface IRepositoryWrapper
    {
        IUserDetailsRepository UserDetails { get; }

        Task Save();
    }
}
