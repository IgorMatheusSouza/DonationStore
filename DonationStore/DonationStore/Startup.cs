using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MediatR;
using DonationStore.Domain.Entities;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.Commands.Authentication;
using DonationStore.Domain.Handlers.Commands.Users;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Repository.Repositories;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Factories;
using DonationStore.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using DonationStore.Application.ViewModels;
using DonationStore.Repository.Context;
using DonationStore.Infrastructure.Transaction;
using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Handlers.Commands.Donation;
using System;

namespace DonationStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var defaultConection = Configuration.GetConnectionString("DefaultConnection");
            ConfigureInfrasctructure(services, defaultConection);

            services.AddMediatR(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Dev",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc(config => config.Filters.Add(new GlobalExceptionHandler())).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("Dev");

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureInfrasctructure(IServiceCollection services, string defaultConection)
        {
            services.AddDbContext<DonationStoreContext>(options => options.UseSqlServer(defaultConection));

            services.AddDbContext<DonationStoreContext>(options => options.UseSqlServer(defaultConection));

            services.AddIdentity<AspNetUsers, AspNetRoles>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DonationStoreContext>()
            .AddDefaultTokenProviders();



            services.AddTransient<IAuthenticationService, AuthenticationService>()
                    .AddTransient<IUserRepository, UserRepository>()
                    .AddTransient<IDonationRepository, DonationRepository>()
                    .AddTransient<IUserFactory, UserFactory>()
                    .AddTransient<IDonationFactory, DonationFactory>()
                    .AddTransient<IDonationService, DonationService>()
                    .AddTransient<ITransactionScopeManager, TransactionScopeManager>()
                    .AddScoped<DonationStoreContext, DonationStoreContext>()
                    .AddScoped<IRequestHandler<RegisterUserCommand, LoginUserViewModel>, RegisterUserCommandHandler>()
                    .AddScoped<IRequestHandler<RegisterDonationCommand, Unit>, RegisterDonationCommandHandler>()
                    .AddScoped<IRequestHandler<LoginCommand, LoginUserViewModel>, LoginCommandHandler>();
        }
    }
}
