using Bootcamp.Entities.Entities.Concrete;

namespace Bootcamp.Entities.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }


        public ProductDto() { }

        public ProductDto(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Stock = product.Stock;
        }

    }
}
