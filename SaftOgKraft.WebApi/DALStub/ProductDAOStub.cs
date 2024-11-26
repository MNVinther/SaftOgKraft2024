using DAL.Model;

namespace SaftOgKraft.WebApi.DALStub
{
    public class ProductDAOStub
    {
        #region intern database som emulerer database

        private static readonly List<Product> _products =
        [
            // New Product explicit in the List above which only takes Products.
            new() { Id = 1, Name = "KraftigSaft", Price = 10, Description = "Den lækreste saft" },
            new() { Id = 2, Name = "SødeSaft", Price = 8, Description = "Sød og frugtrig saft" },
            new() { Id = 3, Name = "CitrusSaft", Price = 12, Description = "Frisk citrussmag" },
            new() { Id = 4, Name = "BærrySaft", Price = 11, Description = "Fuld af bærsmag" },
            new() { Id = 5, Name = "GrønSaft", Price = 9, Description = "Grøn smoothie" },
            new() { Id = 6, Name = "6Saft", Price = 8, Description = "Sød og frugtrig saft" },
            new() { Id = 7, Name = "7Saft", Price = 12, Description = "Frisk citrussmag" },
            new() { Id = 8, Name = "8Saft", Price = 11, Description = "Fuld af bærsmag" },
            new() { Id = 9, Name = "9Saft", Price = 9, Description = "Grøn smoothie" },
            new() { Id = 10, Name = "10Saft", Price = 9, Description = "Grøn smoothie" },
        ];

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
            // Nullcheck, throw exception if no matching IDs
            return _products.FirstOrDefault(product => product.Id == id) ?? throw new Exception("could not find product - check ID again");
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
