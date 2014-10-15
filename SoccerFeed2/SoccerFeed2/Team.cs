using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Team
    {
        public List<Player> Members;
        public string Name;
        public string Stadium;
        public List<Player> inGamePlayers;

        public Team(string name, string std)
        {
            Name = name;
            Stadium = std;
        }
    }
}
