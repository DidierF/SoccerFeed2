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
        void SaveGame(Game g);
        List<Game> GetAllGames();
        Game GetGame(int GameID);
        void GetGameTeams(Team[] teams, int GameID);
        int GetNewGameID();
        void SaveAnnotation(Annotation a, Game g);
        List<Annotation> GetAnnotations(int GameID);
        int GetNewAnnotationID();
        Player GetPlayer(int PlayerID);

    }
}
