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
        private int longerFirstWordMsg;
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

            //int longerIndex = encMessages.FindIndex(x => x.Length == encMessages.Max(y => y.Length));

            //for (int i = 0; i < key.Length; i++)
            //{
            //    decMessages[longerIndex] += GetCharCode(encMessages[longerIndex][i]) - GetCharCode(key[i]) + " ";
            //}

            //do
            //{

            //} while (decMessages[0].Length != encMessages[0].Length && decMessages[1].Length != encMessages[1].Length);

            //int keyI = 0;

            ////TODO
            ////Üzenetek szakaszolása

            //for (int j = 0; j < 10; j++)
            //{
            //    temp = string.Empty;
            //    if (decMessages[0].Length <= decMessages[1].Length)
            //    {
            //        for (int i = 0; i < decMessages[0].Length; i++)
            //        {
            //            temp += GetChar(GetCharCode(encMessages[0][i]) - GetCharCode(key[keyI]));
            //        }

            //        decMessages[0] += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(decMessages[0].Split(' ')[decMessages[0].Split(' ').Length - 1])).FirstOrDefault() + " ";
            //    }
            //    else
            //    {
            //        for (int i = 0; i < decMessages[1].Length; i++)
            //        {
            //            temp += GetChar(GetCharCode(encMessages[1][i]) - GetCharCode(key[keyI]));
            //        }

            //        decMessages[1] += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(decMessages[1].Split(' ')[decMessages[1].Split(' ').Length - 1])).FirstOrDefault() + " ";
            //    }

            //    keyI++;
            //}




            //for (int j = 0; j < 10; j++)
            //{
            //    if (key.Length > decMessages[0].Length || key.Length > decMessages[1].Length)
            //    {
            //        if (decMessages[0].Length < decMessages[1].Length)
            //        {

            //        }
            //    } else
            //    {
            //        if (decMessages[0].Length > decMessages[1].Length)
            //        {
            //            //első megfejtett üzenetből folytatjuk a kulcsot
            //            //kulcs.legth - 1től megfejtett üzenet hosszáig fejtük tovább a kulcsot
            //        } else
            //        {
            //            //második megfejtett üzenetből folytatjuk a kulcsot
            //        }
            //    }
            //}


            //int decCnt = 0;
            //do
            //{
            //    if (key.Length > decMessages[shorterFirstWordsMsg].Length)
            //    {
            //        for (int i = decCnt; i < decMessages[longerFirstWordMsg].Length; i++)
            //        {
            //            temp = string.Empty;

            //            temp += GetChar(GetCharCode(key[decCnt]) - GetCharCode(encMessages[longerFirstWordMsg][i]));

            //            decCnt++;
            //        }

            //        decMessages[longerFirstWordMsg] += temp;
            //    } else
            //    {
            //        for (int i = key.Length - 1; i < decMessages[shorterFirstWordsMsg].Length; i++)
            //        {

            //        }
            //    }
            //} while (encMessages[shorterFirstWordsMsg].Length != decMessages[shorterFirstWordsMsg].Length);


            //------------------------------------------------------------------

            //int dec0Cnt = 0;
            //int dec1Cnt = 0;
            //int keyCnt = 0;
            ////do
            ////{

            ////} while (decMessages[0].Length != encMessages[0].Length || decMessages[1].Length != encMessages[1].Length);

            //for (int j = 0; j < 20; j++)
            //{
            //    temp = string.Empty;

            //    if (key.Length > decMessages[0].Length && key.Length > decMessages[1].Length)
            //    {
            //        if (decMessages[0].Length < decMessages[1].Length)
            //        {
            //            //dec[0]-t folytatjuk
            //            for (int i = dec0Cnt; i < decMessages[0].Length; i++)
            //            {
            //                temp += GetChar(GetCharCode(key[i]) - GetCharCode(encMessages[0][i]));

            //                dec0Cnt++;
            //            }

            //            decMessages[0] += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(decMessages[0].Split(' ')[decMessages[0].Split(' ').Length - 1])).FirstOrDefault() + " ";
            //        }
            //        else
            //        {
            //            //dec[1]-t folytatjuk
            //            for (int i = dec1Cnt; i < decMessages[1].Length; i++)
            //            {
            //                temp += GetChar(GetCharCode(key[i]) - GetCharCode(encMessages[1][i]));

            //                dec1Cnt++;
            //            }

            //            decMessages[1] += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(decMessages[1].Split(' ')[decMessages[1].Split(' ').Length - 1])).FirstOrDefault() + " ";
            //        }
            //    }
            //    else
            //    {
            //        if (decMessages[0].Length > decMessages[1].Length)
            //        {
            //            //első megfejtett üzenetből folytatjuk a kulcsot
            //            //kulcs.length - 1től megfejtett üzenet hosszáig fejtük tovább a kulcsot

            //            for (int i = key.Length - 1; i < dec0Cnt - key.Length; i++)
            //            {
            //                temp += GetChar(GetCharCode(encMessages[0][i]) - GetCharCode(decMessages[0][i]));
            //            }
            //        }
            //        else
            //        {
            //            //második megfejtett üzenetből folytatjuk a kulcsot

            //            for (int i = key.Length; i < dec1Cnt - key.Length; i++)
            //            {
            //                temp += GetChar(GetCharCode(encMessages[1][i]) - GetCharCode(decMessages[1][i]));
            //            }
            //        }

            //        //key += possibleWords.Words.Where(x => x.StartsWith(temp) && !x.Equals(key.Split(' ')[key.Split(' ').Length - 1])).FirstOrDefault() + " ";
            //        key += possibleWords.Words.Where(x => x.StartsWith(temp)).FirstOrDefault() + " ";
            //    }
            //}


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
