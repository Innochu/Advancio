using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvansioIntLtd.AuthEntity;
using AdvansioIntLtd.Entities;
using AdvansioIntLtd.Interface.IService;
using AdvansioIntLtd.Dto;

namespace AdvansioIntLtd.Pages.RegisterPage
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IWalletService _walletService; // Assuming you have a service for managing wallets

        public RegisterModel(UserManager<User> userManager, IWalletService walletService)
        {
            _userManager = userManager;
            _walletService = walletService;
        }

        [BindProperty]
        public Register Register { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                FirstName = Register.FirstName,
                LastName = Register.LastName,
                PhoneNumber = Register.PhoneNumber,
                Email = Register.Email,
            };

            var result = await _userManager.CreateAsync(user, Register.Password);
            if (result.Succeeded)
            {
                var walletDto = new WalletDto
                {
                    PhoneNumber = Register.PhoneNumber,
                    UserId = user.Id, 
                    Balance = 5000 
                };

                // Registration succeeded, create a wallet for the user and fund it
                await _walletService.CreateWallet(walletDto); 
                return RedirectToPage("/Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}
