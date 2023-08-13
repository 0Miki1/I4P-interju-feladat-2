using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace I4P_interju_feladat_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //KeyGuesser k = new KeyGuesser(new List<string>() { "daoz", "ccotlj" }, "back", 0, new PossibleWords("words.txt"));
            //KeyGuesser k = new KeyGuesser(new List<string>() { "cwavbntxafohmpexsamykbcg", "ecaylvmmujdbbxcax emsdbjbfq" }, "early ", 1, new PossibleWords("words.txt"));
            KeyGuesser k = new KeyGuesser(new List<string>() { "cwavbntxa", "ecaylvmmuj" }, "early ", 1, new PossibleWords("words.txt"));

            Console.WriteLine(k.PossibleKeys());

            Console.ReadKey();
        }
    }
}
