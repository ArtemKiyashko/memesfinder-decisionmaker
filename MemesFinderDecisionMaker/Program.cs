using Azure.Monitor.OpenTelemetry.Exporter;
using MemesFinderDecisionMaker.Extentions;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Azure.Core.Serialization;
using OpenTelemetry.Trace;

var builder = FunctionsApplication.CreateBuilder(args);

AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource("Azure.Messaging.ServiceBus.*"))
    .UseFunctionsWorkerDefaults()
    .UseAzureMonitorExporter();

builder.Services.Configure<WorkerOptions>(options =>
    options.Serializer = new NewtonsoftJsonObjectSerializer());

builder.Services.AddServiceTxtMessageClient(builder.Configuration);
builder.Services.AddDecisionManager(builder.Configuration);

builder.Build().Run();
