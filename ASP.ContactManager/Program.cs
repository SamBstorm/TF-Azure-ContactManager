using D = DAL.ContactManager;
using B = BLL.ContactManager;
using Common.ContactManager.Services;
using ASP.ContactManager.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region SessionState
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "AspNetMVC.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionManager>();
#endregion

#region Injections de dépendance
builder.Services.AddScoped<ICategoryRepository<D.Entities.Categorie>, D.Services.CategorieService>();
builder.Services.AddScoped<ICategoryRepository<B.Entities.Category>, B.Services.CategoryService>();
builder.Services.AddScoped<IUserRepository<D.Entities.Utilisateur>, D.Services.UtilisateurService>();
builder.Services.AddScoped<IUserRepository<B.Entities.User>, B.Services.UserService>();
builder.Services.AddScoped<IContactRepository<D.Entities.Contact>, D.Services.ContactService>();
builder.Services.AddScoped<IContactRepository<B.Entities.Contact>, B.Services.ContactService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
#region SessionState
app.UseSession();
app.UseCookiePolicy();
#endregion

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
