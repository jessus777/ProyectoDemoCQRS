using Client_Blazor_Front_End;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
builder.UseServicesData();
builder.UseServicesValidation();
await builder.Build().RunAsync();
