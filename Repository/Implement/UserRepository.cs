using AutoMapper;
using BussinessObject.Models;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public class UserRepository : IUserRepository
    {

        private IMapper mapper;

        public UserRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public UserDTO GetUserByAccountId(int id)
        {
            User user = UserDAO.GetUserByAccountId(id);
            return mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserById(int userId)
        {
            User user = UserDAO.GetUserById(userId);
            return mapper.Map<UserDTO>(user);
        }
    }
}