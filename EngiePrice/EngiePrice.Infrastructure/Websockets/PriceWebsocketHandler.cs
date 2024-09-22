using System;
using System.Net.WebSockets;
using System.Text;
using EngiePrice.Application;
using Newtonsoft.Json;

namespace EngiePrice.Infrastructure.Websockets;

public class PriceWebSocketHandler
{
    private readonly PriceUpdateService _priceUpdateService;
    private readonly List<WebSocket> _sockets = new();

    public PriceWebSocketHandler(PriceUpdateService priceUpdateService)
    {
        _priceUpdateService = priceUpdateService;
    }

    public async Task HandleWebSocket(WebSocket socket)
    {
        _sockets.Add(socket);

        while (socket.State == WebSocketState.Open)
        {
            _priceUpdateService.StartPriceUpdates(async (pair) =>
            {
                var message = JsonConvert.SerializeObject(pair);
                var bytes = Encoding.UTF8.GetBytes(message);

                await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
            });
        }

        _sockets.Remove(socket);
    }
}
