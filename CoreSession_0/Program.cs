using CoreSession_0.Models.ContextClasses;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer().UseLazyLoadingProxies());

builder.Services.AddDistributedMemoryCache(); // E�er Sessin kompleks yap�larla �al��mak i�in ECtensin metdou ekleme durumuna maruz aklm���sa bu kod projeniziz haf�zay� da��t�k sistemde tutarak daha sa�l�kl� bir �evre sunacakt�r.

builder.Services.AddSession(
    x =>
    {
        x.IdleTimeout = TimeSpan.FromMinutes(3);// Ki�inin bo� durma s�resi, E�er kullan�c� 3 dk bo� duursa Session yok olsun dedik.
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
