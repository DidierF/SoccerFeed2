using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Team
    {
        public Player[] Members;
        public string Name;
        public string Stadium;
        public Player[] inGamePlayers;
        private string teamName;
        private string p;

        public Team(string teamName, string p)
        {
            // TODO: Complete member initialization
            this.teamName = teamName;
            this.p = p;
        }
    }
}
