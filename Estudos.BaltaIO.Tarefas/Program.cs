using System.Text.Json.Serialization;
using Estudos.BaltaIO.Tarefas.Data;
using Microsoft.EntityFrameworkCore;
using Telluria.Utils.Crud;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dbVersion = builder.Configuration.GetSection("DataBaseVersion");
var version = new Version(
  dbVersion.GetValue<int>("Major"),
  dbVersion.GetValue<int>("Minor"),
  dbVersion.GetValue<int>("Build")
);

// Add CORS policy
builder.Services.AddCors(options =>
  options.AddPolicy("AllowAllOriginsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Connection of DB
builder.Services.AddDbContext<DataContext>(options => options
  .UseMySql(connectionString, new MySqlServerVersion(version)));
builder.Services.AddScoped<DbContext, DataContext>();
builder.Services.AddCrud();

// Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
  app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
