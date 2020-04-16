using DataAccess.DW.DataAccess.Interfaces;
using Entities.Product;
using Services.DW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services
{
    public class ProductSL : IProductSL
    {
        public IProductDA productDA;
        public ProductSL(IProductDA productDA)
        {
            this.productDA = productDA;
        }
        public CreateProductOut CreateProduct(CreateProductIn input)
        {
            return productDA.CreateProduct(input);
        }

        public DeleteProductOut DeleteProduct(DeleteProductIn input)
        {
            return productDA.DeleteProduct(input);
        }

        public GetAllProductsOut GetAllProduct(GetAllProductsIn input)
        {
            return productDA.GetAllProduct(input);
        }

        public GetProductFilterOut GetProductFilter(GetProductFilterIn input)
        {
            return productDA.GetProductFilter(input);
        }

        public UpdateProductOut UpdateProduct(UpdateProductIn input)
        {
            return productDA.UpdateProduct(input);
        }
    }
}
