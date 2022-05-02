using System.Data;
using Bootcamp.WebAPI.Models;
using Dapper;
using Npgsql.Replication.PgOutput.Messages;

namespace Bootcamp.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        private static List<Product> _products = new List<Product>()
        {
            new Product() {Id = 1, Name = "Product 1", Price = 100, Stock = 10},
            new Product() {Id = 2, Name = "Product 2", Price = 200, Stock = 15},
            new Product() {Id = 3, Name = "Product 3", Price = 200, Stock = 15},
            new Product() {Id = 4, Name = "Product 4", Price = 300, Stock = 18},
            new Product() {Id = 5, Name = "Product 5", Price = 400, Stock = 19},
        };

        public async Task<List<Product>> GetAll()
        {
            var query = "select * from products order by id asc";
            var products = await _connection.QueryAsync<Product>(query);
            return products.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            var query = $"select * from products where id={id}";
            var product = await _connection.QuerySingleAsync<Product>(query);
            return product;
        }

        public async Task<bool> Save(Product product)
        {
            var query = $"insert into products(name, price, stock, categoryid) values(@name,@price,@stock,@categoryid)";
            var response = await _connection.ExecuteAsync(query,new {name=product.Name, price=product.Price, stock=product.Stock, categoryid=product.CategoryId});
            return response == 1 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var query = $"delete from products where id={id}";
            var response = await _connection.ExecuteAsync(query);
            return response == 1 ? true : false;
        }

        public async Task<bool> Update(Product product)
        {
            var query =
                $"update products set name=@name, price=@price, stock=@stock, categoryid=@categoryid where id={product.Id}";
            var response = await _connection.ExecuteAsync(query,new {name=product.Name,price=product.Price,stock=product.Stock,categoryid=product.CategoryId});
            return response == 1 ? true : false;
        }

        public async Task<List<Product>> GetWithPage(int page, int pagesize)
        {
            var query = $"select * from products order by id asc offset {(page - 1) * pagesize} limit {pagesize}";
            var response = await _connection.QueryAsync<Product>(query);
            return response.ToList();
        }
    } 
}
