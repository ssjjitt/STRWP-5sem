using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseWebSockets();
// builder.WebHost.UseUrls("http://localhost:port") // - ����� ���� �� ������������ �� � ����� �� �������

app.MapGet("/", async (context) =>
{
    var htmlFilePath = "D:\\univer\\!���W�\\lab1b\\index.html";
    string htmlContent = await File.ReadAllTextAsync(htmlFilePath);
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(htmlContent);
});

app.Map("/ws", async (context) =>
{
    if (context.WebSockets.IsWebSocketRequest) // ������ ��������-�����������
    {
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync(); // ������� ��������� ����


        while (webSocket.State != WebSocketState.Closed && webSocket.State != WebSocketState.Aborted) 
        {
            var time = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            await webSocket.SendAsync(new ArraySegment<byte>(time, 0, time.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            await Task.Delay(2000);
        }
    }
    else 
    {
        context.Response.StatusCode = 400;
    }
});

await app.RunAsync();
