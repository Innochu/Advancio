using System.ComponentModel.DataAnnotations.Schema;

namespace AdvansioIntLtd.Dto
{
    public class WalletDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        [ForeignKey("AppUserId")]
        public string UserId { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 5000;
    }
}
