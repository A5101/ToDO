using BlazorApp2.Server.Domain;
using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Server.Domain.Repositories.EntityFramework;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;

namespace BlazorApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            
            builder.Services.AddTransient<IElementRepository, EFElementRepository>();
            builder.Services.AddTransient<IRowRepository, EFRowRepository>();
            builder.Services.AddTransient<IFormRepository, EFFormRepository>();
            builder.Services.AddTransient<DataManager>();

            builder.Services.AddDbContext<AppDbContext>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}