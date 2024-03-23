using System.ComponentModel.DataAnnotations.Schema;

namespace AdvansioIntLtd.Entities
{
    public class WalletFunding : BaseEntity
    {
        public decimal FundAmount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Narration { get; set; } = string.Empty;
        
        [ForeignKey("ActionId")]
        public int ActionId { get; set; }
        public decimal CumulativeAmount { get; set; }
        public string WalletNumber { get; set; } = string.Empty;

        [ForeignKey("WalletId")]
        public string WalletId { get; set; } = string.Empty;
    }
}
