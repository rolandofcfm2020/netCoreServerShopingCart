using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLMP12.Backend;
using ApiLMP12.DataAccess;
using ApiLMP12.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLMP12.Controllers
{
    [Route("api/[controller]/[action]")]
    //.../api/products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet] //Verbo REST o tipo de request
        public List<ProductDTO> getAllProducts()
        {
            return new ProductSC().getAllProducts(); 
        }

        //.../api/products/getProductById
        [HttpGet] //Verbo REST o tipo de request
        public Products getProductById(Guid id)
        {
            return new ProductSC().getProductById(id);
        }

        // /api/products/addProduct
        [HttpPost]
        public ProductDTO addProduct([FromBody] ProductDTO newproduct)
        {
            var products = new ProductSC().AddProduct(newproduct);
            return newproduct;
        }
        //.. /api/products/updateProduct?productId=x
        [HttpPut]
        public Products updateProduct(Guid productid, [FromBody] ProductDTO newproduct)
        { 
            var productUpdated =  new ProductSC().updateProduct(productid, newproduct);
            return productUpdated;
        }

        [HttpDelete]
        public bool deleteProduct(Guid id)
        {
            var productUpdated = new ProductSC().deleteProduct(id);
            return productUpdated;
        }

        [HttpPost]
        public void saveProductCart([FromBody] List<ProductDTO> productCart)
        {
           // do something with data
        }
    }
}
