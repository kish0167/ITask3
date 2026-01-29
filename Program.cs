using System.Numerics;

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
    if (!BigInteger.TryParse(request.Query["x"], out BigInteger x)) return errorMessage;
    if (!BigInteger.TryParse(request.Query["y"], out BigInteger y)) return errorMessage;
    return Lcm(x, y).ToString();
}); 

app.Run();

static BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        BigInteger temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static BigInteger Lcm(BigInteger a, BigInteger b)
{
    return a * b > 0 ? a * b: -a * b / Gcd(a, b);
}