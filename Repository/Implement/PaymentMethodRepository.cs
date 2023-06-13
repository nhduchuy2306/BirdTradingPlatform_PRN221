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
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IMapper _mapper;

        public PaymentMethodRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PaymentMethodDTO GetPaymentMethodByUserId(int userId)
        {
            PaymentMethod paymentMethod = PaymentMethodDAO.GetPaymentMethodByUserId(userId);
            return _mapper.Map<PaymentMethodDTO>(paymentMethod);
        }
    }
}