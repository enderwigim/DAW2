using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcAgenda.Data;

var builder = WebApplication.CreateBuilder(args);

string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
if (string.IsNullOrEmpty(userProfile))
{
    userProfile = Directory.GetCurrentDirectory();
}

string dbFolderPath;

if (Directory.Exists(Path.Combine(userProfile, "REPOS")))
{
    dbFolderPath = Path.Combine(userProfile, "REPOS", "DAW2", "servidor", "DB");
} else
{
    throw new DirectoryNotFoundException("No se encontró la carpeta 'REPOS'");
}

if (!Directory.Exists(dbFolderPath)) {
    Directory.CreateDirectory(dbFolderPath);
}

var dbFileName = "aspnet-MvcAgenda-e0e8cf12-7ab4-4235-a9ec-07e1ddccd3a5.mdf";
var dbPath = Path.Combine(dbFolderPath, dbFileName);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionString = $"Server=(localdb)\\MSSQL15;AttachDbFileName={dbPath};Database=aspnet-MvcAgenda;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<MvcAgendaContexto>(options =>
 options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
