using Newtonsoft.Json;

namespace SensorApi.Domain.Command
{
        public class NewEventCommand
        {
            [JsonProperty("timestamp")]
            public long TimeStamp { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("valor")]
            public string Value { get; set; }
        }
}
