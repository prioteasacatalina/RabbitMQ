using MassTransit;
using Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MassTransitInventory
{
    internal class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            await Console.Out.WriteLineAsync(context.Message.LinkedInLink);
            await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(new LinkedInProfile()));
            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("amqp://guest:guest@localhost:5672");
            });

            bus.Start();

            await bus.Publish<LinkedInProfile>(new LinkedInProfile());

        }
    }
}