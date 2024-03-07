using SensorApi.Infrastructure.Queue.RabbitMQ;
using SensorApi.Infrastructure.Queue;
using RabbitMQ.Client;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();
        builder.AddMeter("Microsoft.AspNetCore.Hosting",
            "Microsoft.AspNetCore.Server.Kestrel");
        builder.AddView("http.server.request.duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = new double[] { 0, 0.005, 0.01, 0.025, 0.05,
                      0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 }
            });
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionFactory>(new ConnectionFactory()
{
    HostName = builder.Configuration.GetSection("QueueConfig:hostName").Value,
    UserName = builder.Configuration.GetSection("QueueConfig:userName").Value,
    Password = builder.Configuration.GetSection("QueueConfig:password").Value
});

builder.Services.AddTransient<IQueueClient>((ser) => new RabbitMQQueueClient(ser.GetService<IConnectionFactory>(), builder.Configuration.GetSection("QueueConfig:queue").Value));


var app = builder.Build();

app.MapPrometheusScrapingEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
