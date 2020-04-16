using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class DeleteProductIn : BaseIn
    {
        public int ProductId { get; set; }
    }
}
