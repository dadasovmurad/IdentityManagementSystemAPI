using IdentityManagementSystemAPI.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddApplicationServices();

services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));


services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();


services.AddApplicationServices();


var app = builder.Build();
app.MapControllers();

app.Run();