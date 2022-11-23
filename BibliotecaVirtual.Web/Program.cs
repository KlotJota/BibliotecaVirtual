using BibliotecaVirtual.Web;
using BibliotecaVirtual.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var urlBase = "https://localhost:7221";

builder.Services.AddScoped(sp => new HttpClient 
{ BaseAddress = new Uri(urlBase) });

builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ILocacaoService, LocacaoService>();

await builder.Build().RunAsync();
