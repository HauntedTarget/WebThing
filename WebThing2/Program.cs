using WebThing2.Interfaces;
using WebThing2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Send in DAL as dependency
// transient = creates new object each time service requested
// scoped = instances created once per request, refresh with new instance
// singlton = always return same instance
//builder.Services.AddTransient<IDataAccessLayer, MovieListDAL>();
builder.Services.AddTransient<IDataAccessLayer, FavoriteMoviesDAL>();

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
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();
