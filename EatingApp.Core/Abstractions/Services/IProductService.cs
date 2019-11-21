using EatingApp.Core.DTO;
using System.Collections.Generic;

namespace EatingApp.Core.Abstractions.Services
{
    public interface IProductService
    {
        public List<ProductDto> GetAll();


        public ProductDto GetById(int id);


        public ProductDto Insert(ProductDto product);


        public void Update(ProductDto product);


        public void Delete(int productId);
    }
}
