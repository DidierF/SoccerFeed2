using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Annotation
    {
        public string Motive;
        public Player MainPlayer;
        public DateTime Time;
        public Player AuxPlayer;

        public Annotation(DateTime time, Player player/*, int motive, int id*/)
        {
            this.Time = time;
            this.MainPlayer = player;
            //this.Motive = motive;
            //this.id = id;
        }

        public Annotation(DateTime time, Player player, Player auxplayer/*, int motive, int id*/)
        {
            this.Time = time;
            this.MainPlayer = player;
            this.AuxPlayer = auxplayer;
            //this.motive = motive;
            //this.id = id;
        }

        public string toString()
        {
            return string.Empty;
        }
    }
}
