using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Commands.User;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.Queries.User;
using DonationStore.Application.Services;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using DonationStore.Domain.Factories;
using DonationStore.Domain.Handlers.Commands.Donation;
using DonationStore.Domain.Handlers.Commands.User;
using DonationStore.Domain.Handlers.Commands.Users;
using DonationStore.Domain.Handlers.Queries.Donation;
using DonationStore.Domain.Handlers.Queries.User;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.Services.File;
using DonationStore.Infrastructure.Services.Interfaces;
using DonationStore.Infrastructure.Transaction;
using DonationStore.Repository.Context;
using DonationStore.Repository.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwaggerSetup", Version = "v1" });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

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

            services.AddIdentity<User, AspNetRoles>(options =>
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
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<ITransactionScopeManager, TransactionScopeManager>()
                    .AddTransient<IFileInfrastructureService, FileInfrastructureService>()
                    .AddTransient<IDonationAcquisitionRepository, DonationAcquisitionRepository>()
                    .AddScoped<DonationStoreContext, DonationStoreContext>()
                    .AddScoped<IRequestHandler<RegisterUserCommand, UserViewModel>, RegisterUserCommandHandler>()
                    .AddScoped<IRequestHandler<RegisterDonationCommand, Unit>, RegisterDonationCommandHandler>()
                    .AddScoped<IRequestHandler<LoginCommand, UserViewModel>, LoginCommandHandler>()
                    .AddScoped<IRequestHandler<LogoutCommand, Unit>, LogoutCommandHandler>()
                    .AddScoped<IRequestHandler<LoginCommand, UserViewModel>, LoginCommandHandler>()
                    .AddScoped<IRequestHandler<LogoutCommand, Unit>, LogoutCommandHandler>()
                    .AddScoped<IRequestHandler<GetDonationsQuery, List<DonationViewModel>>, DonationQueryHandler>()
                    .AddScoped<IRequestHandler<GetDonationQuery, DonationViewModel>, DonationQueryHandler>()
                    .AddScoped<IRequestHandler<GetUserQuery, UserDetailViewModel>, GetUserQueryHandler>()
                    .AddScoped<IRequestHandler<AcquireDonationCommand, Unit>, AcquireDonationCommandHandler>()
                    .AddScoped<IRequestHandler<GetDonationAcquisitionsQuery, List<DonationViewModel>>, DonationAcquisitionQueryHandler>()
                    .AddScoped<IRequestHandler<RegisterPhoneNumberCommand, Unit>, RegisterPhoneNumberCommandHandler>()
                    .AddScoped<IRequestHandler<GetUserDonationsQuery, List<DonationViewModel>>, DonationQueryHandler>()
                    .AddScoped<IRequestHandler<ChangeAcquisitionStatusCommand, Unit>, ChangeAcquisitionStatusCommandHandler>()
                    .AddScoped<IRequestHandler<ChangeDonationStatusCommand, Unit>, ChangeDonationStatusCommandHandler>();

        }
    }
}
