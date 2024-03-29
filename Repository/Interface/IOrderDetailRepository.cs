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
        List<OrderDetailDTO> GetOrderDetailByOrderId(int id);
        List<OrderDetailDTO> GetOrderDetailByOrderShopId(int orderShopId);

        void UpdateOrderDetail(OrderDetailDTO orderDetailDTO);

        OrderDetailDTO GetOrderDetailId(int id);

        bool CheckIsExistProductInOrderDetail(int productId);

    }
}