using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerFeed2.Database
{
    class DataBaseInterface: IDataBase
    {
        SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(Properties.Settings.Default.SFDataBaseConnectionString);

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                string teamName = "";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Team;";
                
                connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        teamName = String.Format("{0}", rdr[0]);
                        teams.Add(new Team(teamName, String.Format("{0}", rdr[1])));

                        teams[teams.Count - 1].Members = GetPlayers(teamName);
                    }
                }
            }

            return teams;
        }

        private List<Player> GetPlayers(string teamName)
        {
            List<Player> p = new List<Player>();

            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = connection;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from player where TeamName = @team";
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@team", teamName);

                connection.Open();

                SqlDataReader rdr2 = cmd2.ExecuteReader();

                if (rdr2.HasRows)
                {
                    while (rdr2.Read())
                    {
                        int n;
                        Int32.TryParse(String.Format("{0}", rdr2[0]), out n);
                        p.Add(new Player(String.Format("{0}", rdr2[1]),
                            String.Format("{0}", rdr2[2]), String.Format("{0}", rdr2[3])));
                    }
                    rdr2.Close();
                }
            }
            return p;
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
