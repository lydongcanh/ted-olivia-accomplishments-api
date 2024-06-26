using System.Text.Json;
using System.Text.Json.Serialization;
using Hangfire;
using Microsoft.OpenApi.Models;
using TedOliviaAccomplishmentsApi.Core.Application.Services;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Hangfire;
using ApplicationAccomplishmentService = TedOliviaAccomplishmentsApi.Core.Application.Services.AccomplishmentService;
using GrpcAccomplishmentService = TedOliviaAccomplishmentsApi.ServiceHost.Services.AccomplishmentService;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to support both HTTP/1.1 and HTTP/2
builder.WebHost.ConfigureKestrel(options =>
{
    // Listen on port 5275 for HTTP
    options.ListenAnyIP(5275, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
    });
});

// Add services to the container.
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ted-olivia-accomplishments-api",
        Description = "Backend service for the 'Olivia & Ted Accomplishments' site",
        Version = "v1"
    });
});
builder.Services.AddHangFire();
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseUpper)));

builder.Services.AddScoped<IAccomplishmentService, ApplicationAccomplishmentService>();
builder.Services.AddScoped<IProductivityLogService, ProductivityLogService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.MapHangfireDashboard();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Redirect HTTP to HTTPS
    app.UseHttpsRedirection();
}

app.UseRouting();
app.MapGrpcService<GrpcAccomplishmentService>();

app.MapControllers();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();