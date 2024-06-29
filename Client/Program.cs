using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ESProjeto.Client.Services.CompetitionServices;
using ESProjeto.Client.Services.UserServices;
using ESProjeto.Client.Services.MovieServices;
using ESProjeto.Client.Services.CrewMemberServices;
using ESProjeto.Client.Services.CategoryServices;

namespace ESProjeto.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<MovieService>();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ICompetitionService, CompetitionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICrewMemberService, CrewMemberService>();

            builder.Services.AddHttpClient("ESProjeto.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ESProjeto.ServerAPI"));
            
            builder.Services.AddApiAuthorization();
            builder.Services.AddBlazorise(options =>
                    {
                        options.Immediate = true;
                    })
                    .AddBootstrapProviders()
                    .AddFontAwesomeIcons();

            await builder.Build().RunAsync();

        }
    }
}