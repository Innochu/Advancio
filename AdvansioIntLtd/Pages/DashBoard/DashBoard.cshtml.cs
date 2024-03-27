using AdvansioIntLtd.Interface.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AdvansioIntLtd.Pages.DashBoard
{
    [Authorize]
    public class DashBoardModel : PageModel
    {
        private readonly IWalletService _walletService;

        public DashBoardModel(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
           
            Balance = await _walletService.GetWalletBalanceAsync(userId);
            return Page();
        }
    }
}

