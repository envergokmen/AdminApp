using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp
{
    public static class HostExtensions
    {
        public async static Task SetDefaultLang(this WebAssemblyHost host)
        {
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            var cultureLang = await localStorage.GetItemAsync<string>("BlazorCulture");

            CultureInfo culture;

            if(cultureLang != null)
            {
                culture = new CultureInfo(cultureLang);
            }
            else
            {
                culture = new CultureInfo("en-US");

            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

        }
    }
}
