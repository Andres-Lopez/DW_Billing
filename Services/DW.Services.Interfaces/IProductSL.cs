using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.Interfaces
{
    public interface IProductSL
    {
        CreateProductOut CreateProduct(CreateProductIn input);
        DeleteProductOut DeleteProduct(DeleteProductIn input);
        UpdateProductOut UpdateProduct(UpdateProductIn input);
        GetAllProductsOut GetAllProduct(GetAllProductsIn input);
        GetProductFilterOut GetProductFilter(GetProductFilterIn input);
    }
}
