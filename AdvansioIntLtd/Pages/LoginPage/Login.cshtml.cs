using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvansioIntLtd.AuthEntity;
using AdvansioIntLtd.Entities;

namespace AdvansioIntLtd.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public Login Login { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Validation failed, return the login view with error messages.
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Login.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, Login.Password, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Authentication succeeded, redirect to the desired page.
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
