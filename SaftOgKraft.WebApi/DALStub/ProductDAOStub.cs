namespace SaftOgKraft.WebApi.DALStub
{
    public class ProductDAOStub
    {
        #region intern database der emulerer database

        private static List<Product> _products = new List<Product>()
        {
            new ProductDto() { Id = 1, Name = "KraftigSaft", Price = 10, Description = "Den lækreste saft" },
            new ProductDto() { Id = 2, Name = "SødeSaft", Price = 8, Description = "Sød og frugtrig saft" },
            new ProductDto() { Id = 3, Name = "CitrusSaft", Price = 12, Description = "Frisk citrussmag" },
            new ProductDto() { Id = 4, Name = "BærrySaft", Price = 11, Description = "Fuld af bærsmag" },
            new ProductDto() { Id = 5, Name = "GrønSaft", Price = 9, Description = "Grøn smoothie" },
            new ProductDto() { Id = 6, Name = "6Saft", Price = 8, Description = "Sød og frugtrig saft" },
            new ProductDto() { Id = 7, Name = "7Saft", Price = 12, Description = "Frisk citrussmag" },
            new ProductDto() { Id = 8, Name = "8Saft", Price = 11, Description = "Fuld af bærsmag" },
            new ProductDto() { Id = 9, Name = "9Saft", Price = 9, Description = "Grøn smoothie" },
            new ProductDto() { Id = 10, Name = "10Saft", Price = 9, Description = "Grøn smoothie" },
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
            return _products.FirstOrDefault(product => product.Id == id);
        }

        public int Insert(Product product)
        {
            var newId = _products.Max(product => product.Id) + 1;
            product.Id = newId;
            //product.CreationDate = DateTime.Now;
            _products.Add(product);
            return newId;

        }

        public IEnumerable<Product> GetTenLatestProducts()
        {
            return _products.OrderByDescending(product => product.CreationDate).Take(10);
        }

    }
}
