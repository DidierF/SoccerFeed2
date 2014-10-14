using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2.Database
{
    interface IDataBase
    {
        List<Team> GetTeams();
        void SaveGame();
        List<Game> GetAllGames();
        Game GetGame(int GameID);
        List<Team> GetGameTeams(int GameID);
        int GetNewGameID();
        void SaveAnnoation(Annotation a);
        List<Annotation> GetAnnoations();
        int GetNewAnnotationID();
        Player GetPlayer(int PlayerID);

    }
}
