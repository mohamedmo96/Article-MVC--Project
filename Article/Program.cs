using Article.Code;
using Article.core;
using Article.Data;
using Article.Date;
using Article.Date.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Article
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

           builder.Services.AddSingleton<IDataHelper<Product> ,ProductEntity>() ;


            builder.Services.AddAuthorization(op=>
            {
                op.AddPolicy("User", p => p.RequireClaim("User","User"));
                op.AddPolicy("Admin", p => p.RequireClaim("Admin","Admin"));
            }
            );

           builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddMvc(o=>o.EnableEndpointRouting=false) ;
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseRouting();
               
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}