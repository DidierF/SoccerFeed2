using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Player
    {
        private string p1;
        private string p2;
        private string p3;
        private int n;

        public Player(string p1, string p2, string p3, int n)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.n = n;
        }
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Position { get; private set; }
        public string Team { get; private set; }
    }
}
