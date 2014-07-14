using System;
using System.Collections.Generic;

namespace click
{
    class Click
    {
        uint x;

        public uint X
        {
            get { return x; }
        }
        uint y;

        public uint Y
        {
            get { return y; }
        }
        int delay;

        public int Delay
        {
            get { return delay; }
        }
        int repeat;

        public int Repeat
        {
            get { return repeat; }
        }

        public Click(uint x, uint y, int delay, int repeat)
        {
            this.x = x;
            this.y = y;
            this.delay = delay;
            this.repeat = repeat;
        }

        public string Click_Out(int a)
        {
            return a + ".\t" + X + '-' + Y + "\t\t" + delay + "\t\t" + repeat;
        }
    }
}
