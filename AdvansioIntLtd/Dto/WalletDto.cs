using System.ComponentModel.DataAnnotations.Schema;

namespace AdvansioIntLtd.Dto
{
    public class WalletDto
    {
        public string PhoneNumber { get; set; } 

        [ForeignKey("AppUserId")]
        public string UserId { get; set; } 
        public decimal Balance { get; set; } 
    }
}
