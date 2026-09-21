using Microsoft.Azure.Cosmos;
using SupportWebApp.Services;
using SupportWebApp.Components;

var builder = WebApplication.CreateBuilder(args);
var cosmosConnectionString =
    builder.Configuration["CosmosDb:ConnectionString"]
    ?? throw new InvalidOperationException(
        "Cosmos DB connection string mangler."
    );

builder.Services.AddSingleton(new CosmosClient(cosmosConnectionString));

builder.Services.AddSingleton<CosmosDbService>(serviceProvider =>
{
    var cosmosClient = serviceProvider.GetRequiredService<CosmosClient>();

    return new CosmosDbService(
        cosmosClient,
        "IBasSupportDB",
        "ibassupport"
    );
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
