using BussinessObject.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        UserDTO GetUserByAccountId(int id);
        UserDTO GetUserById(int userId);

        bool IsEmailExisted(string email);

        bool AddNewUser(UserDTO user);

        bool UpdateUser(UserDTO user);

        bool IsEmailExisted(string email, int userId);
    }
}