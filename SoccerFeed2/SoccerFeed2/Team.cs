using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    public class Team
    {
        public List<Player> Members; 
        public string Name;
        public string Stadium;
        public List<Player> inGamePlayers;
        public List<Player> availablePlayers;

        public Team(string name, string std)
        {
            Name = name;
            Stadium = std;
            Members = new List<Player>(); 
            inGamePlayers = new List<Player>();
            availablePlayers = new List<Player>();
            DefaultMembers();
 
        }

        public void DefaultMembers()
        {
            int i = 0;

            foreach (Player player in Members)
            {
                if (i < 11) inGamePlayers.Add(Members[i]);
                if (i >= 11) availablePlayers.Add(Members[i]);
                i++;
            }
        }
    }
}
