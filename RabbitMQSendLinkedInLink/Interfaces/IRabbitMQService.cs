using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQSendLinkedInLink
{
    public interface IRabbitMQService
    {
        void CreateMessage(RabbitMQMessage message);
    }
}
