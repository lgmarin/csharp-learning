using ConsumeApi.Services.WeatherService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddHttpClient("weather", c=>
//     c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json")
// );

// Insert a Type Registration for the ADDHTTP... <specify the interface, and the class that implements it>
builder.Services.AddHttpClient<IWeatherService, WeatherService>("weather", c=>
    c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json")
);


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
