using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4P_interju_feladat_2
{
    internal class Result
    {
        private string msg1;
        private string msg2;
        private string key;

        public Result(List<string> msgs, string key)
        {
            msg1 = msgs[0];
            msg2 = msgs[1];
            this.key = key;
        }

        public string Msg1 { get => msg1; }
        public string Msg2 { get => msg2; }
        public string Key { get => key; }

        public override string ToString()
        {
            return $"Message 1: {Msg1}\nMessage 2: {Msg2}\nKey: {Key}";
        }
    }
}
