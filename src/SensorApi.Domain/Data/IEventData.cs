using SensorApi.Domain.Entities;

namespace SensorApi.Domain.Data
{
    public interface IEventData
    {
        Task Insert(Event oEvent);
    }
}
