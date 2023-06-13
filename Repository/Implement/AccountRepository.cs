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
    public class AccountRepository : IAccountRepository
    {

        private readonly IMapper _mapper;

        public AccountRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AccountDTO GetAccountByPhoneNumberAndPassword(string phoneNumber, string password)
        {
            Account account = AccountDAO.GetAccountByPhoneNumberAndPassword(phoneNumber, password);
            return _mapper.Map<AccountDTO>(account);
        }
    }
}
