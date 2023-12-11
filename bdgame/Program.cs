using bdgame.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<EnglishContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromHours(1);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseSession();

app.Use(async (context, next) =>
{
  context.Response.Headers.Add("X-Xss-Protection", "1");
  context.Response.Headers.Add("X-Frame-Options", "DENY");
  context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
  await next();

  if (context.Response.StatusCode == 404)
  {
    context.Response.Redirect("/Home/Error?statusCode=" + context.Response.StatusCode);
  }

});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
