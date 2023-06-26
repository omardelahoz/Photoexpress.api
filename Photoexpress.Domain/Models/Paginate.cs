﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Models
{
    public class Paginate
    {
        public int PageIndex { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }

        public Paginate()
        {
            PageSize = 10;
            PageIndex = 1;
        }
    }
}
