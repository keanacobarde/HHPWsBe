namespace HHPWsBe.DTOs
{
    public class AddOrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderType { get; set; }
        public DateTime Created { get; set; }
    }
}
