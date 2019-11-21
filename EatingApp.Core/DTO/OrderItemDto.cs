namespace EatingApp.Core.DTO
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public short Quantity { get; set; }

        public string Description { get; set; }
    }
}
