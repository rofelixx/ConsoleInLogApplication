using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleInLogBusiness.Business.Interface;
using ConsoleInLogBusiness.DTO;

namespace ConsoleInLogBusiness.Business
{
    public class VehicleBusiness : IVehicleBusiness
    {
        public string typeStr = "Write a model by number 1) BUS, 2) TRUCK ";
        public string typeDescription = "Types: 1) BUS, 2) TRUCK";

        public void AddNewVehicle(List<VehicleDTO> ListVehicle)
        {
            var vehicle = new VehicleDTO();
            Console.WriteLine();
            Console.WriteLine("******************| Insert new Vehicle |***********************");
            Console.WriteLine();
            while (vehicle.ChassisNumber == string.Empty || vehicle.ChassisNumber == null)
            {
                Console.WriteLine("Enter a Chassi Number: ");
                vehicle.ChassisNumber = (Console.ReadLine());
            }
            //Check if there is already the item informed
            if (!ListVehicle.Any(a => a.ChassisNumber.Contains(vehicle.ChassisNumber)))
            {
                bool correctType = false;
                var type = string.Empty;
                Console.WriteLine(typeStr);
                type = Console.ReadLine();
                while (!correctType)
                {
                    switch (type)
                    {
                        case "1":
                            vehicle.Type = VehicleType.Bus;
                            correctType = true;
                            break;
                        case "2":
                            vehicle.Type = VehicleType.Truck;
                            correctType = true;
                            break;
                        default:
                            Console.WriteLine(typeStr);
                            type = Console.ReadLine();
                            break;
                    }
                }

                while (vehicle.Color == string.Empty || vehicle.Color == null)
                {
                    Console.WriteLine("Type vehicle color: ");
                    vehicle.Color = Console.ReadLine();
                }

                ListVehicle.Add(vehicle);
                Logging("Vehicle with chassi number " + vehicle.ChassisNumber + " inserted successfully");
                Console.WriteLine();
                Console.WriteLine("Vehicle inserted successfully");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue .. ");
            }
            else
            {
                Console.WriteLine("Vehicle already exists, please insert a new chassis");
                Console.WriteLine("Press any key to continue .. ");
            }
        }

        public void EditVehicle(List<VehicleDTO> ListVehicle)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("***********************| Edit Vehicle |***********************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter a Chassi Number: ");
            var chassiNumber = Console.ReadLine();
            //Check if there is an equal item
            if (ListVehicle.Any(a => a.ChassisNumber == chassiNumber))
            {
                var vehicle = ListVehicle
                             .Where(w => w.ChassisNumber == chassiNumber)
                             .Select(s => new VehicleDTO
                             {
                                 ChassisNumber = s.ChassisNumber,
                                 Color = s.Color,
                                 Type = s.Type
                             }).FirstOrDefault();

                Console.WriteLine("Chassi Number: " + vehicle.ChassisNumber);
                Console.WriteLine("Vehicle Color: " + vehicle.Color);

                int opcao = 0;
                bool isNumber = false;
                int number;

                Console.WriteLine();
                Console.WriteLine("[ 1 ] Edit color");
                Console.WriteLine("[ 2 ] Cancel");
                Console.WriteLine("");

                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    isNumber = number > 0 ? isNumber = true : isNumber = false;
                }
                if (isNumber)
                {
                    opcao = number;
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Type a new vehicle color: ");
                            var color = Console.ReadLine();
                            EditColor(ListVehicle, chassiNumber, color);
                            Console.WriteLine("Vehicle edited successfully");
                            Console.WriteLine("Press any key to continue .. ");
                            break;
                        case 2:
                            Console.WriteLine("Press any key to continue .. ");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Chassis number doesn't exists, please try again");
                Console.WriteLine("Press any key to continue .. ");
            }

        }

        public void EditColor(List<VehicleDTO> ListVehicle, string chassiNumber, string newColor)
        {
            var vehicle = ListVehicle.Where(w => w.ChassisNumber == chassiNumber).FirstOrDefault();
            vehicle.Color = newColor;
            Logging("Vehicle with chassi " + chassiNumber + " edited successfully");
        }

        public void DeleteVehicle(List<VehicleDTO> ListVehicle)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("******************| Delete Vehicle |***********************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter a Chassi Number: ");
            var chassiNumber = Console.ReadLine();
            if (ListVehicle.Any(a => a.ChassisNumber == chassiNumber))
            {
                Console.WriteLine("Are you sure you want to delete this vehicle? (y/n)");
                var confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    var vehicle = ListVehicle.Where(w => w.ChassisNumber == chassiNumber).FirstOrDefault();
                    ListVehicle.Remove(vehicle);
                    Logging("Vehicle with chassi " + chassiNumber + " deleted successfully");
                    Console.WriteLine("Vehicle has been deleted");
                    Console.WriteLine("Press any key to continue .. ");
                }
                else
                {
                    Console.WriteLine("Cancelled");
                    Console.WriteLine("Press any key to continue .. ");
                }

            }
            else
            {
                Console.WriteLine("Chassis number doesn't exists, please try again");
                Console.WriteLine("Press any key to continue .. ");
            }
        }

        public void ListAllVehicles(List<VehicleDTO> ListVehicle)
        {
            Console.WriteLine();
            Console.WriteLine("******************| List all Vehicles |***********************");
            Console.WriteLine();
            Console.WriteLine(typeDescription);
            Console.WriteLine();

            var i = 1;
            foreach (var item in ListVehicle)
            {
                Console.WriteLine("******************| Vehicle " + i + " |***********************");
                Console.WriteLine("Chassi Number: " + item.ChassisNumber);
                Console.WriteLine("Vehicle Color: " + item.Color);
                Console.WriteLine("Vehicle Type: " + item.Type);
                Console.WriteLine();
                i++;
            }
            Logging("List All vehicles");

            Console.WriteLine("Press any key to continue .. ");
        }

        public void FindVehicleByChassi(List<VehicleDTO> ListVehicle)
        {
            Console.WriteLine();
            Console.WriteLine("******************| Find vehicle by Chassi |***********************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter a Chassi Number: ");
            var chassiNumber = Console.ReadLine();
            //check if there is an equal item and list item
            if (ListVehicle.Any(a => a.ChassisNumber == chassiNumber))
            {
                var vehicle = ListVehicle
                          .Where(w => w.ChassisNumber == chassiNumber)
                          .Select(s => new VehicleDTO
                          {
                              ChassisNumber = s.ChassisNumber,
                              Color = s.Color,
                              Type = s.Type
                          }).FirstOrDefault();

                Logging("Find vehicle by Chassi Number " + chassiNumber);

                Console.WriteLine("Chassi Number: " + vehicle.ChassisNumber);
                Console.WriteLine("Vehicle Color: " + vehicle.Color);
                Console.WriteLine("Vehicle Type: " + vehicle.Type);
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Press any key to continue .. ");
            }
            else
            {
                Console.WriteLine("Chassis number doesn't exists, please try again");
                Console.WriteLine("Press any key to continue .. ");
            }

        }

        public bool ExitProgram()
        {
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to quit? (y/n)");
            var confirm = Console.ReadLine();
            if (confirm == "y")
            {
                Logging("Exit Program in");
                Environment.Exit(0);
                return true;
            }
            else
            {
                Console.WriteLine("Cancelled");
                return false;
            }
        }

        public void Logging(string Action)
        {
            // Create a writer and open the file:
            StreamWriter log;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!File.Exists(path + @"\Logfile.txt"))
            {
                log = new StreamWriter(path + @"\Logfile.txt");
            }
            else
            {
                log = File.AppendText(path + @"\Logfile.txt");
            }

            // Write to the file:
            log.WriteLine(Action + " - " + DateTime.Now);
            log.WriteLine();

            // Close the stream:
            log.Close();
        }
    }
}
