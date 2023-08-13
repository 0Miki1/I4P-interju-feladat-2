using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace I4P_interju_feladat_2
{
    public class Program
    {
        public static bool MsgFormat(string msg)
        {
            Regex msgReg = new Regex(@"^([a-z]| )+$");

            return msgReg.IsMatch(msg);
        }

        private static void Menu()
        {
            Console.Clear();

            PossibleWords possWords = new PossibleWords("words.txt");
            List<string> encMessages = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                string temp = string.Empty;
                do
                {
                    Console.Write($"Add meg a(z) {i + 1}. titkosított üzenetet: ");
                    temp = Console.ReadLine();
                    
                } while (!MsgFormat(temp));

                encMessages.Add(temp);
            }

            string hint;
            do
            {
                Console.Write("Add meg az első szavát annak az üzenetnek, ahol rövidebb az első szó: ");
                hint = Console.ReadLine();
            } while (!MsgFormat(hint));

            int hintIndex = -1;
            do
            {
                try
                {
                    Console.Write("Hanyadik szóban található a segítség: ");
                    hintIndex = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Adj meg egy számot ami, 1 vagy 2 lehet!");
                }
            } while (hintIndex > 2 || hintIndex < 1);

            KeyGuesser keyGuess = new KeyGuesser(encMessages, hint, hintIndex - 1, possWords);

            Console.WriteLine("A megfejtés: \n" + keyGuess.PossibleKey().ToString());
        }

        static void Main(string[] args)
        {
            KeyGuesser k = new KeyGuesser(new List<string>() { "cwavbntxa", "ecaylvmmuj" }, "early ", 1, new PossibleWords("words.txt"));

            Console.WriteLine(k.PossibleKey().ToString());

            //Menu();

            Console.ReadKey();
        }
    }
}
