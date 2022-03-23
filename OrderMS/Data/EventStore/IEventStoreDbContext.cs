using EventStore.ClientAPI;
using System.Threading.Tasks;

namespace OrderMS.Data.EventStore
{
    public interface IEventStoreDbContext
    {
        Task<IEventStoreConnection> GetConnection();

        Task AppendToStreamAsync(params EventData[] events);
    }
}