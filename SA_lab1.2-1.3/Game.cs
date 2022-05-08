using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SA_lab1._2_1._3
{
    enum GameID
    {
        Strategy,
        Adventure,
        RPG,
    }

    abstract class Game
    {
        private IAccount account;
        protected bool isRunning = false;
        public abstract string SavePath { get; set; }
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

        public abstract void Play();

        protected abstract void Save();

        protected abstract void Load();

        protected bool LogInToAccount()
        {
            Console.WriteLine("You need to log in to your account.");
            Console.Write("Enter your nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            account = new Account();

            return account.LogIn(nickname, password);
        }
    }

    class Strategy : Game
    {
        private string savePath = "StrategyLastSave.txt";
        public override string SavePath
        {
            get
            {
                return savePath;
            }
            set
            {
                savePath = value;
            }
        }

        public Strategy()
        {
            requirements = Requirements.GetInstance(20, 4, 1.6f, 2.0f);
        }

        public override void Play()
        {
            if (isRunning == true)
            {
                Console.WriteLine("ERROR: Can't run 2 or more games at the same time");
                return;
            }

            if (!LogInToAccount())
            {
                Console.WriteLine("ERROR: Invalid input. Try again");
                return;
            }
            else
            {
                Console.WriteLine("You have logged in successfully");
            }

            isRunning = true;
            Load();
            Console.WriteLine(GetType().Name + " is running");
            Save();
            isRunning = false;
        }

        protected override void Save()
        {
            string exmplParams = this.GetType().Name;

            using (FileStream instream = File.Create(savePath))
            {
                byte[] stream = System.Text.Encoding.Default.GetBytes(exmplParams);
                instream.Write(stream, 0, stream.Length);
            }
        }

        protected override void Load()
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

    class Adventure : Game
    {
        private string savePath = "AdventureLastSave.txt";
        public override string SavePath 
        {
            get 
            {
                return savePath;
            }
            set 
            {
                savePath = value;
            } 
        }

        public Adventure()
        {
            requirements = Requirements.GetInstance(50, 8, 2.0f, 2.4f);
        }

        public override void Play()
        {
            if (isRunning == true)
            {
                Console.WriteLine("ERROR: Can't run 2 or more games at the same time");
                return;
            }

            if (!LogInToAccount())
            {
                Console.WriteLine("ERROR: Invalid input. Try again");
                return;
            }
            else
            {
                Console.WriteLine("You have logged in successfully");
            }

            isRunning = true;
            Load();
            Console.WriteLine(GetType().Name + " is running");
            Save();
            isRunning = false;
        }

        protected override void Save()
        {
            string exmplParams = this.GetType().Name;

            using (FileStream instream = File.Create(savePath))
            {
                byte[] stream = System.Text.Encoding.Default.GetBytes(exmplParams);
                instream.Write(stream, 0, stream.Length);
            }
        }

        protected override void Load()
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

    class RPG : Game, ISubscriber
    {
        private bool isMultiPlayerAvailable = false;
        private string savePath = "RPGLastSave.txt";
        public override string SavePath
        {
            get
            {
                return savePath;
            }
            set
            {
                savePath = value;
            }
        }

        public RPG()
        {
            requirements = Requirements.GetInstance(40, 8, 1.8f, 2.2f);
        }

        public override void Play()
        {
            if (isRunning == true)
            {
                Console.WriteLine("ERROR: Can't run 2 or more games at the same time");
                return;
            }

            if (!LogInToAccount())
            {
                Console.WriteLine("ERROR: Invalid input. Try again");
                return;
            }
            else
            {
                Console.WriteLine("You have logged in successfully");
            }

            Console.WriteLine("Choose Mode: ");
            Console.WriteLine("1 - Singleplayer");
            Console.WriteLine("2 - Multiplayer");
            Console.Write("Enter number: ");
            string x = Console.ReadLine();
            switch (x)
            {
                case "1":
                    SinglePlay();
                    break;
                case "2":
                    MultiPlay();
                    break;
                default:
                    Console.WriteLine("ERROR: Invalid input. Try again");
                    return;
            }
        }

        private void SinglePlay()
        {
            isRunning = true;
            Load();
            Console.WriteLine(GetType().Name + " is running. Singleplayer mode");
            Save();
            isRunning = false;
        }

        private void MultiPlay()
        {
            if (isMultiPlayerAvailable == false)
            {
                Console.WriteLine("ERROR: Multiplayer mode is unavailable. Please, connect manipulators");
                return;
            }
                
            isRunning = true;
            Load("RPGMultiLastSave.txt");
            Console.WriteLine(GetType().Name + " is running. Multiplayer mode");
            Save("RPGMultiLastSave.txt");
            isRunning = false;
        }

        protected override void Save()
        {
            string exmplParams = this.GetType().Name;

            using (FileStream instream = File.Create(savePath))
            {
                byte[] stream = System.Text.Encoding.Default.GetBytes(exmplParams);
                instream.Write(stream, 0, stream.Length);
            }
        }

        protected override void Load()
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

        // Other func for multiplayer mode
        private void Save(string path)
        {
            string exmplParams = this.GetType().Name + " Multiplayer";

            using (FileStream instream = File.Create(path))
            {
                byte[] stream = System.Text.Encoding.Default.GetBytes(exmplParams);
                instream.Write(stream, 0, stream.Length);
            }
        }

        // Other func for multiplayer mode
        private void Load(string path)
        {
            if (File.Exists(path))
            {
                string exmplParams;

                using (FileStream outstream = File.OpenRead(path))
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

        public void MakeMultiPlayerAvailable()
        {
            isMultiPlayerAvailable = true;
        }
    }
}
