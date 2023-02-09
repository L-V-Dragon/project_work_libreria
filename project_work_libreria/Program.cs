using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibreriaContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibreriaContext>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services
    .GetService<IServiceScopeFactory>()?
    .CreateScope();

if (scope is not null) {
    using (scope) {
        var RoleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
        if (RoleManager.Roles.Count() == 0) {

            await RoleManager.CreateAsync(new IdentityRole("Admin"));
            await RoleManager.CreateAsync(new IdentityRole("User"));
        }

    }
}

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
// codice da aggiungere dopo app.UseRouting()
app.UseAuthentication();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Cliente}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
