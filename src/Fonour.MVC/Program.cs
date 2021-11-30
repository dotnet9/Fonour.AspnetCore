using Fonour.Application;
using Fonour.Application.DepartmentApp;
using Fonour.Application.MenuApp;
using Fonour.Application.RoleApp;
using Fonour.Application.UserApp;
using Fonour.Domain.IRepositories;
using Fonour.EntityFrameworkCore;
using Fonour.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//��ȡ���ݿ������ַ���
var sqlConnectionString = builder.Configuration.GetConnectionString("Default");

//��������������
builder.Services.AddDbContext<FonourDbContext>(options =>
	options.UseSqlServer(sqlConnectionString)); //options.UseSqlite(sqlConnectionString));
builder.Services.AddAutoMapper(typeof(FonourMapper));
//����ע��
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuAppService, MenuAppService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentAppService, DepartmentAppService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleAppService, RoleAppService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x => x.LoginPath = "/Login/Index");

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
//���������쳣����
	app.UseDeveloperExceptionPage();
else
//���������쳣����
	app.UseExceptionHandler("/Shared/Error");
//ʹ�þ�̬�ļ�
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
});

//Session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	"default",
	"{controller=Home}/{action=Index}/{id?}");

app.Run();