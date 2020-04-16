using DataAccess.DW.DataAccess;
using Entities.Client;
using Services.DW.Services.ClientSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ClientController : ApiController
    {
        ClientSL client = new ClientSL(new ClientDA());

        [HttpPost]
        public IHttpActionResult CreateClient(CreateClientIn input)
        {
            var response = client.CreateClient(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult DeleteClient(DeleteClientIn input)
        {
            var response = client.DeleteClient(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult UpdateClient(UpdateClientIn input)
        {
            var response = client.UpdateClient(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetAllClients(GetAllClientsIn input)
        {
            var response = client.GetAllClients(input);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetClientFilterName(GetClientFilterIn input)
        {
            var response = client.GetClientFilterName(input);

            return Ok(response);
        }
        [HttpPost]
        public IHttpActionResult GetClientFilterLastName(GetClientFilterIn input)
        {
            var response = client.GetClientFilterLastName(input);

            return Ok(response);
        }
        [HttpPost]
        public IHttpActionResult GetClientFilterEmail(GetClientFilterIn input)
        {
            var response = client.GetClientFilterEmail(input);

            return Ok(response);
        }
    }
}
