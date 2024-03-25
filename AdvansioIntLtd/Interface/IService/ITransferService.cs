using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Entities;

namespace AdvansioIntLtd.Interface.IService
{
    public interface ITransferService
    {
        Task<decimal> TransferFundsAsync(TransferDto transferDto);
        Task<Wallet> GetWalletByNumber(string phone);
    }
}
