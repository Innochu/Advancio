using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvansioIntLtd.AuthEntity;
using AdvansioIntLtd.Dto;
using AdvansioIntLtd.Interface.IService;
using AdvansioIntLtd.Entities;

namespace AdvansioIntLtd.Pages.RegisterPage
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWalletService _walletService;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager, IWalletService walletService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = Register.FirstName,
                    LastName = Register.LastName,
                    PhoneNumber = Register.PhoneNumber,
                    UserName = Register.Email,
                    Email = Register.Email,
                };

                var result = await _userManager.CreateAsync(user, Register.Password);
                if (result.Succeeded)
                {
                    var walletDto = new WalletDto
                    {
                        PhoneNumber = Register.PhoneNumber,
                        UserId = user.Id,
                    };

                    try
                    {
                        // Call the service method to create the wallet
                        await _walletService.CreateWallet(walletDto);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during wallet creation
                        ModelState.AddModelError(string.Empty, "Error creating wallet: " + ex.Message);
                        return Page();
                    }

                    // Sign in the user and redirect to the Index page
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/LoginPage/Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Page();
        }
    }
}
