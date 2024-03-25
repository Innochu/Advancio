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
                wall.Balance = 5000;

                await _dbContext.AddAsync(wall);
                await _dbContext.SaveChangesAsync();

                // var reponseDto = _mapper.Map<WalletResponseDto>(wallet);
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

        public async Task<decimal> GetWalletBalanceAsync()
        {
            var walletBalance = await _dbContext.Wallets.SumAsync(w => w.Balance);
            return walletBalance;
        }


        public async Task<Decimal> TransferFundsAsync(TransferDto transferDto)
        {
            try
            {
                // 1. Retrieve Wallet
                var wallet = await GetWalletByNumber(transferDto.WalletNumber);
                
                // 2. Check Balance
                if (wallet.Balance < transferDto.DebitAmount)
                {
                    throw new Exception("insufficient balance");
                }

                // 3. Perform Debit
                decimal newBalance = wallet.Balance - transferDto.DebitAmount;
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