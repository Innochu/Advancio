using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Interface.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdvansioIntLtd.Pages.FtTransfers
{
    [Authorize]
    public class TransferModel : PageModel
    {
        private readonly ITransferService _transferService;

        public TransferModel(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [BindProperty]
        public TransferDto Transfer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Assuming the Transfer object includes the user ID
                await _transferService.TransferFundsAsync(Transfer);

                // Redirect back to the dashboard page with the user ID
                return RedirectToPage("/Dashboard/Dashboard", new { userId = Transfer.UserId });
            }
            return Page();
        }

    }
}
