using AdminApp.Services;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            if (builder.HostEnvironment.IsDevelopment())
            {
                StateContainer.basePath = "";
            }
            else
            {
                StateContainer.basePath = "";
            }

            var services = builder.Services;

            builder.Services.AddTransient(sp => new HttpClient(new DefaultBrowserOptionsMessageHandler(new WebAssemblyHttpHandler()) // or new HttpClientHandler() in .NET 5.0
            {
                DefaultBrowserRequestCache = BrowserRequestCache.NoStore,
                DefaultBrowserRequestCredentials = BrowserRequestCredentials.Include,
                DefaultBrowserRequestMode = BrowserRequestMode.Cors,
            })
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            services.AddScoped<StateContainer>();

            services.AddBlazoredSessionStorage();
            services.AddBlazoredLocalStorage();


            await builder.Build().RunAsync();
        }
    }
}
