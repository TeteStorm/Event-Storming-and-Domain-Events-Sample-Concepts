using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Crosscutting.Services
{
    public interface IProducer<in TEvent>
    {
        Task SendAsync(IEnumerable<TEvent> events);

        Task SendAsync(TEvent @event);
    }
}
