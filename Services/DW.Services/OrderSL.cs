﻿using DataAccess.DW.DataAccess.Interfaces;
using Entities.Order;
using Services.DW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services
{
    public class OrderSL : IOrderSL
    {
        public IOrderDA orderDA;
        public OrderSL(IOrderDA orderDA)
        {
            this.orderDA = orderDA;
        }
        public CreateOrderOut CreateOrder(CreateOrderIn input)
        {
            return orderDA.CreateOrder(input);
        }

        public CreateProductOrderOut CreateProductOrder(CreateProductOrderIn input)
        {
            return orderDA.CreateProductOrder(input);
        }

        public DeleteOrderOut DeleteOrder(DeleteOrderIn input)
        {
            return orderDA.DeleteOrder(input);
        }

        public GetAllOrdersOut GetAllOrders(GetAllOrdersIn input)
        {
            return orderDA.GetAllOrders(input);
        }

        public UpdateOrderOut UpdateOrder(UpdateOrderIn input)
        {
            return orderDA.UpdateOrder(input);
        }
    }
}
