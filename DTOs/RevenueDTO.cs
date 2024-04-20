namespace HHPWsBe.DTOs
{
    public class RevenueDTO
    {
        public decimal? TotalRevenue { get; set; }
        public int TipTotal { get; set; }
        public int PickupTotal { get; set; }
        public int DineInTotal { get; set; }
        public int DeliveryTotal { get; set; }
        public int CashTotal { get; set; }
        public int CreditTotal { get; set; }
        public int DebitTotal { get; set; }
    }
}
