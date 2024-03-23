using AdvansioIntLtd.DbContextFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvansioIntLtd.Pages.DashboardPage
{
    public class IndexModel : PageModel
    {
        private readonly AdvansioDbContext _advansioDbContext;

        public IndexModel(AdvansioDbContext advansioDbContext)
        {
            _advansioDbContext = advansioDbContext;
        }
        public void OnGet()
        {
        }
    }
}
