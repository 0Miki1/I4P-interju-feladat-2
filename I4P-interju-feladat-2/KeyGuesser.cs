using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace I4P_interju_feladat_2
{
    internal class KeyGuesser : Transfer
    {
        private List<string> encMessages;
        private List<string> decMessages;
        private string firstWordHint;
        private int shorterFirstWordsMsg;
        private PossibleWords possibleWords;

        public KeyGuesser(List<string> encMessages, string firstWordHint, int shorterFirstWordsMsg, PossibleWords possibleWords)
        {
            this.encMessages = encMessages;
            decMessages = new List<string>()
            {
                "", ""
            };
            this.firstWordHint = firstWordHint;
            this.shorterFirstWordsMsg = shorterFirstWordsMsg;
            this.possibleWords = possibleWords;
        }

        //Changes the encrypted messages or decrypted messages lists' index 
        private int usingInd(int i)
        {
            if (i == 0)
            {
                return 1;
            }

            return 0;
        }

        public string PossibleKey()
        {
            string key = string.Empty;
            string temp = string.Empty;

            decMessages[shorterFirstWordsMsg] += firstWordHint;

            for (int i = 0; i < firstWordHint.Length; i++)
            {
                temp += GetChar(GetCharCode(encMessages[shorterFirstWordsMsg][i]) - GetCharCode(firstWordHint[i]));
            }

            key += possibleWords.Words.Where(x => x.StartsWith(temp)).FirstOrDefault() + " ";

            int useI = shorterFirstWordsMsg;
            List<int> cnt = new List<int>() { 0, 0 };

            cnt[shorterFirstWordsMsg] = firstWordHint.Length;

            do
            {
                temp = string.Empty;

                useI = usingInd(useI);

                if (decMessages[useI].Length < encMessages[useI].Length)
                {
                    for (int j = cnt[useI]; j < decMessages[usingInd(useI)].Length; j++)
                    {
                        int msgCode = GetCharCode(encMessages[useI][j]);
                        int keyCode = GetCharCode(key[j]);
                        int charcode = msgCode - keyCode;
                        temp += GetChar(charcode);

                        cnt[useI]++;
                    }

                    if (temp.EndsWith(" "))
                    {
                        temp = temp.TrimEnd(' ');
                    }

                    decMessages[useI] += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(decMessages[useI].Split(' ')[decMessages[useI].Split(' ').Length - 1]) || x.Equals(temp)).FirstOrDefault() + " ";
                } else
                {
                    decMessages[useI] += " ";
                }

                if (key.Length < decMessages[useI].Length && key.Length < decMessages[usingInd(useI)].Length)
                {
                    temp = string.Empty;

                    for (int j = key.Length - 1; j < decMessages[usingInd(useI)].Length; j++)
                    {
                        temp += GetChar(GetCharCode(encMessages[useI][j]) - GetCharCode(decMessages[useI][j]));
                    }

                    key += possibleWords.Words.Where(x => x.StartsWith(temp)).First() + " ";
                }
            } while (key.Length > decMessages[0].Length && key.Length > decMessages[1].Length);

            for (int i = 0; i < decMessages.Count; i++)
            {
                decMessages[i] = decMessages[i].TrimEnd(' ');
            }

            return "Dec[0] " + decMessages[0] + "\nDec[1] " + decMessages[1] + "\nKey    " + key + "";
        }
    }
}
