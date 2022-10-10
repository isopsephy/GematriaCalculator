using GematriaCalculator.Data;
using GematriaCalculator.Filters;
using System.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StrongsDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<DataFilter>();
builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    options.Filters.Add<DataFilter>();
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();