

using AdvansioIntLtd.DbContextFolder;
using AdvansioIntLtd.Interface.IService;
using AdvansioIntLtd.Service;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ITransferService, TransferService>();
        }
    }
}
