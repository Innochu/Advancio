namespace AdvansioIntLtd.Entities
{
    public class UserTransaction : BaseEntity
    {
        public int ActionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string WalletNumber { get; set; } = string.Empty;
        public string SavingsId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
