using PL.Presentation.Interfaces;
using PL.Presentation.Controllers;
using System;

namespace PL
{
    public class Start
    {
        private IDeliveryController controller;

        public Start()
        {
            controller = new DeliveryController();
        }

        public void Run()
        {
            Console.WriteLine("\nSelect an option:\n" +
                "1 - Show menu\n" +
                "2 - Show menu by category\n" +
                "3 - Show menu by day\n" +
                "4 - Show complex lunch\n" +
                "5 - Order a complex lunch\n" +
                "6 - Select dishes and order them\n");

            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (a)
            {
                case 1:
                    controller.ShowMenu();
                    break;
                case 2:
                    controller.ShowMenuByCategory();
                    break;
                case 3:
                    controller.ShowMenuByDay();
                    break;
                case 4:
                    controller.ShowComplex();
                    break;
                case 5:
                    controller.CreateOrderComplex();
                    break;
                case 6:
                    controller.CreateOrder();
                    break;
                case 7:
                    controller.ShowOrders();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            Run();
        }
    }
}
