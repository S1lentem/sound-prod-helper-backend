using System.Threading.Tasks;

namespace SoundProdHelper.Infrastructure.RabbitMQ.Interfaces
{
    public interface IMessageSubscriber
    {
        Task HandleActionAsync(string message);
    }
}
