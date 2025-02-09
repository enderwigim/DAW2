using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiluTienda;
using MiluTienda.Data;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);

// Habilitar la sesi�n
builder.Services.AddDistributedMemoryCache();  // Usamos memoria en cach� para la sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Define el tiempo de expiraci�n de la sesi�n
});


// Add services to the container. 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

// Registrar el contexto de la base de datos 
builder.Services.AddDbContext<TiendaContext>(options =>
options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Deshabilitar confirmaci�n de usuario. Configurar Identity para utilizar roles 
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// Configuraci�n de los servicios de ASP.NET Core Identity 
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings. Configuraci�n de las caracter�sticas de las contrase�as 
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    //options.Password.RequireNonAlphanumeric = true; 
    options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequireUppercase = true; 
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

// Usar sesi�n en la aplicaci�n
app.UseSession();

// Configure the HTTP request pipeline. 
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Crear los roles y el administrador predeterminados 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.InitializeAsync(services).Wait();
}

app.Run();