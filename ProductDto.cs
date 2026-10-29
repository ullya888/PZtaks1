namespace TradingCompany.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}