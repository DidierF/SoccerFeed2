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

        public List<Player> GetPlayers(string teamName)
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

        public void SaveGame(Game g)
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert Game (GameID, Stadium, Date) values (@ID, @stadium, @time)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", g.ID);
                command.Parameters.AddWithValue("@stadium", g.HomeTeam.Stadium);
                command.Parameters.AddWithValue("@time", g.StartTime.ToString("h:mm:ss"));
                command.Parameters.AddWithValue("@homeTeam", g.HomeTeam.Name);
                command.Parameters.AddWithValue("@awayTeam", g.AwayTeam.Name);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                connection.Open();

                command.CommandText = "insert GameTeam (GameID, TeamName) values (@ID, @homeTeam)";
                command.ExecuteNonQuery();

                connection.Close();
                connection.Open();

                command.CommandText = "insert GameTeam (GameID, TeamName) values (@ID, @awayTeam)";
                command.ExecuteNonQuery();

            }

        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            SqlConnection connection = new SqlConnection(csb.ConnectionString);


            using (connection)
            {
                SqlCommand GameIDCommand = new SqlCommand();
                GameIDCommand.Connection = connection;
                GameIDCommand.CommandType = CommandType.Text;
                GameIDCommand.CommandText = "Select * from Game";


                connection.Open();
                SqlDataReader idReader = GameIDCommand.ExecuteReader();

                if (idReader.HasRows)
                {
                    while (idReader.Read())
                    {
                        int id;
                        Team[] gameTeams = new Team[2];

                        Int32.TryParse(String.Format("{0}", idReader[0]), out id);


                        GetGameTeams(gameTeams, id);
                        games.Add(new Game(id, gameTeams[0], gameTeams[1]));
                    }
                }
                idReader.Close();
            }


            return games;
        }

        public void GetGameTeams(Team[] teamsArray, int gameID)
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);
            using (connection)
            {
                connection.Open();

                SqlCommand TeamsCommand = new SqlCommand();
                TeamsCommand.Connection = connection;
                TeamsCommand.CommandType = CommandType.Text;

                TeamsCommand.Parameters.Clear();
                TeamsCommand.Parameters.AddWithValue("@gameID", gameID.ToString());
                TeamsCommand.CommandText = "select * from GameTeam where GameID = @gameID";

                SqlDataReader reader = TeamsCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    int i = 0;
                    List<Team> teams = GetTeams();
                    while (reader.Read())
                    {

                        foreach (Team tm in teams)
                        {
                            if (tm.Name == String.Format("{0}", reader[1]).Trim())
                            {
                                teamsArray[i] = tm;
                                i++;
                            }
                        }

                    }
                }
                reader.Close();
            }
        }

        public Game GetGame(int GameID)
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);
            Game g;
            Team[] t = new Team[2];
            using (connection)
            {
                connection.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = connection;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from GameTeam where GameID = @gameID";
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@gameID", GameID);

                SqlDataReader rdr2 = cmd2.ExecuteReader();
                GetGameTeams(t, GameID);

                rdr2.Close();
            }

            g = new Game(GameID, t[0], t[1]);

            return g;
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
                command.CommandText = "select count(gameID) from Game";

                connection.Open();
                games = (int)command.ExecuteScalar();

            }
            return games;
        }

        public void SaveAnnotation(Annotation n, Game g)
        {
            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                connection.Open();
                string query;
                if (n.AuxPlayer != null)
                {
                    query = "insert annotations (ID, Motive, Time, Game, MainPlayerID, AuxPlayerID)" +
                        "values (@ID, @Motive, convert(datetime, @date, 103), @gameID, @playerID, @auxPlayerID)";
                }
                else
                {
                    query = "insert annotations (ID, Motive, Time, Game, MainPlayerID)"
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

        public List<Annotation> GetAnnotations(int GameID)
        {
            List<Annotation> annotations = new List<Annotation>();

            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                string query = "select * from Annotations where Game = @gameID";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@gameID", GameID);

                SqlDataReader rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (rdr.IsDBNull(4))
                        {
                            annotations.Add(new Annotation(rdr.GetDateTime(5), GetPlayer(rdr.GetInt32(3)),
                                GetMotiveInt(string.Format("{0}", rdr[1]).Trim()), rdr.GetInt32(0)));
                        }
                        else
                        {
                            annotations.Add(new Annotation(rdr.GetDateTime(5), GetPlayer(rdr.GetInt32(3)), GetPlayer(rdr.GetInt32(4)),
                                GetMotiveInt(string.Format("{0}", rdr[1]).Trim()), rdr.GetInt32(0)));
                        }

                    }
                }
                rdr.Close();
            }

            return annotations;
        }

        private int GetMotiveInt(string motiveString)
        {
            int motiveInt = 0;
            string[] allMotives = new string[11];
            Annotation.GetPossibleMotives(allMotives);

            for (int i = 0; i < 11; i++)
            {
                if (allMotives[i] == motiveString)
                {
                    motiveInt = i;
                }
            }

            return motiveInt;
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
                command.CommandText = "select count(ID) from Annotations";

                connection.Open();
                annotations = (int)command.ExecuteScalar();

            }
            return annotations;
        }

        public Player GetPlayer(int PlayerID)
        {
            Player p = null;
            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from player where ID = @PlayerID", connection);
                cmd.Parameters.AddWithValue("@PlayerID", PlayerID);
                cmd.CommandType = CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    p = new Player(string.Format("{0}", rdr[1]).Trim(), string.Format("{0}", rdr[2]),
                                    string.Format("{0}", rdr[3]).Trim(), 
                                    string.Format("{0}", rdr[4]).Trim(), rdr.GetInt32(0));
                }
            }

            return p;
        }
    }
}
