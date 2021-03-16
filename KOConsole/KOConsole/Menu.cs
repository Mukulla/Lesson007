using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLib;

namespace KOConsole
{
    class Menu : States
    {        
        public int Difficult = 0;

        string[] Greetings;

        string[] Names;
        string[] SubNames;

        bool MenuChoice;

        int MenuMark = 0;
        int SubMenuMark = 0;

        string Marker = "->";
        string Spacer = " ";

        private ConsoleKey SomeKey;

        public Menu()
        {
            Greetings = new string[4];
            Greetings[0] = "The KO Game ver 011";
            Greetings[1] = "Press Escape To Exit Program";
            Greetings[2] = "Arrows To Move Marker";
            Greetings[3] = "Press Escape To Exit To Menu";

            MenuChoice = true;

            Names = new string[2];
            Names[0] = "Start";
            Names[1] = "Exit";

            SubNames = new string[4];
            SubNames[0] = "Easy";
            SubNames[1] = "Medium";
            SubNames[2] = "Hard";
            SubNames[3] = "Exit";
        }

        public override void HandleKeys()
        {
            SomeKey = Console.ReadKey().Key;

            if (MenuChoice)
            {
                MenuHandles();
            }
            else
            {
                SubMenuHandles();
            }
        }
        void MenuHandles()
        {
            /*
            if (!Console.KeyAvailable)
            {
                return;
            }*/
            //Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape
            //SomeKey = Console.ReadKey().Key;

            //if (Console.ReadKey(true).Key == ConsoleKey.DownArrow)
            if (SomeKey == ConsoleKey.DownArrow)
            {
                ++MenuMark;
                MyFunc.CheckClausaAream(ref MenuMark, 0, Names.Length - 1);
                return;
            }

            //if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
            if (SomeKey == ConsoleKey.UpArrow)
            {
                --MenuMark;
                MyFunc.CheckClausaAream(ref MenuMark, 0, Names.Length - 1);
                return;
            }

            //if(Console.ReadKey(true).Key == ConsoleKey.Enter)
            if(SomeKey == ConsoleKey.Enter)
            {
                switch (MenuMark)
                {
                    case 0:
                        MenuChoice = false;
                        break;
                    case 1:
                        Environment.Exit(0);
                        break;
                }
                return;
            }


            if (SomeKey == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        void SubMenuHandles()
        {
            if (SomeKey == ConsoleKey.DownArrow)
            {
                ++SubMenuMark;
                MyFunc.CheckClausaAream(ref SubMenuMark, 0, SubNames.Length - 1);
                return;
            }            
            if (SomeKey == ConsoleKey.UpArrow)
            {
                --SubMenuMark;
                MyFunc.CheckClausaAream(ref SubMenuMark, 0, SubNames.Length - 1);
                return;
            }

            if (SomeKey == ConsoleKey.Enter)
            {
                switch (SubMenuMark)
                {
                    case 0:                        
                        MenuChoice = true;
                        Global.FieldSizes = MyFunc.Set(3, 3);
                        Global.LimitToWin = 3;
                        Program.ChangeState(1);
                        break;
                    case 1:
                        MenuChoice = true;
                        Global.FieldSizes = MyFunc.Set(4, 4);
                        Global.LimitToWin = 3;
                        Program.ChangeState(1);
                        break;
                    case 2:
                        MenuChoice = true;
                        Global.FieldSizes = MyFunc.Set(5, 5);
                        Global.LimitToWin = 4;
                        Program.ChangeState(1);
                        break;
                    case 3:
                        MenuChoice = true;
                        break;
                }
                return;
            }

            if (SomeKey == ConsoleKey.Escape)
            {
                MenuChoice = true;
            }
        }

        public override void Show()
        {
            if (MenuChoice)
            {
                ShowMenu();
            }
            else
            {
                ShowSubMenu();
            }
        }
        void ShowMenu()
        {            
            Console.WriteLine($"{Greetings[0],21}");
            Console.WriteLine();

            for (int i = 0; i < Names.Length; ++i)
            {
                if(i == MenuMark)
                {
                    Console.WriteLine($"{Marker,7} {Names[i]}");
                }
                else
                {
                    Console.WriteLine($"{Spacer,7} {Names[i] }");
                }
                Console.WriteLine();
            }           

            Console.WriteLine();
            Console.WriteLine($"{Greetings[1],21}");
            Console.WriteLine($"{Greetings[2],21}");
        }

        void ShowSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < SubNames.Length; ++i)
            {
                if (i == SubMenuMark)
                {
                    Console.WriteLine($"{Marker,7} {SubNames[i]}");
                }
                else
                {
                    Console.WriteLine($"{Spacer,7} {SubNames[i]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"{Greetings[3],21}");
        }
    }
}
