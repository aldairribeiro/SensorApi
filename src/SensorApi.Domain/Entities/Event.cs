using System;
using System.Collections.Generic;
using System.Text;
using Vibrant.InfluxDB.Client;

namespace SensorApi.Domain.Entities
{
    public class Event
    {
        [InfluxTimestamp]
        public DateTime Timestamp { get; set; }

        [InfluxTag("regiao")]
        public required string Region { get; set; }

        [InfluxTag("sensor")]
        public required string Sensor { get; set; }

        [InfluxField("valor")]
        public required string Value { get; set; }

        [InfluxField("erro")]
        public bool Error { get; set; }
    }
}
