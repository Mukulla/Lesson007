using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLib;

namespace KOConsole
{
    class Field : States
    {
        Random Rand001 = new Random();
        private ConsoleKey SomeKey;
        private MyFunc.Geminus<int>[] LookAround;

        private MyFunc.Geminus<int> ViKoords = MyFunc.Set(1, 1);

        private MyFunc.Geminus<int> MarkKoords;
        private MyFunc.Geminus<int> TotalMarkKoords;
        private MyFunc.Geminus<int> CPUKoords;

        private char Marker = 'P';
        private char Kro = 'X';
        private char CPUMarker = 'O';
        private char Dottar = '.';

        private char[,] VisibleField;
        private char[,] KOField;

        private bool PlayerVictory = false;
        private bool CPUVictory = false;
        private bool None = false;

        int CountEmptyCells = Global.FieldSizes.Secundus * Global.FieldSizes.Primis;

        public Field()
        {
            LookAround = new MyFunc.Geminus<int>[8];

            LookAround[0] = MyFunc.Set(0, -1);
            LookAround[1] = MyFunc.Set(1, -1);
            LookAround[2] = MyFunc.Set(1, 0);
            LookAround[3] = MyFunc.Set(1, 1);

            LookAround[4] = MyFunc.Set(0, 1);
            LookAround[5] = MyFunc.Set(-1, 1);
            LookAround[6] = MyFunc.Set(-1, 0);
            LookAround[7] = MyFunc.Set(-1, -1);

            VisibleField = new char[Global.FieldSizes.Secundus + 2, Global.FieldSizes.Primis + 2];
            KOField = new char[Global.FieldSizes.Secundus, Global.FieldSizes.Primis];

            MarkKoords.Primis = Global.FieldSizes.Primis / 2;
            MarkKoords.Secundus = Global.FieldSizes.Secundus / 2;

            TotalMarkKoords = MarkKoords;

            //MyFunc.FillArray(VisibleField, '#');
            MyFunc.FillArray(KOField, Dottar);
        }
        public override void HandleKeys()
        {
            SomeKey = Console.ReadKey().Key;

            if (SomeKey == ConsoleKey.Escape)
            {
                Program.ChangeState(0);
            }

            if (SomeKey == ConsoleKey.F1)
            {
                Program.ChangeState(1);
            }

            if (PlayerVictory || None || CPUVictory)
            {
                return;
            }

            MoveMarker();

            if (SomeKey == ConsoleKey.Spacebar)
            {
                if (KOField[MarkKoords.Secundus, MarkKoords.Primis] == Dottar)
                {
                    KOField[MarkKoords.Secundus, MarkKoords.Primis] = Kro;
                    PlayerVictory = CheckDirection(ref MarkKoords, Kro);

                    --CountEmptyCells;
                    if (CountEmptyCells < 1)
                    {
                        None = true;
                        return;
                    }

                    CPUKoords = CPULogick001(ref MarkKoords);
                    KOField[CPUKoords.Secundus, CPUKoords.Primis] = CPUMarker;
                    CPUVictory = CheckDirection(ref CPUKoords, CPUMarker);

                    --CountEmptyCells;
                }
                return;
            }
        }
        void MoveMarker()
        {
            //Смещаем
            switch (SomeKey)
            {
                case ConsoleKey.UpArrow:
                    --MarkKoords.Secundus;
                    break;
                case ConsoleKey.DownArrow:
                    ++MarkKoords.Secundus;
                    break;
                case ConsoleKey.LeftArrow:
                    --MarkKoords.Primis;
                    break;
                case ConsoleKey.RightArrow:
                    ++MarkKoords.Primis;
                    break;
            }
            //Проверяем на нахождение в границах
            MyFunc.CheckClausaAream(ref MarkKoords.Primis, 0, KOField.GetLength(1) - 1);
            MyFunc.CheckClausaAream(ref MarkKoords.Secundus, 0, KOField.GetLength(0) - 1);
        }
        bool CheckDirection(ref MyFunc.Geminus<int> CurrentKoords, char Symbol)
        {
            //Количество найденных в линию
            int Count = 0;
            //Итоговые координаты
            MyFunc.Geminus<int> TotalKoords = CurrentKoords;
            //Для проверки на выход за границы
            MyFunc.Geminus<int> Sizes = MyFunc.Set(KOField.GetLength(1) - 1, KOField.GetLength(0) - 1);
            MyFunc.Geminus<int> Checkers = MyFunc.Set(0, 0);
            //Проходим по всем восьми направлениям на поиск выстроенных в линию
            for (int i = 0; i < LookAround.Length; ++i)
            {
                //Цикл проверки по одному направлению
                do
                {
                    //Увеличиваем количество найденных
                    ++Count;
                    //Смещаем по направлению для поиска
                    MyFunc.DoAction(ref TotalKoords, ref LookAround[i], 0);
                    //Проверяем координаты на попадание в границы
                    Checkers.Primis = MyFunc.IntraAream(ref TotalKoords.Primis, 0, Sizes.Primis);
                    Checkers.Secundus = MyFunc.IntraAream(ref TotalKoords.Secundus, 0, Sizes.Secundus);
                    //Прерываем, если не попадает
                    if (Checkers.Primis != 0 || Checkers.Secundus != 0)
                    {
                        break;
                    }
                } while (KOField[TotalKoords.Secundus, TotalKoords.Primis] == Symbol);
                //Если количество обнаруженных более двух, выходим из функции
                if (Count > Global.LimitToWin - 1)
                {
                    return true;
                    //break;
                }
                //Сбрасываем
                Count = 0;
                TotalKoords = CurrentKoords;
            }
            //Если не найдено, то передаём ложь
            return false;
        }
        MyFunc.Geminus<int> CPUTurnar()
        {
            MyFunc.Geminus<int> TotalKoords;
            do
            {
                TotalKoords.Primis = Rand001.Next(0, KOField.GetLength(1));
                TotalKoords.Secundus = Rand001.Next(0, KOField.GetLength(0));
            } while (KOField[TotalKoords.Secundus, TotalKoords.Primis] != Dottar);

            return TotalKoords;
        }

        MyFunc.Geminus<int> CPULogick001(ref MyFunc.Geminus<int> PlayerKoords)
        {
            MyFunc.Geminus<int> TotalKoords = PlayerKoords;
            MyFunc.Geminus<int> RayKoords = PlayerKoords;
            MyFunc.Geminus<int> CPUKoords = MyFunc.Set(0, 0);

            RayKoords = CheckRays(ref PlayerKoords, Kro);
            CPUKoords = CheckRays(ref PlayerKoords, CPUMarker);

            if (!MyFunc.Less(ref RayKoords, 0, 0))
            {
                return RayKoords;
            }

            if (!MyFunc.Less(ref CPUKoords, 0, 0))
            {
                return CPUKoords;
            }

            return GetSome(ref TotalKoords);
        }
        MyFunc.Geminus<int> CheckRays(ref MyFunc.Geminus<int> SomeKoords, char Symbol001)
        {
            MyFunc.Geminus<int> TotalKoords = SomeKoords;
            MyFunc.Geminus<int> PlaceKoords = MyFunc.Set(-1, -1);
            MyFunc.Geminus<int> BackKoords = MyFunc.Set(-1, -1);

            MyFunc.Geminus<int> Sizes = MyFunc.Set(KOField.GetLength(1) - 1, KOField.GetLength(0) - 1);
            MyFunc.Geminus<int> Checkers = MyFunc.Set(0, 0);

            //List<MyFunc.Geminus<int>> SomeList = new List<MyFunc.Geminus<int>>();

            int Count = 1;

            for (int i = 0; i < LookAround.Length; ++i)
            {
                do
                {
                    MyFunc.DoAction(ref TotalKoords, ref LookAround[i], 0);
                    Checkers.Primis = MyFunc.IntraAream(ref TotalKoords.Primis, 0, Sizes.Primis);
                    Checkers.Secundus = MyFunc.IntraAream(ref TotalKoords.Secundus, 0, Sizes.Secundus);
                    if (Checkers.Primis != 0 || Checkers.Secundus != 0)
                    {
                        break;
                    }
                    if (KOField[TotalKoords.Secundus, TotalKoords.Primis] == Dottar)
                    {
                        PlaceKoords = TotalKoords;
                        //SomeList.Add(PlaceKoords);
                    }
                    if (KOField[TotalKoords.Secundus, TotalKoords.Primis] == Symbol001)
                    {
                        BackKoords.Primis = SomeKoords.Primis + LookAround[i].Primis * -1;
                        BackKoords.Secundus = SomeKoords.Secundus + LookAround[i].Secundus * -1;

                        Checkers.Primis = MyFunc.IntraAream(ref BackKoords.Primis, 0, Sizes.Primis);
                        Checkers.Secundus = MyFunc.IntraAream(ref BackKoords.Secundus, 0, Sizes.Secundus);
                        if (Checkers.Primis != 0 || Checkers.Secundus != 0)
                        {
                            BackKoords = MyFunc.Set(-1, -1);
                        }

                        ++Count;
                    }
                } while (true);

                if (Count > 1)
                {
                    if (!MyFunc.Less(ref BackKoords, 0, 0))
                    {
                        return BackKoords;
                    }
                    return PlaceKoords;
                }

                Count = 0;
                TotalKoords = SomeKoords;
            }
            /*
            if(SomeList.Count > 0)
            {
                int Index001 = Rand001.Next(0, SomeList.Count);
                return SomeList[Index001];
            }   */

            return MyFunc.Set(-1, -1);
        }
        MyFunc.Geminus<int> GetSome(ref MyFunc.Geminus<int> SomeKoords)
        {
            MyFunc.Geminus<int> TotalKoords = SomeKoords;
            List<MyFunc.Geminus<int>> SomeList = new List<MyFunc.Geminus<int>>();

            MyFunc.Geminus<int> Sizes = MyFunc.Set(KOField.GetLength(1) - 1, KOField.GetLength(0) - 1);
            MyFunc.Geminus<int> Checkers = MyFunc.Set(0, 0);

            for (int i = 0; i < LookAround.Length; ++i)
            {
                MyFunc.DoAction(ref TotalKoords, ref LookAround[i], 0);

                Checkers.Primis = MyFunc.IntraAream(ref TotalKoords.Primis, 0, Sizes.Primis);
                Checkers.Secundus = MyFunc.IntraAream(ref TotalKoords.Secundus, 0, Sizes.Secundus);
                if (Checkers.Primis != 0 || Checkers.Secundus != 0)
                {
                    continue;
                }
                if (KOField[TotalKoords.Secundus, TotalKoords.Primis] == Dottar)
                {
                    SomeList.Add(TotalKoords);
                }
            }

            if (SomeList.Count > 0)
            {
                int Index001 = Rand001.Next(0, SomeList.Count);
                return SomeList[Index001];
            }

            return CPUTurnar();
        }

        public override void Show()
        {
            MyFunc.FillArray(VisibleField, '#');

            MyFunc.Copy(ref ViKoords, KOField, VisibleField);

            TotalMarkKoords = MarkKoords;
            MyFunc.DoAction(ref TotalMarkKoords, ref ViKoords, 0);
            VisibleField[TotalMarkKoords.Secundus, TotalMarkKoords.Primis] = Marker;

            Console.WriteLine();

            MyFunc.ShowArray(VisibleField);

            Console.WriteLine();
            Console.WriteLine("Press Escape To Exit To Menu");
            Console.WriteLine("Press F1 To Restart");

            //Console.WriteLine($"{TotalMarkKoords.Secundus} {TotalMarkKoords.Primis}");

            if (PlayerVictory)
            {
                Console.WriteLine("Player Winner");
                return;
            }
            if (CPUVictory)
            {
                Console.WriteLine("CPU Winner");
                return;
            }
            if (None)
            {
                Console.WriteLine("None");
                return;
            }
        }
    }
}
