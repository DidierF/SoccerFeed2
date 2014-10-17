using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2
{
    public class Annotation
    {
        public int motive { get; private set; }
        public string Motive
        {
            get
            {
                switch (motive)
                {
                    case 0:
                        return "Goal";
                    case 1:
                        return "Foul";
                    case 2:
                        return "Red Card";
                    case 3:
                        return "Yellow Card";
                    case 4:
                        return "Substitution";
                    case 5:
                        return "Goal Kick";
                    case 6:
                        return "Throw In";
                    case 7:
                        return "Corner";
                    case 8:
                        return "Offside";
                    case 9:
                        return "Free Throw";
                    case 10:
                        return "Penalty";
                    default:
                        return "Default";
                }
            }
        }
        public Player MainPlayer { get; private set; }
        public DateTime Time { get; private set; }
        public Player AuxPlayer { get; private set; }
        public int ID { get; private set; }

        public Annotation(DateTime time, Player player, int motive, int id)
        {
            this.Time = time;
            this.MainPlayer = player;
            this.motive = motive;
            this.ID = id;
        }

        public Annotation(DateTime time, Player player, Player auxplayer, int motive, int id)
        {
            this.Time = time;
            this.MainPlayer = player;
            this.AuxPlayer = auxplayer;
            this.motive = motive;
            this.ID = id;
        }

        
        public override string ToString()
        {
            string result = "";
            switch (motive)
            {
                case 0:
                    if (AuxPlayer != null)
                    {
                        result = "[" + Time.TimeOfDay + "] " + MainPlayer.Name + " scored a " + Motive + " assisted by " + AuxPlayer.Name;
                    }
                    else
                    {
                        result = "[" + Time.TimeOfDay + "] " + MainPlayer.Name + " scored a " + Motive;
                    }
                    break;
                case 1:
                    result = "[" + Time.TimeOfDay + "] " + MainPlayer.Name + " performed a " + Motive + " to " + AuxPlayer.Name;
                    break;
                case 2:
                case 3:
                    result = "[" + Time.TimeOfDay + "] " + MainPlayer.Name + " received a " + Motive;
                    break;
                case 4:
                    if (AuxPlayer != null)
                    {
                        result = "[" + Time.TimeOfDay + "]" + MainPlayer.Name + " was replaced by " + AuxPlayer.Name;
                    }
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    result = "[" + Time.TimeOfDay + "] " + MainPlayer.Name + " performed a " + Motive;
                    break;
                default:
                    result = "Default motive string";
                    break;

            }
            return result;
        }

        internal static void GetPossibleMotives(string[] allMotives)
        {
            if (allMotives.Length >= 11)
            {
                allMotives[0] = "Goal";
                allMotives[1] = "Foul";
                allMotives[2] = "Red Card";
                allMotives[3] = "Yellow Card";
                allMotives[4] = "Substitution";
                allMotives[5] = "Goal Kick";
                allMotives[6] = "Throw In";
                allMotives[7] = "Corner";
                allMotives[8] = "Offside";
                allMotives[9] = "Free Throw";
                allMotives[10] = "Penalty";
            }
        }
    }
}
