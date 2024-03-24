namespace AdvansioIntLtd.Dto
{
    public class TransfersResponseDto
    {
        public string WalletNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
