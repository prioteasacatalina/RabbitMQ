namespace RabbitMq_Test.RabbitMQConsumer
{
    public interface IRabbitMQDemoQueueConsumer
    {
        LinkedInProfile LinkedInResponse(string message);
    }
}
