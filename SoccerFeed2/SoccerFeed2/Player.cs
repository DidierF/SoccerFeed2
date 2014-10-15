using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Player
    {
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Position { get; private set; }
        public string Team { get; private set; }

        public Player(string name, string number, string pos/*, int id*/)
        {
            this.Name = name;
            this.Number = number;
            this.Position = pos;
            //this.id = id;
            //hasPlayed = false;
        }
    }
}
