using RabbitMQ.Client;
using SoundProdHelper.Common.Extensions;
using System;

namespace SoundProdHelper.Infrastructure.RabbitMQ
{
    public abstract class RabbitMQBase : IDisposable
    {
        private readonly string _hostName;

        private IConnection? connection;
        private IModel? chanel;

        protected RabbitMQBase(string hostName)
        {
            _hostName = hostName.ThrowIfNullOrEmpty(nameof(hostName));
        }

        public void Dispose()
        {
            connection.Dispose();
            chanel.Dispose();
        }

        protected IModel GetChannel()
        {
            if (connection == null)
            {
                var factory = new ConnectionFactory { 
                    HostName = _hostName, 
                    DispatchConsumersAsync = true 
                };

                connection = factory.CreateConnection();
                chanel = connection.CreateModel();
            }

            return chanel;
        }
    }
}
