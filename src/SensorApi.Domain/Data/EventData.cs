//using SensorApi.Domain.Entities;
//using Vibrant.InfluxDB.Client;

//namespace SensorApi.Domain.Data
//{
//    public class EventData : IEventData
//    {

//        private IInfluxClient _client;

//        public EventData(IInfluxClient client)
//        {
//            this._client = client;
//        }

//        public async Task Insert(Event oEvent)
//        {
//            InfluxResult result = await this._client.CreateDatabaseAsync("sensors");
//            await this._client.WriteAsync("sensor-events", "events", new Event[] { oEvent });
//        }
//    }
//}
