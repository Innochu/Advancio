using AdvansioIntLtd.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvansioIntLtd.Persistence.DbContextFolder
{
    public class AdvansioDbContext : DbContext
    {
        public AdvansioDbContext(DbContextOptions<AdvansioDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletFunding> WalletFundings { get; set; }
    }
}