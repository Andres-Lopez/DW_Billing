using DataAccess.DW.DataAccess;
using Entities.Order;
using Services.DW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        OrderSL client = new OrderSL(new OrderDA());

        [HttpPost]
        public IHttpActionResult CreateOrder(CreateOrderIn input)
        {
            var response = client.CreateOrder(input);
            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult DeleteOrder(DeleteOrderIn input)
        {
            var response = client.DeleteOrder(input);
            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult UpdateOrderIn(UpdateOrderIn input)
        {
            var response = client.UpdateOrder(input);
            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult CreateProductOrder(CreateProductOrderIn input)
        {
            var response = client.CreateProductOrder(input);
            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetAllOrders(GetAllOrdersIn input)
        {
            var response = client.GetAllOrders(input);
            return Ok(response);
        }
    }
}
