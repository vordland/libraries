using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scale_of_notation
{
    public class SON
    {
        private int[] number;
        private int scale;
        public SON(int scale)
        {
            this.scale = scale;
            number = new int[1];
        }
        public int this[int index]
        {
            get
            { return number[index]; }
            set
            { number[index] = value; }
        }
    }
}
}
