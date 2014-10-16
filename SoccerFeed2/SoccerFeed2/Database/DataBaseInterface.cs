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
        SqlConnectionStringBuilder csb = 
            new SqlConnectionStringBuilder(Properties.Settings.Default.SFDataBaseConnectionString);

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
                        p.Add(new Player(String.Format("{0}", rdr2[1]).Trim(),
                            String.Format("{0}", rdr2[2]), String.Format("{0}", rdr2[3]), teamName, n));
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
            SqlConnection connection = new SqlConnection(csb.ConnectionString);
            int games = 0;
            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select count(gameID) from game";

                connection.Open();
                games = (int)command.ExecuteScalar();

            }
            return games;
        }

        public void SaveAnnoation(Annotation n, Game g)
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                connection.Open();
                string query;
                if (n.AuxPlayer != null)
                {
                    query = "insert annotation (ID, Motive, Time, Game, MainPlayerID, AuxPlayerID)" +
                        "values (@ID, @Motive, convert(datetime, @date, 103), @gameID, @playerID, @auxPlayerID)";
                }
                else
                {
                    query = "insert annotation (ID, Motive, Time, Game, MainPlayerID)"
                    + "values (@ID, @Motive, convert(datetime, @date, 103), @gameID, @playerID)";
                }

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", n.ID);
                cmd.Parameters.AddWithValue("@Motive", n.Motive);
                cmd.Parameters.AddWithValue("@date", n.Time.ToString("hh:mm:ss"));
                cmd.Parameters.AddWithValue("@gameID", g.ID);
                cmd.Parameters.AddWithValue("@playerID", n.MainPlayer.ID);
                if (n.AuxPlayer != null)
                {
                    cmd.Parameters.AddWithValue("@auxPlayerID", n.AuxPlayer.ID);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public List<Annotation> GetAnnoations()
        {
            throw new NotImplementedException();
        }

        public int GetNewAnnotationID()
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);
            int annotations = 0;
            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select count(ID) from Annotation";

                connection.Open();
                annotations = (int)command.ExecuteScalar();

            }
            return annotations;
        }

        public Player GetPlayer(int PlayerID)
        {
            throw new NotImplementedException();
        }
    }
}
