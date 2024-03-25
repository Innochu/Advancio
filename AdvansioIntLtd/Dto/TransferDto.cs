using System.ComponentModel.DataAnnotations;

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
    }
}
