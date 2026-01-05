var builder = DistributedApplication.CreateBuilder(args);

var serviceBus = builder.AddAzureServiceBus("servicebus").RunAsEmulator(emulator =>
{
    emulator.WithLifetime(ContainerLifetime.Persistent);
});

serviceBus.AddServiceBusQueue("messages");

builder.AddProject<Projects.api>("api").WithReference(serviceBus).WaitFor(serviceBus);
builder.AddAzureFunctionsProject<Projects.function>("function").WithReference(serviceBus).WaitFor(serviceBus);

builder.Build().Run();
