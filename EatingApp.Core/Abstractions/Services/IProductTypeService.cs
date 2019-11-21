using EatingApp.Core.DTO;
using System.Collections.Generic;

namespace EatingApp.Core.Abstractions.Services
{
    public interface IProductTypeService
    {
        public List<ProductTypeDto> GetAll();


        public ProductTypeDto GetById(int id);


        public ProductTypeDto Insert(ProductTypeDto product);


        public void Update(ProductTypeDto product);


        public void Delete(int productId);
    }
}
