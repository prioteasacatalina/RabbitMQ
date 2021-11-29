using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq_Test.RabbitMQConsumer
{
    public class RabbitMQDemoQueueConsumer : IRabbitMQDemoQueueConsumer
    {
        private readonly ConnectionFactory _factory;
        private readonly IRabbitMQResponseService _rabbitMQResponseService;
        private IModel _channel;
        private IConnection _connection;

        public RabbitMQDemoQueueConsumer(IRabbitMQResponseService rabbitMQResponseService)
        {
            _rabbitMQResponseService = rabbitMQResponseService;
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("demo-queue",
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

                // Async start linkedinScraping based on Body 
                var a = new LinkedInProfile();
                string b = JsonConvert.SerializeObject(a);
                Console.WriteLine(b);


                // Success/Fail => Publish pe Linkedin-Scraping-Queue 
                _rabbitMQResponseService.CreateMessage(a);             
            };

            _channel.BasicConsume("demo-queue", true, consumer);
        }

        public LinkedInProfile LinkedInResponse(string message)
        {
            return new LinkedInProfile();

        }
    }
}
