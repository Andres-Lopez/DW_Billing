using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Client;
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
    public class ClientDA : IClientDA
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CreateClientOut CreateClient(CreateClientIn input)
        {
            CreateClientOut response = new CreateClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ClientId", input.client.ClientId);
                param.Add("@FirstName", input.client.FirstName);
                param.Add("@LastName", input.client.LastName);
                param.Add("@Age", input.client.Age);
                param.Add("@Identification", input.client.Identification);
                param.Add("@Email", input.client.Email);
                param.Add("@Operation", 1);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Client", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public DeleteClientOut DeleteClient(DeleteClientIn input)
        {
            DeleteClientOut response = new DeleteClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ClientId", input.ClientId);
                param.Add("@FirstName", null);
                param.Add("@LastName", null);
                param.Add("@Age", null);
                param.Add("@Identification", null);
                param.Add("@Email", null);
                param.Add("@Operation", 2);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Client", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetAllClientsOut GetAllClients(GetAllClientsIn input)
        {
            GetAllClientsOut response = new GetAllClientsOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT [ClientId] ,[FirstName] ,[LastName] ,[Age] ,[Identification] ,[Email] ,[CreationDate] FROM [tbl_Client] ORDER BY CreationDate DESC");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetClientFilterOut GetClientFilterEmail(GetClientFilterIn input)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE Email LIKE'%" + input.Email + "%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetClientFilterOut GetClientFilterLastName(GetClientFilterIn input)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE LastName LIKE'%" + input.LastName + "%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetClientFilterOut GetClientFilterName(GetClientFilterIn input)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE FirstName LIKE'%" + input.FirstName+ "%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public UpdateClientOut UpdateClient(UpdateClientIn input)
        {
            UpdateClientOut response = new UpdateClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@ClientId", input.client.ClientId);
                param.Add("@FirstName", input.client.FirstName);
                param.Add("@LastName", input.client.LastName);
                param.Add("@Age", input.client.Age);
                param.Add("@Identification", input.client.Identification);
                param.Add("@Email", input.client.Email);
                param.Add("@Operation", 3);
                param.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                var data = connection.Execute("SP_Crud_Client", param, commandType: CommandType.StoredProcedure);

                if (param.Get<int>("@RESULT") == 1)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }
    }
}
