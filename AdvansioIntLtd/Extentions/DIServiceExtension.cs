﻿

using AdvansioIntLtd.DbContextFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvansioIntLtd.Extentions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvansioDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AdvansioConnection")));
        }
    }
}