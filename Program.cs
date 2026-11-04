using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PortfolioContext") ?? throw new InvalidOperationException("Connection string 'PortfolioContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IGitHubService, GitHubService>(
    (serviceProvider, client) =>
    {
        var configuration =
            serviceProvider.GetRequiredService<IConfiguration>();

        var token = configuration["GitHub:Token"]
            ?? throw new InvalidOperationException(
                "GitHub token is not configured.");

        client.BaseAddress = new Uri("https://api.github.com/");

        client.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp");

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                "application/vnd.github+json"));
    });

builder.Services.AddScoped<ProjectSyncService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/api/themes", (IWebHostEnvironment env) =>
{
    var assetsPath = Path.Combine(env.WebRootPath, "assets");

    var themes = Directory.GetDirectories(assetsPath)
        .ToDictionary(
            directory => Path.GetFileName(directory),
            directory => Directory.GetFiles(directory)
                .Where(file =>
                    new[] { ".png", ".jpg", ".jpeg", ".gif", ".webp", ".svg" }
                    .Contains(Path.GetExtension(file).ToLowerInvariant()))
                .ToDictionary(
                    file => Path.GetFileNameWithoutExtension(file),
                    file => $"/assets/{Path.GetFileName(directory)}/{Path.GetFileName(file)}"
                )
        );

    return Results.Json(themes);
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
