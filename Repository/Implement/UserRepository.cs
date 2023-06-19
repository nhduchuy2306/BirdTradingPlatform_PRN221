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

        public bool AddNewUser(UserDTO user)
        {
            User user2 = mapper.Map<User>(user);
            return UserDAO.AddNewUser(user2);
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

        public bool IsEmailExisted(string email)
        {
            return UserDAO.IsEmailExisted(email);
        }

        public bool IsEmailExisted(string email, int userId)
        {
            return UserDAO.IsEmailExisted(email, userId);
        }

        public bool UpdateUser(UserDTO user)
        {
            User user2 = mapper.Map<User>(user);
            return UserDAO.UpdateUser(user2);
        }
    }
}