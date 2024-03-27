using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvansioIntLtd.Dto
{
    public class TransferDto
    {
        [Required]
        public string WalletNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Bank { get; set; }
        public decimal Vat { get; set; }
        [ForeignKey("AppUserId")]
        public string UserId { get; set; } = string.Empty;
    }
}
