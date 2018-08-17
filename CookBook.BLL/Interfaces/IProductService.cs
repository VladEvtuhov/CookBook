using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDTO);
        void RemoveProduct(ProductDTO productDTO);
        IEnumerable<ProductDTO> GetProducts();
    }
}
