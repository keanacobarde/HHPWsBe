namespace HHPWsBe.DTOs
{
    public class PaymentInfoDTO
    {
        public int OrderId { get; set; }
        public string? PaymentType { get; set; }
        public decimal? Tip { get; set; }
        public bool Status { get; set; }
    }
}
