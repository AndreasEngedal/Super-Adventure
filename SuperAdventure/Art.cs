using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperAdventure
{
    class Art
    {
        public void DrawFrame(int x, int y)
        {
            string path = @"..\..\ASCII art/Frame.txt";
            StreamReader frameReader = new StreamReader(path);
            string[] frame = new string[5];
            byte counter = 0;
            while (frameReader.EndOfStream != true)
            {
                frame[counter] = frameReader.ReadLine();
                counter++;
            }
            foreach (var obj in frame)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawTree(int x, int y)
        {
            string path = @"..\..\ASCII art/Tree.txt";
            StreamReader treeReader = new StreamReader(path);
            string[] tree = new string[10];
            byte counter = 0;
            while (treeReader.EndOfStream != true)
            {
                tree[counter] = treeReader.ReadLine();
                counter++;
            }
            foreach (var obj in tree)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawStars(int x, int y)
        {
            string path = @"..\..\ASCII art/Stars.txt";
            StreamReader starsReader = new StreamReader(path);
            string[] stars = new string[14];
            byte counter = 0;
            while (starsReader.EndOfStream != true)
            {
                stars[counter] = starsReader.ReadLine();
                counter++;
            }
            foreach (var obj in stars)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawCastle(int x, int y)
        {
            string path = @"..\..\ASCII art/Castle.txt";
            StreamReader castleReader = new StreamReader(path);
            string[] stars = new string[14];
            byte counter = 0;
            while (castleReader.EndOfStream != true)
            {
                stars[counter] = castleReader.ReadLine();
                counter++;
            }
            foreach (var obj in stars)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawWelcome(int x, int y)
        {
            string path = @"..\..\ASCII art/Welcome.txt";
            StreamReader welcomeReader = new StreamReader(path);
            string[] welcome = new string[14];
            byte counter = 0;
            while (welcomeReader.EndOfStream != true)
            {
                welcome[counter] = welcomeReader.ReadLine();
                counter++;
            }
            foreach (var obj in welcome)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawScroll(int x, int y)
        {
            string path = @"..\..\ASCII art/Scroll.txt";
            StreamReader scrollReader = new StreamReader(path);
            string[] scroll = new string[22];
            byte counter = 0;
            while (scrollReader.EndOfStream != true)
            {
                scroll[counter] = scrollReader.ReadLine();
                counter++;
            }
            foreach (var obj in scroll)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawDragon(int x, int y)
        {
            string path = @"..\..\ASCII art/Dragon.txt";
            StreamReader dragonReader = new StreamReader(path);
            string[] dragon = new string[19];
            byte counter = 0;
            while (dragonReader.EndOfStream != true)
            {
                dragon[counter] = dragonReader.ReadLine();
                counter++;
            }
            foreach (var obj in dragon)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawMainMenuFrame(bool drawBree)
        {
            Console.Clear();
            string path = @"..\..\ASCII art/MainMenuBars.txt";
            StreamReader mainMenuBarsReader = new StreamReader(path);
            string[] mainMenuBars = new string[3];
            byte counter = 0;
            while (mainMenuBarsReader.EndOfStream != true)
            {
                mainMenuBars[counter] = mainMenuBarsReader.ReadLine();
                ++counter;
            }
            Console.SetCursorPosition(0, 1);
            foreach (var obj in mainMenuBars)
            {
                Console.WriteLine(obj);
            }
            Console.SetCursorPosition(0, 26);
            foreach (var obj in mainMenuBars)
            {
                Console.WriteLine(obj);
            }
            Console.SetCursorPosition(52, 27);
            Console.Write("Created by ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Andreas Engedal");
            Console.SetCursorPosition(58, 2);
            Console.Write("SuperAdventure!");
            Console.ForegroundColor = ConsoleColor.White;
            if (drawBree == true)
            {
                DrawBree(55, 4);
            }
        }
        public void DrawBree(int x, int y)
        {
            string path;
            path = @"..\..\ASCII art/Bree.txt";
            StreamReader townReader = new StreamReader(path);
            string[] town = new string[21];
            byte counter = 0;
            while (townReader.EndOfStream != true)
            {
                town[counter] = townReader.ReadLine();
                counter++;
            }
            foreach (var obj in town)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawSkeleton(int x, int y)
        {
            string path;
            path = @"..\..\ASCII art/Skeleton.txt";
            StreamReader skeletonReader = new StreamReader(path);
            string[] skeleton = new string[21];
            byte counter = 0;
            while (skeletonReader.EndOfStream != true)
            {
                skeleton[counter] = skeletonReader.ReadLine();
                counter++;
            }
            foreach (var obj in skeleton)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
        public void DrawOrc(int x, int y)
        {
            string path;
            path = @"..\..\ASCII art/Orc.txt";
            StreamReader orcReader = new StreamReader(path);
            string[] orc = new string[21];
            byte counter = 0;
            while (orcReader.EndOfStream != true)
            {
                orc[counter] = orcReader.ReadLine();
                counter++;
            }
            foreach (var obj in orc)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine(obj);
                y++;
            }
        }
    }
}
