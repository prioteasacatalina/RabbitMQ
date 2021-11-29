using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSendLinkedInLink
{
    public class RabbitMQGetProfileService : IRabbitMQGetProfileService
    {
        private readonly ConnectionFactory _factory;
        private readonly IModel _channel;
        private readonly IConnection _connection;
        public RabbitMQGetProfileService()
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
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                //citire body mesaj
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                //procesare
                Console.WriteLine(message);
            };

            _channel.BasicConsume("response-profile", true, consumer);
        }
    }
}
