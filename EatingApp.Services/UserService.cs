using AutoMapper;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.Abstractions;
using EatingApp.Core.DTO;
using EatingApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using EatingApp.Core.Validators;
using FluentValidation;

namespace EatingApp.Services
{
    public class UserService :  IUserService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private UserValidator _userValidator=new UserValidator();

        public UserService(IUnitOfWork unitOfWork, IMapper map)
        {
            this.unitOfWork = unitOfWork;
            mapper = map;
        }

        public List<UserDto> GetAll()
        {
            return unitOfWork.UserRepository.List().Select(item => mapper.Map(item, new UserDto())).ToList();
        }

        public UserDto GetById(int id)
        {
            var item = unitOfWork.UserRepository.GetById(id);
            if (item == null)
                throw new Exception("Not found");
            var dto = new UserDto();
            mapper.Map(item, dto);
            return dto;
        }

        public UserDto Insert(UserDto user)
        {
            _userValidator.ValidateAndThrow(user);
            var usr = new User();
            mapper.Map(user, usr);
            unitOfWork.UserRepository.Add(usr);
            unitOfWork.Save();
            user.Id = usr.Id;
            return user;
        }

        public void Update(UserDto user)
        {
            var usr = new User();
            mapper.Map(user, usr);
            unitOfWork.UserRepository.Edit(usr);
            unitOfWork.Save();
        }

        public void Delete(int userId)
        {
            unitOfWork.UserRepository.Delete(userId);
            unitOfWork.Save();
        }
    }
}
