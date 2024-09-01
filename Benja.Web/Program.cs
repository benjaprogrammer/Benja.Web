using Benja.Library;
using Benja.Model;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HTTP>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(option =>
option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver()
);
var app = builder.Build();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider=new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(),"\\wwwroot\\image")),
//    RequestPath= "wwwroot\\image"
//});
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authen}/{action=Login}/{id?}");

app.Run();
