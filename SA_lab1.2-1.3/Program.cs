using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_lab1._2_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Desktop desktop = new Desktop(400, 300, 16, 2.6f, 3.0f);
            Mobile mobile = new Mobile(200, 150, 8, 2.0f, 2.4f);

            Console.WriteLine("Installing Adventure on the desktop:");
            desktop.InstallGame(GameID.Adventure);
            Console.WriteLine();

            Console.WriteLine("Installing Strategy on the mobile:");
            mobile.InstallGame(GameID.Strategy);
            Console.WriteLine();

            Console.WriteLine("Installing RPG on the mobile:");
            mobile.InstallGame(GameID.RPG);

            Console.WriteLine();

            Console.WriteLine("Start playing Adventure on the desktop:");
            desktop.Play(GameID.Adventure);
            Console.WriteLine();

            Console.WriteLine("Start playing Strategy on the desktop:");
            desktop.Play(GameID.Strategy);
            Console.WriteLine();


            Console.WriteLine("Start playing RPG on the mobile:");
            mobile.Play(GameID.RPG);

            Console.WriteLine();

            Console.WriteLine("Connecting manipulators:");
            mobile.ConnectManipulator(new Manipulator());
            mobile.ConnectManipulator(new Manipulator());

            Console.WriteLine();

            Console.WriteLine("Start playing RPG on the mobile:");
            mobile.Play(GameID.RPG);

            Console.WriteLine();

            mobile.Broadcast();
        }
    }
}
