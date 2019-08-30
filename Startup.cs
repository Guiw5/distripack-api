using AutoMapper;
using DistripackAPI.Helper;
using DistripackAPI.Persistence;
using DistripackAPI.Persistence.Repository;
using DistripackAPI.Persistence.Repository.Impl;
using DistripackAPI.Services;
using DistripackAPI.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DistripackAPI
{
    public class Startup
    {
        private readonly ILogger logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            this.logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICheckingAccountRepository, CheckingAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));

            logger.LogInformation("All services loaded");

            var connectionString = Configuration.GetConnectionString("AmazonDB");

            logger.LogInformation("Adding DB Context: {connectionString}", connectionString);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazonDB")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => { builder.AllowAnyOrigin(); builder.AllowAnyMethod(); builder.AllowAnyHeader(); }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation("In 'Development' environment");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("AllowAllOrigins");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
