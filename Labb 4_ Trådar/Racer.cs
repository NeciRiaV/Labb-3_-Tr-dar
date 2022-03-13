using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_3__Trådar
{
    public class Racer
    {
        public string CarName { get; set; }
        public int Distance { get; set; }
        public int Goal { get; set; }
        public int Speed { get; set; }
        public string DotDot { get; set; }
        public int timer { get; set; }

        public Racer(string name, int distance, int goal, int speed, string dot, int time)
        {
            CarName = name;
            Distance = distance;
            Goal = goal;
            Speed = speed;
            DotDot = dot;
            timer = time;
        }
    }
}
