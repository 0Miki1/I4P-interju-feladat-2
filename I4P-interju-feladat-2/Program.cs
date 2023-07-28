using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4P_interju_feladat_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msg1 = "qxpv";
            string msg2 = "rwwv";

            char c = 'a';
            //int charCnt = 'a';

            string key = string.Empty;

            for (int i = 0; i < msg1.Length; i++)
            {
                while ((msg1[i] + c) != (msg2[i] + c))
                {
                    //charCnt++;
                    c++;
                }

                //key += ((char)charCnt);
                key += c;
                c = 'a';
            }

            Console.WriteLine(key);

            //Console.ReadKey();
        }
    }
}
