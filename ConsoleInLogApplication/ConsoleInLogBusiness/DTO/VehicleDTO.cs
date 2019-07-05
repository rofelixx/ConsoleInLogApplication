using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInLogBusiness.DTO
{
    public class VehicleDTO
    {
        public ChassisDTO Chassis { get; set; }
        public VehicleType Type { get; set; }
        public string Color { get; set; }
        public string ChassisNumber { get; set; }
    }
}
