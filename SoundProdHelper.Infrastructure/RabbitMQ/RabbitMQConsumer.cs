using AutoMapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Infrastructure.RabbitMQ.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace SoundProdHelper.Infrastructure.RabbitMQ
{
    public abstract class RabbitMQConsumer : RabbitMQBase
    {
        private readonly EventingBasicConsumer _consumer;
        protected readonly IMapper Mapper;

        public RabbitMQConsumer(RabbitConfigurations configurations, IMapper mapper) : 
            base(configurations.HostName)
        {
            Mapper = mapper.ThrowIfNull(nameof(mapper));

            var channel = GetChannel();
            _consumer = new EventingBasicConsumer(channel);
        }
        

        public void AddSubscription<T>(string key)
            where T: IMessageSubscriber
        {
            _consumer.Received += (ch, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());


            };
        }

        public async Task HandleKeyAsync<T>()
        {
            var chanel = GetChannel();

            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += async (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                await HandleMessageAsync(Mapper.Map<T>(message));

                ((EventingBasicConsumer)ch).Model.BasicAck(ea.DeliveryTag, false);
            };

           

        }

        protected abstract Task HandleMessageAsync<T>(T message);
    }
}