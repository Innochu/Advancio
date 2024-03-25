using AdvansioIntLtd.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvansioIntLtd.Pages.DashBoard
{
    public class DashBoardModel : PageModel
    {
        private readonly IWalletService _walletService;

        public DashBoardModel(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch the wallet balance
            Balance = await _walletService.GetWalletBalanceAsync();
            return Page();
        }
    }
}

