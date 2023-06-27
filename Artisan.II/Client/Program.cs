using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Artisan.II.Client;
using Artisan.II.Client.Common.JsInterop.Default;
using Bogus;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Artisan.II.ServerAPI",
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddJsInterop();

builder.Services.AddScoped(_ => new Faker(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Artisan.II.ServerAPI"));

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();