using WBAPI.Models;

namespace WBAPI.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? Get(int id);
        void Add(Product p);
        bool Update(int id, Product p);
        bool Delete(int id);
    }
}
