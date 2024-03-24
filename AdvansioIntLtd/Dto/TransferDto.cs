using System.ComponentModel.DataAnnotations;

namespace AdvansioIntLtd.Dto
{
    public class TransferDto
    {
        [Required]
        public string WalletNumber { get; set; } = string.Empty;
        public decimal DebitAmount { get; set; }
        public string Narration { get; set; } = string.Empty;
        public int ActionId { get; set; }
    }
}
