﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos
{
    public record CreateCargoCopmanyDto
    {
        public string CargoCompanyName { get; set; }
    }
}
