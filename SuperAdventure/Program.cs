using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace SuperAdventure
{
    class Program
    {
        //              Opgaveliste
        //            Forbedre ScrollMenu
        //            Lave Monsterclasses
        //    
        //    
        //    
        //    
        public List<Monster> monsters = new List<Monster>();
        public Hero hero = new Hero();
        public Art art = new Art();
        public static Random random = new Random((int)DateTime.Now.Millisecond);
        public static List<Town> towns = new List<Town>();
        public static List<Hero> heroes = new List<Hero>();
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        private void Run()
        {
            LoadObjects();
            Console.SetWindowSize(130, 30);
            Console.SetBufferSize(130, 30);
            MainMenu();
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            art.DrawStars(0, 0);
            art.DrawStars(0, 13);
            art.DrawStars(50, 0);
            art.DrawStars(50, 13);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            art.DrawWelcome(11, 3);
            Console.ForegroundColor = ConsoleColor.White;

            art.DrawTree(5, 20);
            art.DrawCastle(85, 15);
            art.DrawFrame(53, 9);
            bool keepGoing = true;
            while (keepGoing)
            {
                
                string[] loginOptions = new string[2] { "Create a Character", "Load existing" };
                UserOptions(2, loginOptions, 54, 10, true, false, true);
                
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (choice)
                {
                    case "x":
                    case "X":
                    case "0":
                        SaveObjects();
                        Environment.Exit(0);
                        break;
                    case "1":
                        LoadingBar();
                        CharacterCreator();
                        keepGoing = false;
                        break;
                    case "2":
                        //LoadingBar();
                        LoadHeroesScreen();
                        keepGoing = false;
                        break;
                    case "3":
                        break;
                    default:
                        CustomWrite("                    ", 50, 14);
                        break;
                }
            }
        }
        private void CharacterCreator()
        {
            Hero newHero = new Hero();
            Console.Clear();
            ScrollMenuString("Welcome to the glorious lands of...", 50, 9);
            Console.CursorVisible = false;
            System.Threading.Thread.Sleep(1000);

            string[] middleEarth = new string[13] { "M", "i", "d", "d", "l", "e", "-", "E", "a", "r", "t", "h", "!" };
            Console.SetCursorPosition(60, 11);
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var obj in middleEarth)
            {
                Console.Write(obj);
                System.Threading.Thread.Sleep(50);
            }
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(1000);

            Console.SetCursorPosition(47, 13);
            Console.WriteLine("Where do you want to start your adventure?");
            int counter = 15;
            foreach (Town town in towns)
            {
                Console.SetCursorPosition(60, counter);
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(town.ID);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") " + town.Name);
                counter++;
            }
            CursorPosition(60, 20);
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice)) { }
            else
            {
                choice = 1;
            }
            foreach (Town town in towns)
            {
                if (town.ID == choice)
                {
                    newHero.town = town;
                }
                if (choice == 0)
                {
                    MainMenu();
                }
            }

            Console.Clear();
            ScrollMenuArray(newHero.town.StartDescription, 50, 9);
            Console.SetCursorPosition(53, 15);
            Console.WriteLine("What is your name, brave hero?");
            CursorPosition(55, 17);
            newHero.FirstName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            ScrollMenuString("Hero! This is where your adventure begins.", 47, 11);
            Console.SetCursorPosition(52, 13);
            Console.WriteLine("Time to venture out into the world,");
            Console.SetCursorPosition(54, 14);
            Console.WriteLine("Where you will be known as...");
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(58, 17);

            Console.CursorVisible = false;
            char[] heroName = newHero.FullName().ToCharArray();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var obj in heroName)
            {
                Console.Write(obj);
                System.Threading.Thread.Sleep(50);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey();
            heroes.Add(newHero);
            SaveObjects();
            hero = newHero;
            HeroMenu();
        }
        private void HeroMenu()
        {
            CheckAndResetWindowSize();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                art.DrawMainMenuFrame(true);

                CustomWrite(hero.town.MenuDescription[0], 8, 6);
                CustomWrite(hero.town.MenuDescription[1], 4, 7);
                ShowHeroStats(hero, 17, 10, true, true);
                string[] heroMenuOptions = new string[2] { "Go explore!", "Go to the shop" };
                UserOptions(2, heroMenuOptions, 17, 16, true, true, false);
                CursorPosition(17, 21);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                    case "x":
                    case "X":
                        keepGoing = false;
                        CustomWrite("  ", 17, 21);
                        MenuOrExit(8, 22);
                        break;
                    case "xx":
                    case "XX":
                        keepGoing = false;
                        Environment.Exit(0);
                        break;
                    case "1":
                        Combat();
                        break;
                    case "2":
                        break;
                    default:
                        break;
                }
            }
        }
        private void MenuOrExit(int x, int y)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("M");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") Main Menu    (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") Exit to desktop");
                x = x + 9;
                y = y + 2;
                CursorPosition(x, y);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "X":
                    case "x":
                        SaveObjects();
                        Environment.Exit(0);
                        break;
                    case "M":
                    case "m":
                        keepGoing = false;
                        MainMenu();
                        break;
                    default:
                        keepGoing = false;
                        HeroMenu();
                        break;
                }
            }

        }
        private void CheckAndResetWindowSize()
        {
            if (Console.WindowHeight != 30 || Console.WindowWidth != 130)
            {
                Console.SetWindowSize(130, 30);
            }
        }
        private void LoadingBar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            art.DrawWelcome(11, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.SetCursorPosition(60, 15);
            for (int i = 0; i <= 100; i++)
            {
                for (int y = 0; y < i;)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    y = y + 5;
                }
                Console.SetCursorPosition(71, 15);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i + "/100");
                Console.SetCursorPosition(50, 15);
                System.Threading.Thread.Sleep(20);
            }
            Console.SetCursorPosition(55, 16);
            Console.WriteLine("Loading complete!");
            System.Threading.Thread.Sleep(2000);
        }
        private void LoadHeroesScreen()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                art.DrawFrame(8, 24);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                art.DrawDragon(70, 5);
                Console.ForegroundColor = ConsoleColor.White;
                int x = 10;
                int y = 3;

                foreach (Hero hero in heroes)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(heroes.LastIndexOf(hero) + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(") " + hero.FullName());
                    y++;
                }
                CustomWrite("(", 10, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("D");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") Delete a character");

                CustomWrite("(", 10, 22);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") Return to main menu");

                CursorPosition(9, 26);
                string stringChoice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int choice;
                if (int.TryParse(stringChoice, out choice))
                {
                    foreach (Hero tempHero in heroes)
                    {
                        if (tempHero.ID == choice)
                        {
                            hero = tempHero;
                            keepGoing = false;
                        }
                    }
                }
                else
                {
                    if (stringChoice == "d" || stringChoice == "D")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        CustomWrite("What character do you want to delete?", 10, 22);
                        CustomWrite("     ", 9, 26);
                        CursorPosition(9, 26);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            heroes.RemoveAt(choice - 1);
                            SaveObjects();
                        }
                    }
                    if (stringChoice == "x" || stringChoice == "X")
                    {
                        keepGoing = false;
                        MainMenu();
                    }
                }
            }
            HeroMenu();
        }
        private void SaveObjects()
        {
            XmlSerializer townSerializer = new XmlSerializer(typeof(List<Town>));
            StreamWriter townWriter = new StreamWriter(@"..\..\XML Objects\towns.xml");
            townSerializer.Serialize(townWriter, towns);
            townWriter.Close();

            XmlSerializer heroSerializer = new XmlSerializer(typeof(List<Hero>));
            StreamWriter heroWriter = new StreamWriter(@"..\..\XML Objects\heroes.xml");
            heroSerializer.Serialize(heroWriter, heroes);
            heroWriter.Close();

            Type[] monsterTypes = new Type[2];
            monsterTypes[0] = typeof(Skeleton);
            monsterTypes[1] = typeof(Orc);
            XmlSerializer monsterSerializer = new XmlSerializer(typeof(List<Monster>), monsterTypes);
            StreamWriter monsterWriter = new StreamWriter(@"..\..\XML Objects\monsters.xml");
            monsterSerializer.Serialize(monsterWriter, monsters);
            monsterWriter.Close();
        }
        private void LoadObjects()
        {
            XmlSerializer townSerializer = new XmlSerializer(typeof(List<Town>));
            StreamReader townReader = new StreamReader(@"..\..\XML Objects\towns.xml");
            while (townReader.EndOfStream != true)
            {
                towns = (List<Town>)townSerializer.Deserialize(townReader);
            }
            townReader.Close();

            XmlSerializer heroSerializer = new XmlSerializer(typeof(List<Hero>));
            StreamReader heroReader = new StreamReader(@"..\..\XML Objects\heroes.xml");
            while (heroReader.EndOfStream != true)
            {
                heroes = (List<Hero>)heroSerializer.Deserialize(heroReader);
            }
            heroReader.Close();

            Type[] monsterTypes = new Type[2];
            monsterTypes[0] = typeof(Skeleton);
            monsterTypes[1] = typeof(Orc);
            XmlSerializer monsterSerializer = new XmlSerializer(typeof(List<Monster>), monsterTypes);
            StreamReader monsterReader = new StreamReader(@"..\..\XML Objects\monsters.xml");
            while (monsterReader.EndOfStream != true)
            {
                monsters = (List<Monster>)monsterSerializer.Deserialize(monsterReader);
            }
            monsterReader.Close();
        }
        private void ScrollMenuArray(string[] array, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            art.DrawScroll(35, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(array[0]);
            y++;
            x = x - 3;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(array[1]);
        }
        private void ScrollMenuString(string text, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            art.DrawScroll(35, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }
        private void CursorPosition(int x, int y)
        {

            Console.WriteLine(); // >
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = true;
        }
        private void CustomWrite(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        private void Combat()
        {
            Console.CursorVisible = false;
            art.DrawMainMenuFrame(false);
            Monster monster = new Skeleton();
            Type monsterType = typeof(Skeleton);
            int randomID = random.Next(1, Monster.MonsterCounter);
            System.Threading.Thread.Sleep(100);
            foreach (Monster obj in monsters)
            {
                if (obj.ID == randomID)
                {
                    monsterType = obj.GetType();
                    if (monsterType == typeof(Orc))
                    {
                        monster = new Orc();
                    }
                }
            }
            CustomWrite("You've encountered a " + monster.Name + "!", 50, 14);
            if (monsterType == typeof(Skeleton))
            {
                art.DrawSkeleton(100, 6);
            }
            if (monsterType == typeof(Orc))
            {
                art.DrawOrc(75, 6);
            }
            Console.ReadLine();
            CustomWrite("                                         ", 50, 14);
            bool keepGoing = true;
            while (keepGoing)
            {
                ShowHeroStats(hero, 10, 7, false, true);
                ShowMonsterStats(monster, 10, 15, true);

                CustomWrite("    ", 58, 23);

                string[] combatOptions = new string[2] { "Attack!", "Retreat!" };
                UserOptions(2, combatOptions, 58, 19, false, true, true);

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice)) { }
                else
                {
                    choice = 1;
                }
                Console.ForegroundColor = ConsoleColor.White;
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        HeroMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        private void ShowHeroStats(Hero hero, int x, int y, bool coins, bool hearts)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            CustomWrite(hero.FullName(), x, y);

            int currentHealth = hero.CurrentHealth;
            if (hearts == true) //                                          Hearts true
            {
                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("HP: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x + 7, y + 1);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                while (currentHealth >= 4)
                {
                    Console.Write("♥ ");
                    currentHealth = currentHealth - 4;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (hearts == false) //                                         Hearts false
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("HP: ");
                Console.ForegroundColor = ConsoleColor.White;
                CustomWrite(hero.CurrentHealth + "/" + hero.MaxHealth, x + 7, y);
            }
            Console.SetCursorPosition(x, y + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ATK: ");
            Console.ForegroundColor = ConsoleColor.White;
            CustomWrite(hero.MinDamage + " - " + hero.MaxDamage, x + 7, y + 2);

            if (coins == true) //                                           Coins
            {
                Console.SetCursorPosition(x, y + 3);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Coins: ");
                Console.ForegroundColor = ConsoleColor.White;
                string coinsString = Convert.ToString(hero.Coins);
                CustomWrite(coinsString, x + 7, y + 3);
            }
        }
        private void ShowMonsterStats(Monster monster, int x, int y, bool hearts)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            CustomWrite(monster.Name, x, y);

            int currentHealth = monster.CurrentHealth;
            if (hearts == true) //                                          Hearts true
            {
                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("HP: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x + 7, y + 1);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                while (currentHealth >= 4)
                {
                    Console.Write("♥ ");
                    currentHealth = currentHealth - 4;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (hearts == false) //                                         Hearts false
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("HP: ");
                Console.ForegroundColor = ConsoleColor.White;
                CustomWrite(monster.CurrentHealth + "/" + monster.MaxHealth, x + 7, y);
            }
            Console.SetCursorPosition(x, y + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ATK: ");
            Console.ForegroundColor = ConsoleColor.White;
            CustomWrite(monster.MinDamage + " - " + monster.MaxDamage, x + 7, y + 2);
        }
        private void UserOptions(int numberOfOptions, string[] stringArray, int x, int y, bool exit, bool whatDoYouWantToDoText, bool cursorPosition)
        {
            int number = 1;
            int yCounter = 2;
            int arrayCounter = 0;
            if (whatDoYouWantToDoText == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                CustomWrite("What do you want to do?", x - 4, y);
                
            }
            if (whatDoYouWantToDoText == false)
            {
                yCounter = 0;
            }

            for (int counter = numberOfOptions; counter > 0; counter--)
            {
                CustomWrite("(", x, y + yCounter);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(number);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") " + stringArray[arrayCounter]);
                number++;
                yCounter++;
                arrayCounter++;
            }
            if (exit == true)
            {
                CustomWrite("(", x, y + yCounter);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(") " + "Exit");
            }
            if (cursorPosition == true)
            {
                CursorPosition(x, y + numberOfOptions + 2);
            }
        }
        static void GenerateRandomNumber()
        {
            byte[] byt = new byte[4];
            RNGCryptoServiceProvider rngCrypto =
                new RNGCryptoServiceProvider();
            rngCrypto.GetBytes(byt);
            int randomNumber = BitConverter.ToInt32(byt, 0);
            Console.WriteLine(randomNumber);
        }
    }
}
