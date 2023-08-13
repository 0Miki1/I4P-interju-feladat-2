using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4P_interju_feladat_2
{
    internal class Transfer
    {
        protected int GetCharCode(char character)
        {
            if (char.IsUpper(character))
            {
                return char.ToLower(character) - 'a';
            }

            if (character == ' ')
            {
                return 26;
            }

            return character - 'a';
        }

        protected char GetChar(int code)
        {
            if (code == -1)
            {
                return ' ';
            }
            else if (code < 0)
            {
                code += 27;
            }
            else if (code == 26)
            {
                return ' ';
            }
            else if (code > 26)
            {
                code %= 27;
            }

            return (char)('a' + code);
        }
    }
}
