using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddAuthentication(options => {
      options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.RequireAuthenticatedSignIn = true;
  })
  .AddCookie(options => {
      options.Cookie.Name = "_Auth";
      options.LoginPath = "/";
      options.LogoutPath = "/User/Logout";
      options.AccessDeniedPath = "/Error";
      options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
  });

builder.Services
  .AddAuthorization(options => {
      options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
  });

builder.Services.AddSession(options =>
{
    // Konfigurasi opsi session
    options.IdleTimeout = TimeSpan.FromHours(8); // waktu session expire
    options.Cookie.HttpOnly = true; // memastikan cookie hanya dapat diakses melalui HTTP(S)
    options.Cookie.IsEssential = true; // cookie session dianggap penting, sehingga tidak akan dihapus meskipun browser melakukan clear cache
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
