using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace liveriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSocketController : ControllerBase
    {
        [HttpGet("connect")]
        public async Task ConnectWebSocket(CancellationToken cancellationToken)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await HandleWebSocketConnection(webSocket, cancellationToken);
            }
            else
            {
                HttpContext.Response.StatusCode = 400; // Bad Request
            }
        }

        private async Task HandleWebSocketConnection(WebSocket webSocket, CancellationToken cancellationToken)
        {
            var buffer = new byte[1024];

            while (!cancellationToken.IsCancellationRequested && webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Message reçu : {receivedMessage}");

                    // Exemple de réponse
                    string responseMessage = "Message reçu : " + receivedMessage;
                    var responseBuffer = Encoding.UTF8.GetBytes(responseMessage);
                    await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, result.EndOfMessage, cancellationToken);
                }
            }
        }
    }
}
