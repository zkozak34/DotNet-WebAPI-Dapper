using Bootcamp.WebAPI.Models;
using Dapper;
using System.Data;

namespace Bootcamp.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

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
