using D = DAL_Fake.ContactManager;
using B = BLL.ContactManager;
using Common.ContactManager.Entities;
using Common.ContactManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryRepository<D.Entities.Categorie>, D.Services.CategoryService>();
builder.Services.AddScoped<ICategoryRepository<B.Entities.Category>, B.Services.CategoryService>();
builder.Services.AddScoped<IContactRepository<D.Entities.Contact>, D.Services.ContactService>();
builder.Services.AddScoped<IContactRepository<B.Entities.Contact>, B.Services.ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
