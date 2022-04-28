using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arch_lab1._2_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Device laptop = new Desktop();
            Desktop desktop = new Desktop(400, 300, 8, 1.8f, 2.2f);
            Mobile mobile = new Mobile(200, 150, 8, 2.0f, 2.4f);

            Console.WriteLine(laptop.TechnicalCharacteristics.HDDCapacity);
            Console.WriteLine(mobile.TechnicalCharacteristics.HDDUsage);
            Console.WriteLine(desktop.TechnicalCharacteristics.GraphCardSpeed);

            Console.WriteLine();

            desktop.InstallGame((GameID)4); // ERROR: Invalid input. Try again
            desktop.InstallGame(GameID.Strategy);
            desktop.InstallGame(GameID.Adventure);
            mobile.InstallGame(GameID.Strategy);

            Console.WriteLine();

            desktop.Play(GameID.Adventure); // ERROR: Device's technical characteristics are too low
            Console.WriteLine();
            desktop.Play(GameID.Strategy); // Nothing to load. Starting new game. Strategy is running
            Console.WriteLine();
            desktop.Play(GameID.Strategy); // Strategy was loaded. Continue playing. Strategy is running
            Console.WriteLine();
            laptop.Play(GameID.Strategy); // ERROR: The game is not installed
        }
    }
}
