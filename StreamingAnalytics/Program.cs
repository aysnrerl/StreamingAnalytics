using StreamingAnalytics.Context;
using StreamingAnalytics.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Dependency Injection (DI) Kayıtları ─────────────────────────
// 📌 NE YAPAR?
// Controller'lar DapperContext ve StreamingService'i "new" ile oluşturmaz.
// ASP.NET bunu otomatik yapar — biz sadece burada kayıt ediyoruz.

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<StreamingService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Varsayılan sayfa Dashboard olsun
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
