using ApiLMP12.DataAccess;
using ApiLMP12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLMP12.Backend
{
    public class ProductSC
    {

        public RV_ERPContext DataContext = new RV_ERPContext();

        public IQueryable<Products> getAllProductsFromDB()
        {
            return DataContext.Products;
        }

        public List<ProductDTO> getAllProducts()
        {
            var response = new List<ProductDTO>();
            response = getAllProductsFromDB().Select(s => new ProductDTO
            {
                Title = s.Name,
                Description = s.Description,
                Cost = s.Cost == null? 0m : s.Cost.Value,
                Id = s.Id
            }).ToList();
            return response;
        }

        public Products updateProduct(Guid productid, ProductDTO newproduct)
        {
            var productInDB = getProductById(productid);
            if (productInDB == null)
                return null;

            productInDB.Name = newproduct.Title;
            productInDB.Description = newproduct.Description;
            productInDB.Cost = newproduct.Cost;

            DataContext.SaveChanges();

            return productInDB;
        }

        public Products getProductById(Guid id)
        {
            return getAllProductsFromDB().Where(w => w.Id == id).FirstOrDefault();
        }

        public Products AddProduct(ProductDTO newproduct)
        {
            var newProductInDB = new Products();
            newProductInDB.Id = Guid.NewGuid();
            newProductInDB.Description = newproduct.Description;
            newProductInDB.Cost = newproduct.Cost;
            newProductInDB.Name = newproduct.Title;
            newProductInDB.Sku = Guid.NewGuid().ToString();

            DataContext.Products.Add(newProductInDB);
            DataContext.SaveChanges();

            return newProductInDB;
        }

        public bool deleteProduct(Guid id)
        {
            try
            {

                var productToDelete = getProductById(id);
                //this is my DataContext or my real DB 

                DataContext.Products.Remove(productToDelete);
                DataContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
