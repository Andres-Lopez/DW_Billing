using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Client.General
{
    public class BaseOut
    {
        public ResponseCode ResponseCode;
    }

    public enum ResponseCode
    {
        Success,
        Error
    }
}
