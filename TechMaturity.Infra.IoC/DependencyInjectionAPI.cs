﻿using TechMaturity.Application.Interfaces;
using TechMaturity.Application.Mappings;
using TechMaturity.Application.Services;
using TechMaturity.Domain.Account;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using TechMaturity.Infra.Data.Identity;
using TechMaturity.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TechMaturity.Infra.IoC
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
             ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

          
            services.AddScoped<IAuthenticate, AuthenticateService>();


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPillarRepository, PillarRepository>();
            services.AddScoped<IPracticeRepository, PracticeRepository>();
            services.AddScoped<ICapabilityRepository, CapabilityRepository>();
            services.AddScoped<ICriteriaRepository, CriteriaRepository>();
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPillarService, PillarService>();
            services.AddScoped<IPracticeService, PracticeService>();
            services.AddScoped<ICapabilityService,CapabilityService>();
            services.AddScoped<ICriteriaService, CriteriaService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("TechMaturity.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}


