using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson007
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] SomeArray = new int[15];

            SetRandomValues(SomeArray, -31, 31);
            Show(SomeArray);

            Console.Read();
        }

        static void SetRandomValues(int []SomeArray001, int Min, int Max)
        {
            if(!CheckArray(SomeArray001))
            {
                return;
            }
            Random Rand001 = new Random();           

            for (int i = 0; i < SomeArray001.Length; ++i)
            {
                SomeArray001[i] = Rand001.Next(Min, Max);
            }
        }

        static void Show(int[] SomeArray001)
        {
            if (!CheckArray(SomeArray001))
            {
                return;
            }

            foreach (var Item in SomeArray001)
            {
                Console.WriteLine(Item);
            }
        }

        static bool CheckArray<T>( T[] SomeArray001)
        {
            if (SomeArray001 == null)
            {
                return false;
            }
            return true;
        }
    }
}
