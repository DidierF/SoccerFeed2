using System.Windows.Forms;
namespace SoccerFeed2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.annotationHistory = new System.Windows.Forms.TextBox();
            this.playComboBox = new System.Windows.Forms.ComboBox();
            this.playerComboBox = new System.Windows.Forms.ComboBox();
            this.auxComboBox = new System.Windows.Forms.ComboBox();
            this.time = new System.Windows.Forms.Label();
            this.team1Score = new System.Windows.Forms.Label();
            this.team2Score = new System.Windows.Forms.Label();
            this.team1Check = new System.Windows.Forms.RadioButton();
            this.team2Check = new System.Windows.Forms.RadioButton();
            this.insertBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // annotationHistory
            // 
            this.annotationHistory.Location = new System.Drawing.Point(-1, 160);
            this.annotationHistory.Multiline = true;
            this.annotationHistory.Name = "annotationHistory";
            this.annotationHistory.Size = new System.Drawing.Size(643, 351);
            this.annotationHistory.TabIndex = 1;
            // 
            // playComboBox
            // 
            this.playComboBox.FormattingEnabled = true;
            this.playComboBox.Location = new System.Drawing.Point(233, 92);
            this.playComboBox.Name = "playComboBox";
            this.playComboBox.Size = new System.Drawing.Size(179, 21);
            this.playComboBox.TabIndex = 6;
            this.playComboBox.SelectedIndexChanged += new System.EventHandler(this.playComboBox_SelectedIndexChanged);
            // 
            // playerComboBox
            // 
            this.playerComboBox.FormattingEnabled = true;
            this.playerComboBox.Location = new System.Drawing.Point(13, 92);
            this.playerComboBox.Name = "playerComboBox";
            this.playerComboBox.Size = new System.Drawing.Size(179, 21);
            this.playerComboBox.TabIndex = 7;
            this.playerComboBox.SelectedIndexChanged += new System.EventHandler(this.playerComboBox_SelectedIndexChanged);
            // 
            // auxComboBox
            // 
            this.auxComboBox.FormattingEnabled = true;
            this.auxComboBox.Location = new System.Drawing.Point(450, 92);
            this.auxComboBox.Name = "auxComboBox";
            this.auxComboBox.Size = new System.Drawing.Size(179, 21);
            this.auxComboBox.TabIndex = 8;
            this.auxComboBox.SelectedIndexChanged += new System.EventHandler(this.auxComboBox_SelectedIndexChanged);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(595, 33);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(34, 13);
            this.time.TabIndex = 9;
            this.time.Text = "00:00";
            // 
            // team1Score
            // 
            this.team1Score.AutoSize = true;
            this.team1Score.Location = new System.Drawing.Point(144, 35);
            this.team1Score.Name = "team1Score";
            this.team1Score.Size = new System.Drawing.Size(13, 13);
            this.team1Score.TabIndex = 10;
            this.team1Score.Text = "0";
            // 
            // team2Score
            // 
            this.team2Score.AutoSize = true;
            this.team2Score.Location = new System.Drawing.Point(144, 54);
            this.team2Score.Name = "team2Score";
            this.team2Score.Size = new System.Drawing.Size(13, 13);
            this.team2Score.TabIndex = 11;
            this.team2Score.Text = "0";
            // 
            // team1Check
            // 
            this.team1Check.AutoSize = true;
            this.team1Check.Location = new System.Drawing.Point(12, 33);
            this.team1Check.Name = "team1Check";
            this.team1Check.Size = new System.Drawing.Size(85, 17);
            this.team1Check.TabIndex = 12;
            this.team1Check.TabStop = true;
            this.team1Check.Text = "radioButton1";
            this.team1Check.UseVisualStyleBackColor = true;
            this.team1Check.CheckedChanged += new System.EventHandler(this.team1Check_CheckedChanged);
            // 
            // team2Check
            // 
            this.team2Check.AutoSize = true;
            this.team2Check.Location = new System.Drawing.Point(12, 52);
            this.team2Check.Name = "team2Check";
            this.team2Check.Size = new System.Drawing.Size(85, 17);
            this.team2Check.TabIndex = 13;
            this.team2Check.TabStop = true;
            this.team2Check.Text = "radioButton2";
            this.team2Check.UseVisualStyleBackColor = true;
            this.team2Check.CheckedChanged += new System.EventHandler(this.team2Check_CheckedChanged);
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(513, 118);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(116, 36);
            this.insertBtn.TabIndex = 14;
            this.insertBtn.Text = "Insert Annotation";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SoccerFeed2.Properties.Resources.SoccerFeedLogo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(284, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 89);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 507);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.team2Check);
            this.Controls.Add(this.team1Check);
            this.Controls.Add(this.team2Score);
            this.Controls.Add(this.team1Score);
            this.Controls.Add(this.time);
            this.Controls.Add(this.auxComboBox);
            this.Controls.Add(this.playerComboBox);
            this.Controls.Add(this.playComboBox);
            this.Controls.Add(this.annotationHistory);
            this.Name = "MainWindow";
            this.Text = "SoccerFeed";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox annotationHistory;
        private ComboBox playComboBox;
        private ComboBox playerComboBox;
        private ComboBox auxComboBox;
        private Label time;
        private Label team1Score;
        private Label team2Score;
        private RadioButton team1Check;
        private RadioButton team2Check;
        private Button insertBtn;
        private Timer timer1;
        private PictureBox pictureBox1;
    }
}

