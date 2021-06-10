using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string DeleteBicycle(int id)
        {
            if (!bicycleManagementService.Delete(id))
            {
                return "Bicycle is not deleted!";
            }
            else
            {
                return "Bicycle successfully deleted!";
            }
        }

        public string DeleteBuyer(int id)
        {
            if (!buyerManagementService.Delete(id))
            {
                return "Buyer is not deleted!";
            }
            else
            {
                return "Buyer successfully deleted!";
            }
        }

        public string DeleteOrder(int id)
        {
            if (!orderManagementService.Delete(id))
            {
                return "Order is not deleted!";
            }
            else
            {
                return "Order successfully deleted!";
            }
        }

        public List<BicycleDTO> GetBicycles(string query)
        {
            return bicycleManagementService.Get(query);
        }

        public List<BuyerDTO> GetBuyers(string query)
        {
            return buyerManagementService.Get(query);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<OrderDTO> GetOrders(string query)
        {
            return orderManagementService.Get(query);
        }


        private BicycleManagementService bicycleManagementService = new BicycleManagementService();

        private BuyerManagementService buyerManagementService = new BuyerManagementService();

        private OrderManagementService orderManagementService = new OrderManagementService();

        public string PostBicycle(BicycleDTO bicycleDTOs)
        {
            if (!bicycleManagementService.Save(bicycleDTOs))
            {
                return "Bicycle is not saved!";
            }
            else
            {
                return "Bicycle successfully saved!";
            }
        }


        public string PostBuyer(BuyerDTO buyerDTOs)
        {
            if (!buyerManagementService.Save(buyerDTOs))
            {
                return "Buyer is not saved!";
            }
            else
            {
                return "Buyer successfully saved!";
            }
        }

        public string PostOrder(OrderDTO orderDTOs)
        {
            if (!orderManagementService.Save(orderDTOs))
            {
                return "Order is not saved!";
            }
            else
            {
                return "Order successfully saved!";
            }
        }

        public BicycleDTO GetBicycleById(int id)
        {
            return bicycleManagementService.GetById(id);
        }

        public BuyerDTO GetBuyerById(int id)
        {
            return buyerManagementService.GetById(id);
        }

        public OrderDTO GetOrderById(int id)
        {
            return orderManagementService.GetById(id);
        }
    }
}