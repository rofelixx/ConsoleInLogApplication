using System;
using System.Collections.Generic;
using System.Text;
using ConsoleInLogBusiness.DTO;

namespace ConsoleInLogBusiness.Business.Interface
{
    public interface IVehicleBusiness
    {
        void AddNewVehicle(List<VehicleDTO> ListVehicle);


        void EditVehicle(List<VehicleDTO> ListVehicle);


        void DeleteVehicle(List<VehicleDTO> ListVehicle);


        void ListAllVehicles(List<VehicleDTO> ListVehicle);


        void FindVehicleByChassi(List<VehicleDTO> ListVehicle);


        bool ExitProgram();
    }
}
