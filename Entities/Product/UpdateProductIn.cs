﻿using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class UpdateProductIn : BaseIn
    {
        public Product product { get; set; }
    }
}
