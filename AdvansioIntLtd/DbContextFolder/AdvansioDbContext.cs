using AdvansioIntLtd.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvansioIntLtd.DbContextFolder
{
    public class AdvansioDbContext : IdentityDbContext<User>
    {
        public AdvansioDbContext(DbContextOptions<AdvansioDbContext> options) : base(options)
        {

        }

       // public DbSet<User> Users { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletFunding> WalletFundings { get; set; }
    }
}