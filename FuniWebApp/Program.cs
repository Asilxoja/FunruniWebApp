using FuniWebApp.Areas.Admin.Data.Interfaces;
using FuniWebApp.Areas.Admin.Services;
using FuniWebApp.Data;
using FuniWebApp.Data.Interfaces;
using FuniWebApp.Data.Services;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
				.AddNToastNotifyToastr(new ToastrOptions()
				{
					ProgressBar = true,
					PositionClass = ToastPositions.TopRight,
					TimeOut = 5000
				});
builder.Services.AddDbContext<FuniWebDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));

builder.Services.AddTransient<ICategoryInterface, CategoryServices>();
builder.Services.AddTransient<IFuniInterface, FuniServices>();
builder.Services.AddTransient<IFileInterface, FileService>();

//->->->->->->->Danger zone <-<-<-<-<-<-
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Funi}/{action=Index}/{id?}"
          );
app.UseNToastNotify();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();