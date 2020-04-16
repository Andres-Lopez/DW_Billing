using Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.Interfaces.ClientSL
{
    public interface IClientSL
    {
        CreateClientOut CreateClient(CreateClientIn input);
        DeleteClientOut DeleteClient(DeleteClientIn input);
        UpdateClientOut UpdateClient(UpdateClientIn input);
        GetAllClientsOut GetAllClients(GetAllClientsIn input);

        GetClientFilterOut GetClientFilterName(GetClientFilterIn input);
        GetClientFilterOut GetClientFilterLastName(GetClientFilterIn input);
        GetClientFilterOut GetClientFilterEmail(GetClientFilterIn input);
    }
}
