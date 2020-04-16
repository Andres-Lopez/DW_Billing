using DataAccess.DW.DataAccess;
using Entities.Product;
using Services.DW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        ProductSL Product = new ProductSL(new ProductDA());

        [HttpPost]
        public IHttpActionResult CreateProduct(CreateProductIn input)
        {
            var response = Product.CreateProduct(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult DeleteProduct(DeleteProductIn input)
        {
            var response = Product.DeleteProduct(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult UpdateProduct(UpdateProductIn input)
        {
            var response = Product.UpdateProduct(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetAllProducts(GetAllProductsIn input)
        {
            var response = Product.GetAllProduct(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetProductFilterName(GetProductFilterIn input)
        {
            var response = Product.GetProductFilter(input);

            return Ok(response);
        }
    }
}
