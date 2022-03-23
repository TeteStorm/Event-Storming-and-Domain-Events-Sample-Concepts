using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderMS.Infrastructure.Services
{
    public interface IProducer<in TEvent>
    {
        Task SendAsync(IEnumerable<TEvent> events);

        Task SendAsync(TEvent @event);
    }
}
