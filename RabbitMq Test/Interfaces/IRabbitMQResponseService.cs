using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq_Test.RabbitMQConsumer
{
    public interface IRabbitMQResponseService
    {
        void CreateMessage(LinkedInProfile message);
    }
}
