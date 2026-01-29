var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/simerkish_gmail_com", (HttpRequest request) =>
{
    const string errorMessage = "NaN";
    if (!Int32.TryParse(request.Query["x"], out int x)) return errorMessage;
    if (!Int32.TryParse(request.Query["y"], out int y)) return errorMessage;
    return Lcm(x, y).ToString();
}); 

app.Run();

static long Gcd(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static long Lcm(int a, int b)
{
    return Math.Abs((long)a * b) / Gcd(a, b);
}