using DAL.Model;

namespace SaftOgKraft.WebApi.DALStub
{
    public class ProductDAOStub
    {
        #region intern database der emulerer database

        private static List<Product> _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "KraftigSaft", Price = 10, Description = "Den lækreste saft" },
            new Product() { Id = 2, Name = "SødeSaft", Price = 8, Description = "Sød og frugtrig saft" },
            new Product() { Id = 3, Name = "CitrusSaft", Price = 12, Description = "Frisk citrussmag" },
            new Product() { Id = 4, Name = "BærrySaft", Price = 11, Description = "Fuld af bærsmag" },
            new Product() { Id = 5, Name = "GrønSaft", Price = 9, Description = "Grøn smoothie" },
            new Product() { Id = 6, Name = "6Saft", Price = 8, Description = "Sød og frugtrig saft" },
            new Product() { Id = 7, Name = "7Saft", Price = 12, Description = "Frisk citrussmag" },
            new Product() { Id = 8, Name = "8Saft", Price = 11, Description = "Fuld af bærsmag" },
            new Product() { Id = 9, Name = "9Saft", Price = 9, Description = "Grøn smoothie" },
            new Product() { Id = 10, Name = "10Saft", Price = 9, Description = "Grøn smoothie" },
        };

        #endregion

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public IEnumerable<Product> GetTenLatestProducts()
        {
            return GetAll().Take(10);
        }

        public Product Get(int id)
        {
            // Searches the product list for the first product with the matching ID
            return _products.FirstOrDefault(product => product.Id == id);
        }

        public int Insert(Product product)
        {
            // Finds the maximum product ID in the list and increments it for the new product
            var newId = _products.Max(product => product.Id) + 1;
            product.Id = newId;
            //product.CreationDate = DateTime.Now;
            _products.Add(product);
            return newId;
        }

        //// Another method to retrieve the ten latest products, sorted by creation date
        //public IEnumerable<Product> GetTenLatestProducts()
        //{
        //    // Sorts the products by creation date in descending order (newest first) and takes the first 10
        //    return _products.OrderByDescending(product => product.CreationDate).Take(10);
        //}

    }
}
