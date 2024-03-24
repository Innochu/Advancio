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
                    Balance = walletDto.Balance,
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

        public Task<TransfersResponseDto> TransferFundsAsync(TransferDto transferDto)
        {
           
        }
    }
}