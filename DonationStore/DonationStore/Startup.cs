using DonationStore.Repository.Context;
using DonationStore.Repository.Identity;
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
using DonationStore.Domain.Handlers.Commands;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Repository.Repositories;

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

            services.AddDbContext<IdentityDonationStoreContext>(options => options.UseSqlServer(defaultConection));

            services.AddDbContext<DonationStoreContext>(options => options.UseSqlServer(defaultConection));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentityDonationStoreContext>()
            .AddDefaultTokenProviders();

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

            services.AddTransient<IAuthenticationService, AuthenticationService>()
                    .AddTransient<IUserRepository, UserRepository>()
                    .AddScoped<DonationStoreContext, DonationStoreContext>()
                    .AddScoped<IRequestHandler<RegisterUserCommand, Unit>, RegisterUserCommandHandler>();


            services.AddControllers().AddNewtonsoftJson();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
