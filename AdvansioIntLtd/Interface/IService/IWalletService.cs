using AdvansioIntLtd.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AdvansioIntLtd.Interface.IService
{
    public interface IWalletService
    {
        Task<WalletDto> CreateWallet(WalletDto walletDto);
        Task<decimal> GetWalletBalanceAsync();
        Task<TransferResultDto> TransferFundsAsync(TransferDto transferDto);
    }
}
