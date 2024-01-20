using Microsoft.EntityFrameworkCore;
using MedicalJournalApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalJournalApp;

var builder = WebApplication.CreateBuilder(args);
{
    string connection = builder.Configuration.GetConnectionString("DefaultConnection"); 
    builder.Services.AddDbContext<ArticleContext>(options => options.UseSqlServer(connection)); 
    builder.Services.AddTransient<IArticleRepository, EFArticleRepository>();
    builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
    builder.Services.AddMvc();
    builder.Services.AddRazorPages(); 
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        SeedData.Initialize(services);
    }

    app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    app.UseDefaultFiles(); 
    app.UseStaticFiles();
    app.UseRouting();
    app.MapRazorPages();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: null,
            template: "{category}/Page{productPage:int}",
            defaults: new { controller = "Home", action = "Index" });

        routes.MapRoute(
            name: null,
            template: "Page{productPage:int}",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(
            name: null,
            template: "{category}",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(
            name: null,
            template: "",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
    });
}

app.Run();