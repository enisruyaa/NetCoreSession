using CoreSession_0.Models.ContextClasses;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer().UseLazyLoadingProxies());

builder.Services.AddDistributedMemoryCache(); // Eðer Sessin kompleks yapýlarla çalýþmak için ECtensin metdou ekleme durumuna maruz aklmýþþsa bu kod projeniziz hafýzayý daðýtýk sistemde tutarak daha saðlýklý bir çevre sunacaktýr.

builder.Services.AddSession(
    x =>
    {
        x.IdleTimeout = TimeSpan.FromMinutes(3);// Kiþinin boþ durma süresi, Eðer kullanýcý 3 dk boþ duursa Session yok olsun dedik.
        x.Cookie.HttpOnly = true;
        x.Cookie.IsEssential = true;
    });


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
