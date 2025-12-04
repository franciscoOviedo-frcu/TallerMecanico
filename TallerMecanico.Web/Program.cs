using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection; // <--- AGREGA ESTA LÍNEA OBLIGATORIAMENTE
using System;
using System.Net.Http;

namespace TallerMecanico.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddHttpClient("FipeApi", client =>
            {
                // Asegúrate de que esta sea la URL base correcta de la API que vas a usar
                client.BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/");
            });
            await builder.Build().RunAsync();
        }
    }
}
