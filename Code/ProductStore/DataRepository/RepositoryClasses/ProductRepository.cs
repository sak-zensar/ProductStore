using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataRepository
{
    public class ProductRepository : IProductRepositoryInteface
    {
        public dynamic GetData(dynamic data)
        {
            List<ProductDetails> productList = null;
            var jsonResult = JsonConvert.DeserializeObject(data);
            if (jsonResult != null)
            {
                string ProductName = jsonResult.ProductName != null ? jsonResult.ProductName : string.Empty;
                int CategoryId = jsonResult.CategoryId != null && jsonResult.CategoryId > 0 ? jsonResult.CategoryId : -1;
                string CategoryName = jsonResult.CategoryName != null ? jsonResult.CategoryName : string.Empty;
                int UnitId = jsonResult.UnitId != null && jsonResult.UnitId > 0 ? jsonResult.UnitId : -1;

                using (var dbContex = new ProductStoreEntities())
                {
                    productList = dbContex.ProductSearch(ProductName, CategoryId, CategoryName, UnitId)
                                        .Select(c =>
                                            new ProductDetails
                                            {
                                                Category = c.Category,
                                                CategoryId = c.CategoryId,
                                                Currency = c.Currency,
                                                Price = c.Price,
                                                ProductId = c.ProductId,
                                                ProductName = c.ProductName,
                                                Unit = c.Unit,
                                                UnitId = c.UnitId
                                            }
                                        ).ToList<ProductDetails>();
                }
            }
            return productList;
        }

        public dynamic Insert(dynamic data)
        {
            ProductDetails product = JsonConvert.DeserializeObject<ProductDetails>(data);
            if (product != null)
            {
                using (var dbContex = new ProductStoreEntities())
                {
                    dbContex.SaveProduct(product.ProductId, product.ProductName, product.CategoryId, product.Price, product.Currency, product.UnitId);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public dynamic Update(dynamic data)
        {
            ProductDetails product = JsonConvert.DeserializeObject<ProductDetails>(data);
            if (product != null)
            {
                using (var dbContex = new ProductStoreEntities())
                {
                    dbContex.SaveProduct(product.ProductId, product.ProductName, product.CategoryId, product.Price, product.Currency, product.UnitId);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public dynamic Delete(dynamic data)
        {
            int ProductId = (int)data;
            using (var dbContex = new ProductStoreEntities())
            {
                Product removeProduct = dbContex.Products.Where(p => p.ProductId.Equals(ProductId)).FirstOrDefault(); ;
                if (removeProduct != null)
                {
                    dbContex.Products.Remove(removeProduct);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
