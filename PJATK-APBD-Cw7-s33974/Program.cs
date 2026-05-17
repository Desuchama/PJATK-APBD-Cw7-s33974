using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PJATK_APBD_Cw7_s33974.Infrastructure;
using PJATK_APBD_Cw7_s33974.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPCsService, PCsService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "APBD cw7"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();