using AdvansioIntLtd.DbContextFolder;
using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Entities;
using AdvansioIntLtd.Interface.IService;
using Microsoft.EntityFrameworkCore;

namespace AdvansioIntLtd.Service
{
    public class TransferService : ITransferService
    {
        private readonly AdvansioDbContext _dbContext;

        public TransferService(AdvansioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<decimal> TransferFundsAsync(TransferDto transferDto)
        {
            try
            {
                // 1. Retrieve Wallet
                var wallet = await  GetWalletByNumber(transferDto.WalletNumber);

                // 2. Check Balance
                if (wallet.Balance < transferDto.Amount)
                {
                    throw new Exception("insufficient balance");
                }

                // 3. Perform Debit
                decimal newBalance = wallet.Balance - transferDto.Amount;
                wallet.Balance = newBalance;
                _dbContext.Wallets.Update(wallet);
                await _dbContext.SaveChangesAsync();

                return newBalance;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Wallet> GetWalletByNumber(string phone)
        {
            var wallets = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.PhoneNumber == phone);

            if (wallets == null)
            {
                throw new Exception("Wallet with this number not found");
            }

            // Assuming you want to use the details of the first wallet if multiple wallets are found

            return wallets;
        }

    }
}
