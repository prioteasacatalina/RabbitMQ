using MassTransit;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransitOrder
{
    public class GetProfileConsumer : IConsumer<LinkedInProfile>
    {
        public async Task Consume(ConsumeContext<LinkedInProfile> context)
        {
            await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(context.Message));
        }
    }
}
