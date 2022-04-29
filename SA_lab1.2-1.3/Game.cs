using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        protected const string savePath = "LastSave.txt";
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
                    Console.WriteLine("ERROR: This device does not support the game");
                    return null;
                }

                Strategy strategy = new Strategy();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= strategy.requirements.HDDUsage)
                {
                    return strategy;
                }

                Console.WriteLine("ERROR: Not enough space in the device memory");
                return null;
            }
            else if (game == GameID.Adventure)
            {
                Adventure adventure = new Adventure();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= adventure.requirements.HDDUsage)
                {
                    return adventure;
                }

                Console.WriteLine("ERROR: Not enough space in the device memory");
                return null;
            }
            else if (game == GameID.RPG)
            {
                RPG rpg = new RPG();

                if ((device.TechnicalCharacteristics.HDDCapacity - device.TechnicalCharacteristics.HDDUsage) >= rpg.requirements.HDDUsage)
                {
                    return rpg;
                }

                Console.WriteLine("ERROR: Not enough space in the device memory");
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
            Load();
            Console.WriteLine(GetType().Name + " is running");
            Save();
        }

        // Each game has its own params to save, so each game has different function Save()
        // Therefore Save() is virtual
        protected virtual void Save()
        {
            string exmplParams = this.GetType().Name;

            using (FileStream instream = File.Create(savePath))
            { 
                byte[] stream = System.Text.Encoding.Default.GetBytes(exmplParams);
                instream.Write(stream, 0, stream.Length);
            }
        }

        // Each game has its own params to load, so each game has different function Load()
        // Therefore Load() is virtual
        protected virtual void Load()
        {
            if (File.Exists(savePath))
            {
                string exmplParams;

                using (FileStream outstream = File.OpenRead(savePath))
                {
                    byte[] stream = new byte[outstream.Length];
                    outstream.Read(stream, 0, stream.Length);
                    exmplParams = System.Text.Encoding.Default.GetString(stream);
                }

                Console.WriteLine(exmplParams + " was loaded. Continue playing.");
            } 
            else 
            {
                Console.WriteLine("Nothing to load. Starting new game.");
            }
        }
    }

    class Strategy : Game
    {
        public Strategy()
        {
            requirements = new Requirements(20, 4, 1.6f, 2.0f);
        }
        
        // Need to rewrite according to params of this game
        protected override void Save()
        {
            base.Save();
        }

        // Need to rewrite according to params of this game
        protected override void Load()
        {
            base.Load();
        }
    }

    class Adventure : Game
    {
        public Adventure()
        {
            requirements = new Requirements(50, 8, 2.0f, 2.4f);
        }

        // Need to rewrite according to params of this game
        protected override void Save()
        {
            base.Save();
        }

        // Need to rewrite according to params of this game
        protected override void Load()
        {
            base.Load();
        }
    }

    class RPG : Game
    {
        public RPG()
        {
            requirements = new Requirements(40, 8, 1.8f, 2.2f);
        }

        // Need to rewrite according to params of this game
        protected override void Save()
        {
            base.Save();
        }

        // Need to rewrite according to params of this game
        protected override void Load()
        {
            base.Load();
        }

        void SinglePlay()
        {

        }

        void MultiPlay()
        {

        }
    }
}
