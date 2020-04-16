using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Order;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess
{
    public class OrderDA : IOrderDA
    {

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public CreateOrderOut CreateOrder(CreateOrderIn input)
        {
            CreateOrderOut response = new CreateOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@OrderId", input.order.OrderId);
                param.Add("@ClientId", input.order.ClientId);
                param.Add("@Total", input.order.Total);
                param.Add("@Operation", 1);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Order", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") > 0)
                {
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                    response.OrderId = param.Get<int>("@RESULT");
                }
                    

            }

            return response;




        }

        public DeleteOrderOut DeleteOrder(DeleteOrderIn input)
        {
            DeleteOrderOut response = new DeleteOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@OrderId", input.OrderId);
                param.Add("@ClientId", null);
                param.Add("@Total", null);
                param.Add("@Operation", 2);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Order", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public UpdateOrderOut UpdateOrder(UpdateOrderIn input)
        {
            UpdateOrderOut response = new UpdateOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@OrderId", input.order.OrderId);
                param.Add("@ClientId", input.order.ClientId);
                param.Add("@PurchaseDate", input.order.PurchaseDate);
                param.Add("@Total", input.order.Total);
                param.Add("@Operation", 3);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Order", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public CreateProductOrderOut CreateProductOrder(CreateProductOrderIn input)
        {
            CreateProductOrderOut response = new CreateProductOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query("INSERT INTO tbl_ProductOrder(ProductId,OrderId,Quantity,UnitPrice) VALUES('"+input.ProductId+ "'," + input.OrderId + "," + input.Quantity + "," + input.UnitPrice + ")");

                response.ResponseCode = Entities.Client.General.ResponseCode.Success;
            }

            return response;
        }

        public GetAllOrdersOut GetAllOrders(GetAllOrdersIn input)
        {
            GetAllOrdersOut response = new GetAllOrdersOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Order>("SELECT [OrderId] , c.FirstName + ' ' + c.LastName [ClientName], c.ClientId ,[PurchaseDate] ,[Total] FROM tbl_Order o INNER JOIN tbl_Client c ON o.ClientId = c.ClientId ORDER BY PurchaseDate DESC");

                var orderList = new List<Order>();

                foreach (var i in data)
                {
                    var order = new Order()
                    {
                        OrderId = i.OrderId,
                        ClientId = i.ClientId,
                        ClientName = i.ClientName,
                        Total = i.Total,
                        PurchaseDate = i.PurchaseDate,
                        

                    };

                    orderList.Add(order);
                }

                response.order = orderList;

                if (response.order.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }
    }
}
