using RabbitMQ.Client;

namespace SensorApi.Infrastructure.Queue
{
    public interface IQueueClient
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
        string GetQueueName();
        void Publish<T>(string exchangeName, string routingKey, T newEvent);
    }
}
