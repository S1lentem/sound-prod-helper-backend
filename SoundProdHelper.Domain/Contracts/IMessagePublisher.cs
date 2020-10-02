using System.Threading.Tasks;

namespace SoundProdHelper.Domain.Contracts
{
    public interface IMessagePublisher
    {
        Task Publish<T>(string key, T value);
    }
}