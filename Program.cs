using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using PizzaApp.Data;
using PizzaApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(navigationManager.BaseUri)
    };
});

// register app state services
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

/* === SEED + MIGRATE (BURASI) === */
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaContext>();

    context.Database.Migrate();      // tabloları/migration'ı uygula
    PizzaContext.SeedData(context);  // veri ekle (Specials.Any() varsa eklemez)
}
/* =============================== */

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
