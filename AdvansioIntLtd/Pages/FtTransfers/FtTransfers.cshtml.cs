using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdvansioIntLtd.Pages.FtTransfers
{
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
              
                await _transferService.TransferFundsAsync(Transfer);
                return RedirectToPage("/Index"); // Redirect to a success page or dashboard
            }
            return Page();
        }
    }
}
