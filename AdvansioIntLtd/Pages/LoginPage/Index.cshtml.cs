using AdvansioIntLtd.AuthEntity;
using AdvansioIntLtd.DbContextFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvansioIntLtd.Pages.LoginPage
{
    public class IndexModel : PageModel
    {
        private readonly AdvansioDbContext _advansioDbContext;

        [BindProperty]
        public Login Login { get; set; }

        public IndexModel(AdvansioDbContext advansioDbContext)
        {
            _advansioDbContext = advansioDbContext;
        }
        public void OnGet()
        {
        }

        //public async Task<IActionResult> OnPostLogin(Login login) 
        //{
        //}
    }
}
