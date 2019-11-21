using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using EatingApp.Entities;

namespace EatingApp.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<ProductTypeDto> GetAll()
        {
            return unitOfWork.ProductTypeRepository.List().Select(item => mapper.Map(item, new ProductTypeDto())).ToList();
        }

        public ProductTypeDto GetById(int id)
        {
            var item = unitOfWork.ProductTypeRepository.GetById(id);
            if (item == null)
                throw new Exception("Not found");

            var dto = new ProductTypeDto();
            mapper.Map(item, dto);
            return dto;
        }

        public ProductTypeDto Insert(ProductTypeDto product)
        {
            var prod = new ProductType();
            mapper.Map(product, prod);
            unitOfWork.ProductTypeRepository.Add(prod);
            unitOfWork.Save();
            product.Id = prod.Id;

            return product;
        }

        public void Update(ProductTypeDto product)
        {
            var prod = new ProductType();
            mapper.Map(product, prod);
            unitOfWork.ProductTypeRepository.Edit(prod);
            unitOfWork.Save();
        }

        public void Delete(int productId)
        {
            unitOfWork.ProductTypeRepository.Delete(productId);
            unitOfWork.Save();
        }
    }
}
