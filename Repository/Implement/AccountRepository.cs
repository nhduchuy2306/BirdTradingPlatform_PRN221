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

        public bool AddNewAccount(AccountDTO account)
        {
            Account account1 = _mapper.Map<Account>(account);
            return AccountDAO.AddNewAccount(account1);
        }

        public bool UpdateAccount(AccountDTO account)
        {
            Account account1 = _mapper.Map<Account>(account);
            return AccountDAO.UpdateAccount(account1);
        }

        public AccountDTO GetAccountByPhoneNumberAndPassword(string phoneNumber, string password)
        {
            Account account = AccountDAO.GetAccountByPhoneNumberAndPassword(phoneNumber, password);
            return _mapper.Map<AccountDTO>(account);
        }

        public bool IsPhoneNumberExited(string phoneNumber)
        {
            return AccountDAO.IsPhoneNumberExisted(phoneNumber);
        }

        public bool IsPhoneNumberExited(string phoneNumber, int userId)
        {
            return AccountDAO.IsPhoneNumberExisted(phoneNumber, userId);
        }

        public AccountDTO GetAccountByUserId(int userId)
        {
            Account account = AccountDAO.GetAccountByUserId(userId);
            return _mapper.Map<AccountDTO>(account);
        }
    }
}
