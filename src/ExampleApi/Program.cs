using LoggingUtility;

var builder = WebApplication.CreateBuilder(args);

////builder.Logging.AddApplicationInsightsLogging(builder.Configuration);

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry(isDevelopment: builder.Environment.IsDevelopment());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
