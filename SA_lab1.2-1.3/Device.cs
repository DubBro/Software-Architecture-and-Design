using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arch_lab1._2_1._3
{
    abstract class Device
    {
        protected TechnicalCharacteristics technicalCharacteristics;
        private List<Game> games = new List<Game>();

        public TechnicalCharacteristics TechnicalCharacteristics
        {
            get
            {
                return technicalCharacteristics;
            }
        }

        public void InstallGame(GameID gameID)
        {
            Game game = Game.Install(gameID, this);
            if (game != null)
            {
                games.Add(game);
                technicalCharacteristics.HDDUsage = technicalCharacteristics.HDDUsage + game.Requirements.HDDUsage;
                Console.WriteLine("The game has been installed successfully");
            }
        }

        public void Play(GameID gameID)
        {
            if (gameID == GameID.Strategy)
            {
                Game strategy = games.Find(game => game is Strategy);

                if (strategy == null)
                {
                    Console.WriteLine("ERROR: The game is not installed");
                    return;
                }

                if (technicalCharacteristics.RAMCapacity >= strategy.Requirements.RAMUsage &&
                    technicalCharacteristics.GraphCardSpeed >= strategy.Requirements.GraphCardUsage &&
                    technicalCharacteristics.ProcessorSpeed >= strategy.Requirements.ProcessorUsage)
                {
                    strategy.Play();
                }
                else
                {
                    Console.WriteLine("ERROR: Device's technical characteristics are too low");
                }
            }
            else if (gameID == GameID.Adventure)
            {
                Game adventure = games.Find(game => game is Adventure);

                if (adventure == null)
                {
                    Console.WriteLine("ERROR: The game is not installed");
                    return;
                }

                if (technicalCharacteristics.RAMCapacity >= adventure.Requirements.RAMUsage &&
                    technicalCharacteristics.GraphCardSpeed >= adventure.Requirements.GraphCardUsage &&
                    technicalCharacteristics.ProcessorSpeed >= adventure.Requirements.ProcessorUsage)
                {
                    adventure.Play();
                }
                else
                {
                    Console.WriteLine("ERROR: Device's technical characteristics are too low");
                }
            }
            else if (gameID == GameID.RPG)
            {
                Game rpg = games.Find(game => game is RPG);

                if (rpg == null)
                {
                    Console.WriteLine("ERROR: The game is not installed");
                    return;
                }

                if (technicalCharacteristics.RAMCapacity >= rpg.Requirements.RAMUsage &&
                    technicalCharacteristics.GraphCardSpeed >= rpg.Requirements.GraphCardUsage &&
                    technicalCharacteristics.ProcessorSpeed >= rpg.Requirements.ProcessorUsage)
                {
                    rpg.Play();
                }
                else
                {
                    Console.WriteLine("ERROR: Device's technical characteristics are too low");
                }
            }
            else
            {
                Console.WriteLine("ERROR: Invalid input. Try again");
            }
        }
    }

    class Desktop : Device
    {
        public Desktop()
        {
            technicalCharacteristics = new TechnicalCharacteristics();
        }

        public Desktop(int hddCapacity, int hddUsage, int ramCapacity, float graphCardSpeed, float processorSpeed)
        {
            technicalCharacteristics = new TechnicalCharacteristics(hddCapacity, hddUsage, ramCapacity, graphCardSpeed, processorSpeed);
        }
    }

    class Mobile : Device
    {
        public Mobile()
        {
            technicalCharacteristics = new TechnicalCharacteristics();
        }

        public Mobile(int hddCapacity, int hddUsage, int ramCapacity, float graphCardSpeed, float processorSpeed)
        {
            technicalCharacteristics = new TechnicalCharacteristics(hddCapacity, hddUsage, ramCapacity, graphCardSpeed, processorSpeed);
        }

        public void Broadcast()
        {
            Console.WriteLine(this.GetType().Name + " is broadcasting");
        }
    }
}
