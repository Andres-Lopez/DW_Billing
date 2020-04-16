using DataAccess.DW.DataAccess.Interfaces;
using Entities.Client;
using Services.DW.Services.Interfaces.ClientSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.ClientSL
{
    public class ClientSL : IClientSL
    {

        public IClientDA clientDA;
        public ClientSL(IClientDA clientDA)
        {
            this.clientDA = clientDA;
        }

        public CreateClientOut CreateClient(CreateClientIn input)
        {
            return clientDA.CreateClient(input);
        }

        public DeleteClientOut DeleteClient(DeleteClientIn input)
        {
            return clientDA.DeleteClient(input);
        }

        public GetAllClientsOut GetAllClients(GetAllClientsIn input)
        {
            return clientDA.GetAllClients(input);
        }

        public GetClientFilterOut GetClientFilterEmail(GetClientFilterIn input)
        {
            return clientDA.GetClientFilterEmail(input);
        }

        public GetClientFilterOut GetClientFilterLastName(GetClientFilterIn input)
        {
            return clientDA.GetClientFilterLastName(input);
        }

        public GetClientFilterOut GetClientFilterName(GetClientFilterIn input)
        {
            return clientDA.GetClientFilterName(input);
        }

        public UpdateClientOut UpdateClient(UpdateClientIn input)
        {
            return clientDA.UpdateClient(input);
        }
    }
}
