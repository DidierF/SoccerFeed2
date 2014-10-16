using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    public class Game
    {
        public Team[] Teams { get; private set; }
        public DateTime StartTime { get; private set; }
        public List<Annotation> Annotations { get; private set; }
        public int[] Score { get; private set; }
        public int ID { get; private set; }

        public Game(int id, Team t1, Team t2)
        {
            this.ID = id;
            Teams = new Team[] { t1, t2 };
            Annotations = new List<Annotation>();
            StartTime = System.DateTime.Now;
            Score = new int[] {0, 0}; 
        }

        public void addAnnotation(Annotation annotation)
        {
            Annotations.Add(annotation);
            if (annotation.Motive.Equals("Goal")) Goal(annotation);
            if (annotation.Motive.Equals("Substitution")) Substitution(annotation); 
        }

        private void Goal(Annotation annotation)
        {
            if (annotation.MainPlayer.Team == Teams[0].Name) Score[0]++;
            if (annotation.MainPlayer.Team == Teams[1].Name) Score[1]++;
        }

        private void Substitution(Annotation annotation)
        {
            int team = -1;

            if (annotation.MainPlayer.Team == Teams[0].Name) team = 0;
            if (annotation.MainPlayer.Team == Teams[1].Name) team = 1;

            if (team != -1)
            {
                Teams[team].availablePlayers.Add(annotation.MainPlayer);
                Teams[team].inGamePlayers.Remove(annotation.MainPlayer);
                Teams[team].inGamePlayers.Add(annotation.AuxPlayer);
                Teams[team].availablePlayers.Remove(annotation.AuxPlayer);
            }
        }
    }
}
