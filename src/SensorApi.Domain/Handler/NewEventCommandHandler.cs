using SensorApi.Domain.Command;
using SensorApi.Domain.Data;
using SensorApi.Domain.Entities;
using SensorApi.Infrastructure.Extensions;
using SensorApi.Infrastructure.Handler;

namespace SensorApi.Domain.Handler
{
    public class NewEventCommandHandler : IHandler<NewEventCommand>
    {

        private IEventData _eventData;

        public NewEventCommandHandler(IEventData eventData)
        {
            this._eventData = eventData;
        }

        public async Task Handle(NewEventCommand command)
        {
            Event oEvent = new Event()
            {
                Region = string.Join(".", command.Tag.Split(".")[0], command.Tag.Split(".")[1]),
                Sensor = command.Tag.Split(".")[2],
                Timestamp = command.TimeStamp.FromUnixTime(),
                Value = command.Value,
                Error = string.IsNullOrEmpty(command.Value)
            };

            await this._eventData.Insert(oEvent);
        }
    }
}
