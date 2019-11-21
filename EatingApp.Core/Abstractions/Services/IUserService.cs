using EatingApp.Core.DTO;
using System.Collections.Generic;

namespace EatingApp.Core.Abstractions.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAll();

        public UserDto GetById(int id);

        public UserDto Insert(UserDto user);

        public void Update(UserDto user);

        public void Delete(int userId);


    }
}
