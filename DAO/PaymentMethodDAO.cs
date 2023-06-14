using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PaymentMethodDAO
    {
<<<<<<< Updated upstream
        public static PaymentMethod GetPaymentMethodById(int? paymentMethodId)
        {
            PaymentMethod paymentMethod = null;
            try
            {
                using var context = new BirdTradingPlatformContext();
                paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == paymentMethodId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentMethod;
        }

=======
>>>>>>> Stashed changes
        public static PaymentMethod GetPaymentMethodByUserId(int userId)
        {
            PaymentMethod paymentMethod = null;
            try
            {
                using var context = new BirdTradingPlatformContext();
                paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.UserId == userId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentMethod;
        }
    }
}