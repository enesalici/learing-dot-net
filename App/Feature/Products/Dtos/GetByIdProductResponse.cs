﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Dtos
{
    public class GetByIdProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int stock { get; set; }
    }
}
