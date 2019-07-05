using System;
using System.Collections.Generic;
using ConsoleInLogBusiness.DTO;

namespace ConsoleInLogApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var ListVehicles = new List<VehicleDTO>();

            var ConsoleInLogBusiness = new ConsoleInLogBusiness.Business.VehicleBusiness();
            int opcao = 0;
            bool isNumber = false;
            int number;
            bool exit = false;
            do
            {
                Console.WriteLine("******************| InLog Console Application |***********************");
                Console.WriteLine();
                Console.WriteLine("[ 1 ] Insert a new vehicle");
                Console.WriteLine("[ 2 ] Edit an existing vehicle");
                Console.WriteLine("[ 3 ] Delete an existing vehicle");
                Console.WriteLine("[ 4 ] List all vehicles");
                Console.WriteLine("[ 5 ] Find vehicle by chassis");
                Console.WriteLine("[ 6 ] Exit");
                Console.WriteLine("-------------------------------------");
                Console.Write("Type a number between 1 and 6: ");

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
                            ConsoleInLogBusiness.AddNewVehicle(ListVehicles);
                            break;
                        case 2:
                            ConsoleInLogBusiness.EditVehicle(ListVehicles);
                            break;
                        case 3:
                            ConsoleInLogBusiness.DeleteVehicle(ListVehicles);
                            break;
                        case 4:
                            ConsoleInLogBusiness.ListAllVehicles(ListVehicles);
                            break;
                        case 5:
                            ConsoleInLogBusiness.FindVehicleByChassi(ListVehicles);
                            break;
                        case 6:
                            exit = ConsoleInLogBusiness.ExitProgram();
                            Console.WriteLine("Press any key to continue .. ");
                            break;
                        default:
                            Console.WriteLine("Incorrect number, Please write a number between 1 and 6 ");
                            Console.WriteLine("Press any key to continue .. ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number, Please write a number between 1 and 6 ");
                    Console.WriteLine("Press any key to continue .. ");
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (!exit);
        }
    }
}
