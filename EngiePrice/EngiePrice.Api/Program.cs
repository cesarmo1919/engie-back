using EngiePrice.Application;
using EngiePrice.Infrastructure.Websockets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PricePublisher>();
builder.Services.AddSingleton<PriceUpdateService>();
builder.Services.AddSingleton<PriceWebSocketHandler>();

var app = builder.Build();


app.UseWebSockets();

app.Map("/ws",
async (HttpContext context) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();

        var priceService = context.RequestServices.GetRequiredService<PriceWebSocketHandler>();
        await priceService.HandleWebSocket(webSocket);
    }
});


app.Run();
