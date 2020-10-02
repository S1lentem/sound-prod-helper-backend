using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.Infrastructure.RabbitMQ
{
    public class RabbitMQPublisher : RabbitMQBase, IMessagePublisher
    {
        public RabbitMQPublisher(RabbitConfigurations configurations) : base(configurations.HostName)
        {
            
        }

        public Task Publish<T>(string key, T value)
        {
            var channel = GetChannel();

            var body = Encoding.UTF8.GetBytes(value.ToString());

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: key,
                body: body
            );

            return Task.CompletedTask;
        }
    }
}