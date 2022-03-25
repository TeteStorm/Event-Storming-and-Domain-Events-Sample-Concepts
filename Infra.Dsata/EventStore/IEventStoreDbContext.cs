using EventStore.ClientAPI;
using System.Threading.Tasks;

namespace Infra.Data.EventStore
{
    public interface IEventStoreDbContext
    {
        Task<IEventStoreConnection> GetConnection();

        Task AppendToStreamAsync(params EventData[] events);
    }
}