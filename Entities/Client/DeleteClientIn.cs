using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Client
{
    public class DeleteClientIn : BaseIn
    {
        public int ClientId { get; set; }
    }
}
