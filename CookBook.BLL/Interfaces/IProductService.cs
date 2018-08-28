using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDTO);
        void RemoveProduct(ProductDTO productDTO);
        IEnumerable<ProductDTO> GetProducts();
    }
}
