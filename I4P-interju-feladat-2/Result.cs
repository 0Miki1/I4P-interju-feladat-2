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

        public Result(string msg1, string msg2, string key)
        {
            this.msg1 = msg1;
            this.msg2 = msg2;
            this.key = key;
        }

        public string Msg1 { get => msg1; }
        public string Msg2 { get => msg2; }
        public string Key { get => key; }
    }
}
