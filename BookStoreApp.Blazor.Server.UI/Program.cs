using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Authentication;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using IAuthenticationService = BookStoreApp.Blazor.Server.UI.Services.Authentication.IAuthenticationService;
using AuthenticationService = BookStoreApp.Blazor.Server.UI.Services.Authentication.AutheticationService;
using BookStoreApp.Blazor.Server.UI.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Configurations;

namespace BookStoreApp.Blazor.Server.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5122"));

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();

            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                            p.GetRequiredService<ApiAuthenticationStateProvider>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}