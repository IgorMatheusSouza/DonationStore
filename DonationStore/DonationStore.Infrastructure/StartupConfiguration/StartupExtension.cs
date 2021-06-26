//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using MediatR;
//using DonationStore.Domain.Entities;
//using DonationStore.Application.Services.Abstractions;
//using DonationStore.Application.Commands.Authentication;
//using DonationStore.Domain.Handlers.Commands.Users;
//using DonationStore.Domain.Abstractions.Repositories;
//using DonationStore.Repository.Repositories;
//using DonationStore.Domain.Abstractions.Factories;
//using DonationStore.Domain.Factories;
//using DonationStore.Infrastructure.Exceptions;
//using Microsoft.AspNetCore.Mvc;
//using DonationStore.Application.ViewModels;
//using DonationStore.Repository.Context;
//using DonationStore.Infrastructure.Transaction;
//using DonationStore.Application.Commands.Donation;
//using DonationStore.Domain.Handlers.Commands.Donation;


//namespace DonationStore.Infrastructure.StartupConfiguration
//{
//    public static class StartupExtension
//    {
 
//        public static IServiceCollection Startup(this IServiceCollection services)
//        {
//            var defaultConection = "DefaultConnection";
//            ConfigureInfrasctructure(services, defaultConection);

//            return services;
//        }

//        private static void ConfigureInfrasctructure(IServiceCollection services, string defaultConection)
//        {
//            services.AddDbContext<IdentityDonationStoreContext>(options => options.UseSqlServer(defaultConection));

//            services.AddDbContext<DonationStoreContext>(options => options.UseSqlServer(defaultConection));

//            services.AddIdentity<AppUser, AspNetRoles>(options =>
//            {
//                options.User.RequireUniqueEmail = true;
//                options.Password.RequireDigit = false;
//                options.Password.RequiredLength = 6;
//                options.Password.RequireNonAlphanumeric = false;
//                options.Password.RequireUppercase = false;
//                options.Password.RequireLowercase = false;
//            })
//            .AddEntityFrameworkStores<IdentityDonationStoreContext>()
//            .AddDefaultTokenProviders();



//            services.AddTransient<IAuthenticationService, AuthenticationService>()
//                    .AddTransient<IUserRepository, UserRepository>()
//                    .AddTransient<IDonationRepository, DonationRepository>()
//                    .AddTransient<IUserFactory, UserFactory>()
//                    .AddTransient<ITransactionScopeManager, TransactionScopeManager>()
//                    .AddScoped<DonationStoreContext, DonationStoreContext>()
//                    .AddScoped<IRequestHandler<RegisterUserCommand, LoginUserViewModel>, RegisterUserCommandHandler>()
//                    .AddScoped<IRequestHandler<RegisterDonationCommand, Unit>, RegisterDonationCommandHandler>()
//                    .AddScoped<IRequestHandler<LoginCommand, LoginUserViewModel>, LoginCommandHandler>();
//        }
//    }
//}
