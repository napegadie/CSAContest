using Azure.Identity;
using CSAContestWeb.Extension;
using CSAContestWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(builderazure =>
{
    builderazure.AddBlobServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage"]);

    builderazure.AddSearchClient(builder.Configuration.GetSection("SearchClient"));
    builderazure.AddSearchIndexClient(builder.Configuration.GetSection("SearchClient"));

     // Use DefaultAzureCredential by default
    builderazure.UseCredential(new DefaultAzureCredential());

});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IExtensionRepo, ExtensionRepo>();

builder.Services.AddDbContext<DocSearchDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDocumentModelRepo, DocumentModelRepo>();

builder.Services.AddHttpClient("BookLibApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("BookLibApiUrl").Value);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
