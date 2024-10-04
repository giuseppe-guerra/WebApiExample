namespace WebApplication1.Dtos
{
    public record class ProductCreateDto(
        string ProductName, decimal UnitPrice, int SupplierId, int CategoryId, string QuantityPerUnit, 
        short UnitsInStock, short UnitsOnOrder, short ReorderLevel, bool Discontinued);
}
