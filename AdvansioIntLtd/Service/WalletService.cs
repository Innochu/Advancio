using AdvansioIntLtd.DbContextFolder;
using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Entities;
using AdvansioIntLtd.Enum;
using AdvansioIntLtd.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvansioIntLtd.Service
{
    public class WalletService : IWalletService
    {

        private readonly AdvansioDbContext _dbContext;

        public WalletService(AdvansioDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<WalletDto> CreateWallet(WalletDto walletDto)
        {
            try
            {
                var wall = new Wallet
                {
                    PhoneNumber = walletDto.PhoneNumber,
                    UserId = walletDto.UserId,
                };
                wall.SetWalletID(walletDto.PhoneNumber);
                wall.Currency = Currency.Naira;

                // Set initial balance to 5000 only for new wallets
                if (!_dbContext.Wallets.Any(w => w.UserId == walletDto.UserId))
                {
                    wall.Balance = 5000;
                }
                else
                {
                    wall.Balance = 0; 
                }

                await _dbContext.AddAsync(wall);
                await _dbContext.SaveChangesAsync();

                var responseDto = new WalletDto
                {
                    PhoneNumber = wall.PhoneNumber,
                    UserId = wall.UserId,
                    Balance = wall.Balance,
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<decimal> GetWalletBalanceAsync(string userId)
        {
            var totalBalance = await _dbContext.Wallets.Where(w => w.UserId == userId).Select(w => w.Balance).FirstOrDefaultAsync();
            return totalBalance;
        }





    }
}