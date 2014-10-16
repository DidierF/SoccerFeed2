using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerFeed2.Database;

namespace SoccerFeed2
{
    public class Team
    {
        public List<Player> Members; 
        public string Name;
        public string Stadium;
        //TODO: Getters for InGamePlayers and Available Players;
        public List<Player> InGamePlayers;
        public List<Player> AvailablePlayers;

        public Team(string name, string std)
        {
            Name = name;
            Stadium = std;
            Members = new DataBaseInterface().GetPlayers(this.Name); 
            InGamePlayers = new List<Player>();
            AvailablePlayers = new List<Player>();
            DefaultMembers();
 
        }

        public void DefaultMembers()
        {
            int i = 0;

            foreach (Player player in Members)
            {
                if (i < 11) InGamePlayers.Add(Members[i]);
                if (i >= 11) AvailablePlayers.Add(Members[i]);
                i++;
            }
        }
    }
}
