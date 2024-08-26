using MyCustomUmbracoProject.Interfaces;
using MyCustomUmbracoProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddUmbraco(builder.Environment, builder.Configuration)
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

// Add SpaStaticFiles service to serve Vite build files
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp\\dist\\umbraco-app";
});

builder.Services.AddScoped<IContentService, ContentService>();

builder.Services.AddEndpointsApiExplorer();// Registers the endpoints for API Explorer
builder.Services.AddSwaggerGen();// Registers the Swagger generator

var app = builder.Build();

// Configure the middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("localhost:44320/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });
// Serve the Vite files
app.UseSpaStaticFiles();


// Set up default file handling for SPA
app.UseSpaStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "ClientApp\\dist\\umbraco-app")),
    RequestPath = "",
    OnPrepareResponse = ctx =>
    {
        // Set cache control header to allow caching of static files
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000,immutable");
    }
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // Handle fallback route for SPA
    endpoints.MapFallbackToFile("index.html");
});

// SPA configuration for development
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    if(app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");// Assuming Vite dev server runs on this port
    }
});



await app.RunAsync();




// the main program.cs 
/*
 WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
 */