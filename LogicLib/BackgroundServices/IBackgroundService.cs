using System.Threading;
using System.Threading.Tasks;

namespace LogicLib.BackgroundServices
{
    public interface IBackgroundService
    {
        Task GetTask(CancellationToken cancellationToken = default);
    }
}