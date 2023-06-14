using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(OrderDetailDTO orderDetailDTO);
<<<<<<< Updated upstream
        List<OrderDetailDTO> GetOrderDetailByOrderId(int id);
=======
>>>>>>> Stashed changes
    }
}