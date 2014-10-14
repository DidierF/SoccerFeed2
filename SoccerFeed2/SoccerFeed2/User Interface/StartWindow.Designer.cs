namespace SoccerFeed2
{
    partial class StartWindow
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
            this.OpenBtn = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.ComboBox();
            this.away = new System.Windows.Forms.ComboBox();
            this.Team1Players = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Stadium = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.TextBox();
            this.Team2Players = new System.Windows.Forms.TextBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(13, 13);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenBtn.TabIndex = 0;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // home
            // 
            this.home.FormattingEnabled = true;
            this.home.Location = new System.Drawing.Point(12, 104);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(184, 21);
            this.home.TabIndex = 2;
            this.home.Text = "Home";
            this.home.SelectedIndexChanged += new System.EventHandler(this.home_SelectedIndexChanged);
            // 
            // away
            // 
            this.away.FormattingEnabled = true;
            this.away.Location = new System.Drawing.Point(247, 104);
            this.away.Name = "away";
            this.away.Size = new System.Drawing.Size(184, 21);
            this.away.TabIndex = 3;
            this.away.Text = "Away";
            this.away.SelectedIndexChanged += new System.EventHandler(this.away_SelectedIndexChanged);
            // 
            // Team1Players
            // 
            this.Team1Players.Location = new System.Drawing.Point(12, 151);
            this.Team1Players.Multiline = true;
            this.Team1Players.Name = "Team1Players";
            this.Team1Players.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Team1Players.Size = new System.Drawing.Size(184, 328);
            this.Team1Players.TabIndex = 4;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(306, 492);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(125, 42);
            this.Start.TabIndex = 5;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stadium
            // 
            this.Stadium.Location = new System.Drawing.Point(13, 514);
            this.Stadium.Name = "Stadium";
            this.Stadium.Size = new System.Drawing.Size(123, 20);
            this.Stadium.TabIndex = 6;
            this.Stadium.Text = "Stadium";
            this.Stadium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(177, 514);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(123, 20);
            this.Date.TabIndex = 7;
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Team2Players
            // 
            this.Team2Players.Location = new System.Drawing.Point(247, 151);
            this.Team2Players.Multiline = true;
            this.Team2Players.Name = "Team2Players";
            this.Team2Players.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Team2Players.Size = new System.Drawing.Size(184, 328);
            this.Team2Players.TabIndex = 8;
            // 
            // Logo
            // 
            this.Logo.Location = new System.Drawing.Point(177, 13);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(100, 50);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 555);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.Team2Players);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Stadium);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Team1Players);
            this.Controls.Add(this.away);
            this.Controls.Add(this.home);
            this.Controls.Add(this.OpenBtn);
            this.Name = "StartWindow";
            this.Text = "StartWindow";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.ComboBox home;
        private System.Windows.Forms.ComboBox away;
        private System.Windows.Forms.TextBox Team1Players;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox Stadium;
        private System.Windows.Forms.TextBox Date;
        private System.Windows.Forms.TextBox Team2Players;
        private System.Windows.Forms.PictureBox Logo;
    }
}