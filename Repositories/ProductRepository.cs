using WBAPI.Models;

namespace WBAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public IEnumerable<Product> GetAll() => _products;

        public Product? Get(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product p)
        {
            p.Id = _nextId++;
            _products.Add(p);
        }

        public bool Update(int id, Product updated)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null) return false;
            p.Name = updated.Name;
            p.Price = updated.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            return p != null && _products.Remove(p);
        }
    }
}
