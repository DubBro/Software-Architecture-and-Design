using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arch_lab1._2_1._3
{
    enum GameID
    {
        Strategy,
        Adventure,
        RPG,
    }

    abstract class Game
    {
        protected Requirements requirements;

        public Requirements Requirements
        {
            get
            {
                return requirements;
            }
        }

        public static Game Install(GameID game, Device device)
        {
            if (game == GameID.Strategy)
            {
                if (!(device is Desktop))
                {
                    return null;
                }

                Strategy strategy = new Strategy();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= strategy.requirements.HDDUsage)
                {
                    return strategy;
                }

                return null;
            }
            else if (game == GameID.Adventure)
            {
                Adventure adventure = new Adventure();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= adventure.requirements.HDDUsage)
                {
                    return adventure;
                }

                return null;
            }
            else if (game == GameID.RPG)
            {
                RPG rpg = new RPG();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= rpg.requirements.HDDUsage)
                {
                    return rpg;
                }

                return null;
            }
            else
            {
                Console.WriteLine("ERROR: Invalid input. Try again");
                return null;
            }
        }

        public void Play()
        {
            Console.WriteLine(GetType().Name + " is running");
        }
    }

    class Strategy : Game
    {
        public Strategy()
        {
            requirements = new Requirements(20, 4, 1.6f, 2.0f);
        }
    }

    class Adventure : Game
    {
        public Adventure()
        {
            requirements = new Requirements(50, 8, 2.0f, 2.4f);
        }
    }

    class RPG : Game
    {
        public RPG()
        {
            requirements = new Requirements(40, 8, 1.8f, 2.2f);
        }

        void SinglePlay()
        {

        }

        void MultiPlay()
        {

        }
    }
}
