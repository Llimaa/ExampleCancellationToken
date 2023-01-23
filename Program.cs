var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/with-cancellation-token", async (CancellationToken cancellationToken) => await ExampleWithCancellationToken(cancellationToken));

app.MapGet("/without-cancellation-token", async (CancellationToken cancellationToken) => await ExampleWithoutCancellationToken());

app.Run();


async Task ExampleWithCancellationToken(CancellationToken cancellationToken) 
{
    app.Logger.LogInformation("Example With Cancellation Token");
    app.Logger.LogInformation($"Request started at: {DateTime.Now.ToLongDateString()}");

    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        app.Logger.LogInformation($"Processing for: {i}");
    }

    app.Logger.LogInformation($"Request Completed at: {DateTime.Now.ToLongDateString()}");
}

async Task ExampleWithoutCancellationToken() 
{
    app.Logger.LogInformation("Example Without Cancellation Token");
    app.Logger.LogInformation($"Request started at: {DateTime.Now.ToLongDateString()}");
    
    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        app.Logger.LogInformation($"Processing for: {i}");
    }

    app.Logger.LogInformation($"Request Completed at: {DateTime.Now.ToLongDateString()}");
}