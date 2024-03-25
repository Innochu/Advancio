using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvansioIntLtd.Interface.IService
{
    public interface IWalletService
    {
        Task<WalletDto> CreateWallet(WalletDto walletDto);
        Task<decimal> GetWalletBalanceAsync();
        Task<decimal> TransferFundsAsync(TransferDto transferDto);
        Task<Wallet> GetWalletByNumber(string phone);
    }
}
