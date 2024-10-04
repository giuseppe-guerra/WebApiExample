using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Endpoints
{
    public static class ProductsEndpoints
    {
        public static RouteGroupBuilder MapProductsEndpoint(this WebApplication app, IMapper mapper)
        {
            const string GetProductEndpoint = "GetProduct";

            var productGroup = app.MapGroup("api/products");


            // GET api/products
            productGroup.MapGet("/", async (NorthwindContext context) =>
            {
                return await context.Products
                    .AsNoTracking()
                    .ToListAsync();
            });


            // GET api/products/1
            productGroup.MapGet("/{id}", async (int id, NorthwindContext context) =>
            {
                Product? product = await context.Products.FindAsync(id);

                return product != null ? Results.Ok(product) : Results.NotFound();

            }).WithName(GetProductEndpoint);


            // POST api/products/
            productGroup.MapPost("/", async (ProductCreateDto product, NorthwindContext context) =>
            {
                Product newProduct = mapper.Map<Product>(product);

                context.Products.Add(newProduct);
                await context.SaveChangesAsync();

                ProductDto productDto = mapper.Map<ProductDto>(newProduct);

                return Results.CreatedAtRoute(GetProductEndpoint, new { Id = newProduct.ProductId }, productDto);
            });


            // PUT api/products/1
            productGroup.MapPut("/{id}", async (int id, ProductUpdateDto product, NorthwindContext context) =>
            {
                var existingProduct = await context.Products.FindAsync(id);
                
                if (existingProduct != null)
                {
                    context.Entry(existingProduct)
                        .CurrentValues
                        .SetValues(product);
                    
                    await context.SaveChangesAsync();

                    return Results.NoContent();
                }

                return Results.NotFound();
            });


            // DELETE api/products/77
            productGroup.MapDelete("/{id}", async (int id, NorthwindContext context) =>
            {
                await context.Products.Where(p => p.ProductId == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return productGroup;
        }
    }
}
