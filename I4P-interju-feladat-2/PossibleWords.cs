using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace I4P_interju_feladat_2
{
    internal class PossibleWords
    {
        private readonly List<string> words;

        public PossibleWords(string filePath)
        {
            words = FileRead(filePath);
        }

        public List<string> Words { get => words; }

        private List<string> FileRead(string filePath)
        {
            FileStream fs = new FileStream(@"..\..\" + filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            List<string> temp = new List<string>();

            while (!sr.EndOfStream)
            {
                temp.Add(sr.ReadLine());
            }

            sr.Close();
            fs.Close();

            return temp;
        }
    }
}
