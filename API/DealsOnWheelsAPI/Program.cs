using DealsOnWheelsAPI.Data.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DealsOnWheelsAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DealsOnWheelsAPIContext")));

builder.Services.AddScoped<EfCoreUserRepository>();
builder.Services.AddScoped<EfCoreVehicleRepository>();
builder.Services.AddScoped<EfCoreTransactionRepository>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(corsPolicyBuilder =>
   corsPolicyBuilder.WithOrigins("http://localhost:4200")
  .AllowAnyMethod()
  .AllowAnyHeader()
);

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