using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerFeed2.Properties;

namespace SoccerFeed2.Database
{
    class DataBaseInterface: IDataBase
    {
        SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(Settings.Default.SFDataBaseConnectionString);

        public List<Team> GetTeams()
        {
            throw new NotImplementedException();
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int GameID)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetGameTeams(int GameID)
        {
            throw new NotImplementedException();
        }

        public int GetNewGameID()
        {
            throw new NotImplementedException();
        }

        public void SaveAnnoation(Annotation a)
        {
            throw new NotImplementedException();
        }

        public List<Annotation> GetAnnoations()
        {
            throw new NotImplementedException();
        }

        public int GetNewAnnotationID()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int PlayerID)
        {
            throw new NotImplementedException();
        }
    }
}
