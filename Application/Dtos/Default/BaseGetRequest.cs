﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Default
{
    public class BaseGetRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchInput { get; set; }
    }
}
