using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Product;
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
    public class ProductDA : IProductDA
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CreateProductOut CreateProduct(CreateProductIn input)
        {
            CreateProductOut response = new CreateProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProductId", input.product.ProductId);
                param.Add("@Name", input.product.Name);
                param.Add("@Quantity", input.product.Quantity);
                param.Add("@Price", input.product.Price);
                param.Add("@Operation", 1);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Product", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public DeleteProductOut DeleteProduct(DeleteProductIn input)
        {
            DeleteProductOut response = new DeleteProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProductId", input.ProductId);
                param.Add("@Name", null);
                param.Add("@Quantity", null);
                param.Add("@Price", null);
                param.Add("@Operation", 2);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Product", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetAllProductsOut GetAllProduct(GetAllProductsIn input)
        {
            GetAllProductsOut response = new GetAllProductsOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Product>("SELECT [ProductId] ,[Name] ,[Quantity] ,[Price] ,[CreationDate] FROM [tbl_Product] ORDER BY CreationDate DESC");

                var productList = new List<Product>();
                foreach (var i in data)
                {
                    var product = new Product()
                    {
                        ProductId = i.ProductId,
                        Name = i.Name,
                        Quantity = i.Quantity,
                        Price = i.Price,
                        CreationDate = i.CreationDate

                    };

                    productList.Add(product);
                }

                response.product = productList;

                if (response.product.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetProductFilterOut GetProductFilter(GetProductFilterIn input)
        {
            GetProductFilterOut response = new GetProductFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Product>("SELECT [ProductId] ,[Name] ,[Quantity] ,[Price] ,[CreationDate] FROM [tbl_Product] WHERE Name LIKE '%"+input.Name+"%' ORDER BY CreationDate DESC");

                var productList = new List<Product>();
                foreach (var i in data)
                {
                    var product = new Product()
                    {
                        ProductId = i.ProductId,
                        Name = i.Name,
                        Quantity = i.Quantity,
                        Price = i.Price,
                        CreationDate = i.CreationDate

                    };

                    productList.Add(product);
                }

                response.product = productList;

                if (response.product.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }
        public UpdateProductOut UpdateProduct(UpdateProductIn input)
        {
            UpdateProductOut response = new UpdateProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProductId", input.product.ProductId);
                param.Add("@Name", input.product.Name);
                param.Add("@Quantity", input.product.Quantity);
                param.Add("@Price", input.product.Price);
                param.Add("@Operation", 3);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Product", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }
    }
}
