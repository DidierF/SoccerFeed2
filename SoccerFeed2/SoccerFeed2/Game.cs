using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    class Game
    {
        public Team[] Teams { get; private set; }
        public DateTime StartTime { get; private set; }
        public List<Annotation> Annotations { get; private set; }
        public int Score { get; private set; }

        public Game(/*int id,*/ Team t1, Team t2)
        {
            //this.id = id;
            Teams = new Team[] { t1, t2 };
            Annotations = new List<Annotation>();
            StartTime = System.DateTime.Now;
        }
    }
}
