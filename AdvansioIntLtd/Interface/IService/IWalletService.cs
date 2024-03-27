using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvansioIntLtd.Interface.IService
{
    public interface IWalletService
    {
        Task<WalletDto> CreateWallet(WalletDto walletDto);
        Task<decimal> GetWalletBalanceAsync(string userId);
       
        
    }
}
