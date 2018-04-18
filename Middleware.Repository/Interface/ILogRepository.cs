using System.Threading.Tasks;

namespace Middleware.Repository.Interface
{
    public interface ILogRepository
    {
        Task GravarAsync(string Mesangem);
    }
}
