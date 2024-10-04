namespace WebApplication1.Dtos
{
    public record class ProductDto(
        int ProductID, string ProductName, decimal UnitPrice, int SupplierId, int CategoryId);
}
