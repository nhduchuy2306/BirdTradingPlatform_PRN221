<<<<<<< Updated upstream
using BussinessObject.Models;
=======
>>>>>>> Stashed changes
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPaymentMethodRepository
    {
<<<<<<< Updated upstream
        PaymentMethodDTO GetPaymentMethodById(int? paymentMethodId);
=======
>>>>>>> Stashed changes
        PaymentMethodDTO GetPaymentMethodByUserId(int userId);
    }
}