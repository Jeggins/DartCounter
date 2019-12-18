namespace DartCounter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button_GamesStart = new System.Windows.Forms.Button();
            this.button_Player = new System.Windows.Forms.Button();
            this.button_StartPoints = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Gamemode = new System.Windows.Forms.Button();
            this.label_Player1 = new System.Windows.Forms.Label();
            this.label_Player3 = new System.Windows.Forms.Label();
            this.label_Player2 = new System.Windows.Forms.Label();
            this.label_Player4 = new System.Windows.Forms.Label();
            this.button_CreatePlayer = new System.Windows.Forms.Button();
            this.button_Statistics = new System.Windows.Forms.Button();
            this.comboBox_Player1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Player2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Player3 = new System.Windows.Forms.ComboBox();
            this.comboBox_Player4 = new System.Windows.Forms.ComboBox();
            this.button_DeletePlayer = new System.Windows.Forms.Button();
            this.button_RotatePlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(65, 24, 64, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dart - Counter";
            // 
            // button_GamesStart
            // 
            this.button_GamesStart.BackColor = System.Drawing.Color.ForestGreen;
            this.button_GamesStart.Location = new System.Drawing.Point(79, 548);
            this.button_GamesStart.Margin = new System.Windows.Forms.Padding(70, 3, 70, 15);
            this.button_GamesStart.Name = "button_GamesStart";
            this.button_GamesStart.Size = new System.Drawing.Size(186, 50);
            this.button_GamesStart.TabIndex = 10;
            this.button_GamesStart.Text = "Spiel Starten";
            this.button_GamesStart.UseVisualStyleBackColor = false;
            this.button_GamesStart.Click += new System.EventHandler(this.button_GamesStart_Click);
            // 
            // button_Player
            // 
            this.button_Player.Location = new System.Drawing.Point(39, 130);
            this.button_Player.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.button_Player.Name = "button_Player";
            this.button_Player.Size = new System.Drawing.Size(100, 45);
            this.button_Player.TabIndex = 0;
            this.button_Player.Text = "1 Spieler";
            this.button_Player.UseVisualStyleBackColor = true;
            this.button_Player.Click += new System.EventHandler(this.button_Player_Click);
            // 
            // button_StartPoints
            // 
            this.button_StartPoints.Location = new System.Drawing.Point(205, 130);
            this.button_StartPoints.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.button_StartPoints.Name = "button_StartPoints";
            this.button_StartPoints.Size = new System.Drawing.Size(100, 45);
            this.button_StartPoints.TabIndex = 1;
            this.button_StartPoints.Text = "501";
            this.button_StartPoints.UseVisualStyleBackColor = true;
            this.button_StartPoints.Click += new System.EventHandler(this.button_StartPoints_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Spieleranzahl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Punkte";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Spielmodus";
            // 
            // button_Gamemode
            // 
            this.button_Gamemode.Location = new System.Drawing.Point(122, 227);
            this.button_Gamemode.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.button_Gamemode.Name = "button_Gamemode";
            this.button_Gamemode.Size = new System.Drawing.Size(100, 45);
            this.button_Gamemode.TabIndex = 2;
            this.button_Gamemode.Text = "Double - Out";
            this.button_Gamemode.UseVisualStyleBackColor = true;
            this.button_Gamemode.Click += new System.EventHandler(this.button_Gamemode_Click);
            // 
            // label_Player1
            // 
            this.label_Player1.AutoSize = true;
            this.label_Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player1.Location = new System.Drawing.Point(59, 308);
            this.label_Player1.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label_Player1.Name = "label_Player1";
            this.label_Player1.Size = new System.Drawing.Size(56, 15);
            this.label_Player1.TabIndex = 16;
            this.label_Player1.Text = "Spieler 1";
            // 
            // label_Player3
            // 
            this.label_Player3.AutoSize = true;
            this.label_Player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player3.Location = new System.Drawing.Point(59, 371);
            this.label_Player3.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label_Player3.Name = "label_Player3";
            this.label_Player3.Size = new System.Drawing.Size(56, 15);
            this.label_Player3.TabIndex = 18;
            this.label_Player3.Text = "Spieler 3";
            this.label_Player3.Visible = false;
            // 
            // label_Player2
            // 
            this.label_Player2.AutoSize = true;
            this.label_Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player2.Location = new System.Drawing.Point(232, 308);
            this.label_Player2.Margin = new System.Windows.Forms.Padding(3, 0, 50, 0);
            this.label_Player2.Name = "label_Player2";
            this.label_Player2.Size = new System.Drawing.Size(56, 15);
            this.label_Player2.TabIndex = 19;
            this.label_Player2.Text = "Spieler 2";
            this.label_Player2.Visible = false;
            // 
            // label_Player4
            // 
            this.label_Player4.AutoSize = true;
            this.label_Player4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player4.Location = new System.Drawing.Point(229, 371);
            this.label_Player4.Margin = new System.Windows.Forms.Padding(3, 0, 50, 0);
            this.label_Player4.Name = "label_Player4";
            this.label_Player4.Size = new System.Drawing.Size(56, 15);
            this.label_Player4.TabIndex = 20;
            this.label_Player4.Text = "Spieler 4";
            this.label_Player4.Visible = false;
            // 
            // button_CreatePlayer
            // 
            this.button_CreatePlayer.Location = new System.Drawing.Point(79, 440);
            this.button_CreatePlayer.Name = "button_CreatePlayer";
            this.button_CreatePlayer.Size = new System.Drawing.Size(186, 29);
            this.button_CreatePlayer.TabIndex = 7;
            this.button_CreatePlayer.Text = "Neuen Spieler anlegen";
            this.button_CreatePlayer.UseVisualStyleBackColor = true;
            this.button_CreatePlayer.Click += new System.EventHandler(this.button_CreatePlayer_Click);
            // 
            // button_Statistics
            // 
            this.button_Statistics.Location = new System.Drawing.Point(79, 510);
            this.button_Statistics.Name = "button_Statistics";
            this.button_Statistics.Size = new System.Drawing.Size(186, 29);
            this.button_Statistics.TabIndex = 9;
            this.button_Statistics.Text = "Statistiken";
            this.button_Statistics.UseVisualStyleBackColor = true;
            this.button_Statistics.Click += new System.EventHandler(this.button_Statistics_Click);
            // 
            // comboBox_Player1
            // 
            this.comboBox_Player1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Player1.FormattingEnabled = true;
            this.comboBox_Player1.Location = new System.Drawing.Point(12, 326);
            this.comboBox_Player1.MaxDropDownItems = 100;
            this.comboBox_Player1.Name = "comboBox_Player1";
            this.comboBox_Player1.Size = new System.Drawing.Size(147, 21);
            this.comboBox_Player1.TabIndex = 3;
            // 
            // comboBox_Player2
            // 
            this.comboBox_Player2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Player2.FormattingEnabled = true;
            this.comboBox_Player2.Location = new System.Drawing.Point(185, 326);
            this.comboBox_Player2.MaxDropDownItems = 100;
            this.comboBox_Player2.Name = "comboBox_Player2";
            this.comboBox_Player2.Size = new System.Drawing.Size(147, 21);
            this.comboBox_Player2.TabIndex = 4;
            this.comboBox_Player2.Visible = false;
            // 
            // comboBox_Player3
            // 
            this.comboBox_Player3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Player3.FormattingEnabled = true;
            this.comboBox_Player3.Location = new System.Drawing.Point(12, 389);
            this.comboBox_Player3.MaxDropDownItems = 100;
            this.comboBox_Player3.Name = "comboBox_Player3";
            this.comboBox_Player3.Size = new System.Drawing.Size(147, 21);
            this.comboBox_Player3.TabIndex = 5;
            this.comboBox_Player3.Visible = false;
            // 
            // comboBox_Player4
            // 
            this.comboBox_Player4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Player4.FormattingEnabled = true;
            this.comboBox_Player4.Location = new System.Drawing.Point(185, 389);
            this.comboBox_Player4.MaxDropDownItems = 100;
            this.comboBox_Player4.Name = "comboBox_Player4";
            this.comboBox_Player4.Size = new System.Drawing.Size(147, 21);
            this.comboBox_Player4.TabIndex = 6;
            this.comboBox_Player4.Visible = false;
            // 
            // button_DeletePlayer
            // 
            this.button_DeletePlayer.Location = new System.Drawing.Point(79, 475);
            this.button_DeletePlayer.Name = "button_DeletePlayer";
            this.button_DeletePlayer.Size = new System.Drawing.Size(186, 29);
            this.button_DeletePlayer.TabIndex = 8;
            this.button_DeletePlayer.Text = "Spieler löschen";
            this.button_DeletePlayer.UseVisualStyleBackColor = true;
            this.button_DeletePlayer.Click += new System.EventHandler(this.button_DeletePlayer_Click);
            // 
            // button_RotatePlayer
            // 
            this.button_RotatePlayer.Image = ((System.Drawing.Image)(resources.GetObject("button_RotatePlayer.Image")));
            this.button_RotatePlayer.Location = new System.Drawing.Point(158, 354);
            this.button_RotatePlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_RotatePlayer.Name = "button_RotatePlayer";
            this.button_RotatePlayer.Size = new System.Drawing.Size(28, 28);
            this.button_RotatePlayer.TabIndex = 21;
            this.button_RotatePlayer.UseVisualStyleBackColor = true;
            this.button_RotatePlayer.Visible = false;
            this.button_RotatePlayer.Click += new System.EventHandler(this.button_RotatePlayer_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button_GamesStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 622);
            this.Controls.Add(this.button_RotatePlayer);
            this.Controls.Add(this.button_DeletePlayer);
            this.Controls.Add(this.comboBox_Player4);
            this.Controls.Add(this.comboBox_Player3);
            this.Controls.Add(this.comboBox_Player2);
            this.Controls.Add(this.comboBox_Player1);
            this.Controls.Add(this.button_Statistics);
            this.Controls.Add(this.button_CreatePlayer);
            this.Controls.Add(this.label_Player4);
            this.Controls.Add(this.label_Player2);
            this.Controls.Add(this.label_Player3);
            this.Controls.Add(this.label_Player1);
            this.Controls.Add(this.button_Gamemode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_StartPoints);
            this.Controls.Add(this.button_Player);
            this.Controls.Add(this.button_GamesStart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dart - Counter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GamesStart;
        private System.Windows.Forms.Button button_Player;
        private System.Windows.Forms.Button button_StartPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Gamemode;
        private System.Windows.Forms.Label label_Player1;
        private System.Windows.Forms.Label label_Player3;
        private System.Windows.Forms.Label label_Player2;
        private System.Windows.Forms.Label label_Player4;
        private System.Windows.Forms.Button button_CreatePlayer;
        private System.Windows.Forms.Button button_Statistics;
        private System.Windows.Forms.ComboBox comboBox_Player1;
        private System.Windows.Forms.ComboBox comboBox_Player2;
        private System.Windows.Forms.ComboBox comboBox_Player3;
        private System.Windows.Forms.ComboBox comboBox_Player4;
        private System.Windows.Forms.Button button_DeletePlayer;
        private System.Windows.Forms.Button button_RotatePlayer;
    }
}

