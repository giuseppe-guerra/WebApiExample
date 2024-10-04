namespace WebApplication1.Dtos
{
    public record class ProductUpdateDto(
        string ProductName, decimal UnitPrice, int SupplierId, int CategoryId);
    
}
