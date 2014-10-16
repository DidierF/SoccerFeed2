using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    public class Player
    {
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Position { get; private set; }
        public string Team { get; private set; }
        public int ID { get; private set; }
        public bool HasPlayed { get; set; }

        public Player(string name, string number, string pos, string team, int id)
        {
            this.Name = name;
            this.Number = number;
            this.Position = pos;
            this.Team = team;
            this.ID = id;
            HasPlayed = false;
        }
    }
}
