using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using MyLib;

namespace KOConsole
{
    class Program
    {
        static States CurrentState;
        static void Main(string[] args)
        {
            Program.ChangeState(0);

            while (true)
            {
                CurrentState.Show();
                CurrentState.HandleKeys();

                Console.Clear();
            }
        }

        static public void ChangeState(int NewState)
        {
            switch (NewState)
            {
                case 0:
                    CurrentState = new Menu();
                    break;
                case 1:
                    CurrentState = new Field();
                    break;
            }
        }
    }
}
