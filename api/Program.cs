using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddServiceDefaults();

builder.AddAzureServiceBusClient(connectionName: "servicebus");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("sendmessage",async (ServiceBusClient sbClient) =>
{
    var sender = sbClient.CreateSender("messages");
    await sender.SendMessageAsync(new ServiceBusMessage("Hello Dave"));

    return Results.Ok("Message Sent");
});




app.Run();

