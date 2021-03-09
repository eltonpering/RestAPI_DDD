using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceCustomer;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Web_ECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc(
                   "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "C#/RESTFul API Challenge",
                        Description = "Desafio RESTFul API com Elton A Pering",
                        Contact = new OpenApiContact
                        {
                            Name = "Elton A Pering",
                            Email = "eltonapering@gmail.com"
                        }
                    });
           });

            services.AddDbContext<ContextBase>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers()
                  .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.ReferenceLoopHandling
                      = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                  });


            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddEntityFrameworkStores<ContextBase>()
                  .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();

            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<ICustomer, RepositoryCustomer>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<InterfaceCustomerApp, AppCustomer>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServiceCustomer, ServiceCustomer>();


            //JWT
            //adiciona o manipulador de autenticacao e define o 
            //esquema de autenticacao usado : Bearer
            //valida o emissor, a audiencia e a chave
            //usando a chave secreta valida a assinatura
            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidAudience = Configuration["TokenConfiguration:Audience"],
                     ValidIssuer = Configuration["TokenConfiguration:Issuer"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(Configuration["Jwt:key"]))
                 });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UsuarioAPI",
                    policy => policy.RequireClaim("UsuarioAPINumero"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Swagger
            app.UseSwagger();

            //Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Elton A Pering");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //adiciona o middleware para redirecionar para https
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //adiciona o middleware de roteamento 
            app.UseRouting();

            //adiciona o middleware de autenticacao
            app.UseAuthentication();

            //adiciona o middleware que habilita a autorizacao
            app.UseAuthorization();


            //Adiciona o middleware que executa o endpoint do request atual
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
