using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using EatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatingApp.Services
{
    public class ProductService :IProductService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<ProductDto> GetAll()
        {

            return unitOfWork.ProductRepository.List().Select(item => mapper.Map(item, new ProductDto())).ToList();
        }

        public ProductDto GetById(int id)
        {
            var item = unitOfWork.ProductRepository.GetById(id);
            if (item == null)
                throw new Exception("Not found");
            var dto = new ProductDto();
            mapper.Map(item, dto);
            return dto;
        }

        public ProductDto Insert(ProductDto product)
        {
            var prod = new Product();
            mapper.Map(product, prod);
            unitOfWork.ProductRepository.Add(prod);
            unitOfWork.Save();
            product.Id = prod.Id;

            return product;
        }

        public void Update(ProductDto product)
        {
            var prod = new Product();
            mapper.Map(product, prod);
            unitOfWork.ProductRepository.Edit(prod);
            unitOfWork.Save();
        }

        public void Delete(int productId)
        {
            unitOfWork.ProductRepository.Delete(productId);
            unitOfWork.Save();
        }
    }
}
