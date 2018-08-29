using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IProductService
    {
        OperationDetails CreateProduct(ProductDTO productDTO);
        OperationDetails RemoveProduct(ProductDTO productDTO);
        IEnumerable<ProductDTO> GetProducts();
    }
}
