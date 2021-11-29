using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq_Test.RabbitMQConsumer
{
    public class RabbitMQResponseService : IRabbitMQResponseService
    {
        private readonly ConnectionFactory _factory;
        private IModel _channel;
        private IConnection _connection;
        public RabbitMQResponseService()
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("response-profile",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
        public void CreateMessage(LinkedInProfile message)
        {          
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish("", "response-profile", null, body);
        }
    }
}

