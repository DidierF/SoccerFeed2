using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoccerFeed2.Database;

namespace SoccerFeed2
{
    public partial class MainWindow : Form
    {
        public Game Game { get; private set; }
        public DateTime currentTime { get; private set; }
        public TimeSpan actualTime { get; private set; }
        public Player mainPlayer{ get; private set; }
        public Player auxPlayer{ get; private set; }
        public int annotationMotive { get; private set; }

        //TODO: Extract logic to another class!

        public MainWindow(Game gm)
        {
            InitializeComponent();
            ///Sets the window not resizable.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            annotationHistory.ReadOnly = true;
            annotationHistory.BackColor = System.Drawing.SystemColors.Window;
            this.Game = gm;
            team1Check.Text = Game.HomeTeam.Name;
            team2Check.Text = Game.AwayTeam.Name;
            currentTime = new DateTime();

            playComboBox.Items.AddRange(new string[] 
            {
                "Goal", "Foul", "Red Card", "Yellow Card", "Substitution",
                "Goal Kick", "Throw In", "Corner", "Offside", "Free Throw", "Penalty"
            });
            annotationHistory.AppendText("[" + System.DateTime.Now + "] " + "Game Start.\n");
            annotationHistory.Update(); 
            timer1.Interval = 1000; 
            timer1.Start();
            DisplayAnnotations(Game.ID);
            auxComboBox.Enabled = false; 
        }

        private void DisplayAnnotations(int gameID)
        {
            List<Annotation> anns = new DataBaseInterface().GetAnnotations(gameID);

            foreach (Annotation a in anns)
            {
                Game.addAnnotation(a);
                annotationHistory.AppendText(a.ToString() + "\n");
                UpdateScore(a);
            }
        }

        private void UpdateScore(Annotation a)
        {

            if (a.Motive == "Goal")
            {
                team1Score.Text = Game.Score[0].ToString();
                team2Score.Text = Game.Score[1].ToString();
            }
            team1Score.Update();
            team2Score.Update();
        }

        private void team1Check_CheckedChanged(object sender, EventArgs e)
        {
            if (team1Check.Checked)
            {
                playerComboBox.Text = "";
                playerComboBox.Items.Clear();
                foreach (Player p in Game.HomeTeam.InGamePlayers)
                {
                    playerComboBox.Items.Add(p.Name);
                }
            }
        }

        private void team2Check_CheckedChanged(object sender, EventArgs e)
        {
            if (team2Check.Checked)
            {
                playerComboBox.Text = "";
                playerComboBox.Items.Clear();
                foreach (Player p in Game.AwayTeam.InGamePlayers)
                {
                    playerComboBox.Items.Add(p.Name);
                }
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (!(playerComboBox.SelectedItem == null || playComboBox.SelectedItem == null) && 
                !(auxComboBox.Enabled && auxComboBox.SelectedItem == null && playComboBox.SelectedIndex != 0))
            {
            DateTime currentTime = Game.StartTime.Add(actualTime);
            int motive = playComboBox.SelectedIndex;
            int newID = new DataBaseInterface().GetNewAnnotationID();
            Annotation ann = new Annotation(currentTime, this.mainPlayer, this.auxPlayer, annotationMotive, newID);

            Game.addAnnotation(ann);
            new DataBaseInterface().SaveAnnotation(ann, Game);

            annotationHistory.AppendText(ann.ToString() + "\n");
            annotationHistory.Update(); 
            UpdateScore(ann);
            if (annotationMotive == 4) UpdateTeams(); 

            playerComboBox.ResetText();
            playComboBox.ResetText();
            auxComboBox.ResetText();
            mainPlayer = null;
            annotationMotive = '0';
            auxPlayer = null;
            auxComboBox.Enabled = false; 
            }

        }

        private void playComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox playCB = (ComboBox)sender;
            List<Player> players = new List<Player>();
            switch (playCB.SelectedIndex)
            {
                case 2:
                case 3:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    auxComboBox.ResetText();
                    auxComboBox.Enabled = false;
                    break;
                case 0:
                    auxComboBox.ResetText();
                    auxComboBox.Enabled = true;
                    if (team1Check.Checked)
                    {
                        players = Game.HomeTeam.InGamePlayers;
                    }
                    else if (team2Check.Checked)
                    {
                        players = Game.AwayTeam.InGamePlayers;
                    }
                    break;
                case 1:
                    auxComboBox.ResetText();
                    auxComboBox.Enabled = true;
                    if (team1Check.Checked)
                    {
                        players = Game.AwayTeam.InGamePlayers;
                    }
                    else if (team2Check.Checked)
                    {
                        players = Game.HomeTeam.InGamePlayers;
                    }
                    break;
                case 4:
                    auxComboBox.ResetText();
                    auxComboBox.Enabled = true;
                    if (team1Check.Checked)
                    {
                        players = Game.HomeTeam.AvailablePlayers;
                    }
                    else if (team2Check.Checked)
                    {
                        players = Game.AwayTeam.AvailablePlayers;
                    }
                    break;
            }
            auxComboBox.Items.Clear();
            foreach (Player p in players)
            {
                auxComboBox.Items.Add(p.Name);
            }
            annotationMotive = playCB.SelectedIndex;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           currentTime = System.DateTime.Now; 
           actualTime = currentTime.Subtract(Game.StartTime);
           time.Text = actualTime.Minutes + ":" + actualTime.Seconds;  
        }

        private void auxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox auxCB = (ComboBox)sender;

            switch (annotationMotive)
            {
                case 0: 
                    if(team1Check.Checked)
                    {
                        this.auxPlayer = Game.HomeTeam.InGamePlayers[auxCB.SelectedIndex]; 
                    }
                    if(team2Check.Checked)
                    {
                        this.auxPlayer = Game.AwayTeam.InGamePlayers[auxCB.SelectedIndex];
                    }
                    break; 
                case 1:
                    if(team1Check.Checked)
                    {
                        this.auxPlayer = Game.AwayTeam.InGamePlayers[auxCB.SelectedIndex]; 
                    }
                    if (team2Check.Checked)
                    {
                        this.auxPlayer = Game.HomeTeam.InGamePlayers[auxCB.SelectedIndex]; 
                    }
                    break;
                case 4:
                    if(team1Check.Checked)
                    {
                        this.auxPlayer = Game.HomeTeam.AvailablePlayers[auxCB.SelectedIndex];
                    }
                    if(team2Check.Checked)
                    {
                        this.auxPlayer = Game.AwayTeam.AvailablePlayers[auxCB.SelectedIndex]; 
                    }
                    break;
                default:
                    break; 
            }
        }

        private void playerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (team1Check.Checked)
            {
                this.mainPlayer = Game.HomeTeam.InGamePlayers[playerComboBox.SelectedIndex];
            }
            else
            {
                this.mainPlayer = Game.AwayTeam.InGamePlayers[playerComboBox.SelectedIndex];
            }
        }

        private void UpdateTeams()
        {
            List<Player> updatedTeam = new List<Player>();
            if (team1Check.Checked) updatedTeam = Game.HomeTeam.InGamePlayers;
            if (team2Check.Checked) updatedTeam = Game.AwayTeam.InGamePlayers;

            playerComboBox.Items.Clear(); 
            foreach (Player player in updatedTeam) playerComboBox.Items.Add(player.Name);
        }
    }
}
