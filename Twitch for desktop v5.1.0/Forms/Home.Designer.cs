namespace Twitch_for_desktop_v5_1_0.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainLeft = new System.Windows.Forms.Panel();
            this.btnFollowing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHLine_2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnVideos = new System.Windows.Forms.Button();
            this.btnChannels = new System.Windows.Forms.Button();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.labelHLine_1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pbPanelLeft = new System.Windows.Forms.PictureBox();
            this.panelMainRight = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitleTab = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.mainLayoutPanel.SuspendLayout();
            this.panelMainLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.panelMainLeft, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.panelMainRight, 1, 0);
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 35);
            this.mainLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 1;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(970, 695);
            this.mainLayoutPanel.TabIndex = 2;
            // 
            // panelMainLeft
            // 
            this.panelMainLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(20)))), ((int)(((byte)(31)))));
            this.panelMainLeft.Controls.Add(this.btnFollowing);
            this.panelMainLeft.Controls.Add(this.label1);
            this.panelMainLeft.Controls.Add(this.labelHLine_2);
            this.panelMainLeft.Controls.Add(this.btnLogout);
            this.panelMainLeft.Controls.Add(this.btnOptions);
            this.panelMainLeft.Controls.Add(this.btnVideos);
            this.panelMainLeft.Controls.Add(this.btnChannels);
            this.panelMainLeft.Controls.Add(this.btnDiscover);
            this.panelMainLeft.Controls.Add(this.btnGames);
            this.panelMainLeft.Controls.Add(this.btnLive);
            this.panelMainLeft.Controls.Add(this.labelHLine_1);
            this.panelMainLeft.Controls.Add(this.labelUsername);
            this.panelMainLeft.Controls.Add(this.pbPanelLeft);
            this.panelMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMainLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainLeft.Name = "panelMainLeft";
            this.panelMainLeft.Size = new System.Drawing.Size(300, 695);
            this.panelMainLeft.TabIndex = 0;
            // 
            // btnFollowing
            // 
            this.btnFollowing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFollowing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFollowing.ForeColor = System.Drawing.Color.White;
            this.btnFollowing.Location = new System.Drawing.Point(12, 510);
            this.btnFollowing.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btnFollowing.Name = "btnFollowing";
            this.btnFollowing.Size = new System.Drawing.Size(278, 36);
            this.btnFollowing.TabIndex = 12;
            this.btnFollowing.Text = "Following";
            this.btnFollowing.UseVisualStyleBackColor = true;
            this.btnFollowing.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 483);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 7);
            this.label1.TabIndex = 11;
            // 
            // labelHLine_2
            // 
            this.labelHLine_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHLine_2.BackColor = System.Drawing.Color.Gray;
            this.labelHLine_2.Location = new System.Drawing.Point(0, 628);
            this.labelHLine_2.Margin = new System.Windows.Forms.Padding(0);
            this.labelHLine_2.Name = "labelHLine_2";
            this.labelHLine_2.Size = new System.Drawing.Size(300, 7);
            this.labelHLine_2.TabIndex = 10;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(12, 645);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(278, 36);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Location = new System.Drawing.Point(12, 582);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(278, 36);
            this.btnOptions.TabIndex = 8;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnVideos
            // 
            this.btnVideos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVideos.ForeColor = System.Drawing.Color.White;
            this.btnVideos.Location = new System.Drawing.Point(12, 427);
            this.btnVideos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnVideos.Name = "btnVideos";
            this.btnVideos.Size = new System.Drawing.Size(278, 36);
            this.btnVideos.TabIndex = 7;
            this.btnVideos.Text = "Videos";
            this.btnVideos.UseVisualStyleBackColor = true;
            this.btnVideos.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnChannels
            // 
            this.btnChannels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChannels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChannels.ForeColor = System.Drawing.Color.White;
            this.btnChannels.Location = new System.Drawing.Point(12, 381);
            this.btnChannels.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnChannels.Name = "btnChannels";
            this.btnChannels.Size = new System.Drawing.Size(278, 36);
            this.btnChannels.TabIndex = 6;
            this.btnChannels.Text = "Channels";
            this.btnChannels.UseVisualStyleBackColor = true;
            this.btnChannels.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnDiscover
            // 
            this.btnDiscover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDiscover.ForeColor = System.Drawing.Color.White;
            this.btnDiscover.Location = new System.Drawing.Point(12, 335);
            this.btnDiscover.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(278, 36);
            this.btnDiscover.TabIndex = 5;
            this.btnDiscover.Text = "Discover";
            this.btnDiscover.UseVisualStyleBackColor = true;
            this.btnDiscover.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnGames
            // 
            this.btnGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGames.ForeColor = System.Drawing.Color.White;
            this.btnGames.Location = new System.Drawing.Point(12, 289);
            this.btnGames.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(278, 36);
            this.btnGames.TabIndex = 4;
            this.btnGames.Text = "Games";
            this.btnGames.UseVisualStyleBackColor = true;
            this.btnGames.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // btnLive
            // 
            this.btnLive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLive.ForeColor = System.Drawing.Color.White;
            this.btnLive.Location = new System.Drawing.Point(12, 243);
            this.btnLive.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(278, 36);
            this.btnLive.TabIndex = 3;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.LeftPanel_btnClick);
            // 
            // labelHLine_1
            // 
            this.labelHLine_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHLine_1.BackColor = System.Drawing.Color.Gray;
            this.labelHLine_1.Location = new System.Drawing.Point(0, 216);
            this.labelHLine_1.Margin = new System.Windows.Forms.Padding(0);
            this.labelHLine_1.Name = "labelHLine_1";
            this.labelHLine_1.Size = new System.Drawing.Size(300, 7);
            this.labelHLine_1.TabIndex = 2;
            // 
            // labelUsername
            // 
            this.labelUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(12, 179);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(278, 29);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPanelLeft
            // 
            this.pbPanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPanelLeft.Image = global::Twitch_for_desktop_v5_1_0.Properties.Resources.twitch;
            this.pbPanelLeft.Location = new System.Drawing.Point(12, 42);
            this.pbPanelLeft.Name = "pbPanelLeft";
            this.pbPanelLeft.Size = new System.Drawing.Size(278, 111);
            this.pbPanelLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPanelLeft.TabIndex = 0;
            this.pbPanelLeft.TabStop = false;
            // 
            // panelMainRight
            // 
            this.panelMainRight.AutoScroll = true;
            this.panelMainRight.BackColor = System.Drawing.Color.White;
            this.panelMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainRight.Location = new System.Drawing.Point(300, 0);
            this.panelMainRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainRight.Name = "panelMainRight";
            this.panelMainRight.Size = new System.Drawing.Size(670, 695);
            this.panelMainRight.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(7, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(187, 25);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Twitch for desktop";
            // 
            // labelTitleTab
            // 
            this.labelTitleTab.AutoSize = true;
            this.labelTitleTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitleTab.ForeColor = System.Drawing.Color.Gray;
            this.labelTitleTab.Location = new System.Drawing.Point(296, 6);
            this.labelTitleTab.Name = "labelTitleTab";
            this.labelTitleTab.Size = new System.Drawing.Size(70, 24);
            this.labelTitleTab.TabIndex = 6;
            this.labelTitleTab.Tag = "";
            this.labelTitleTab.Text = "Games";
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(15)))), ((int)(((byte)(22)))));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::Twitch_for_desktop_v5_1_0.Properties.Resources.close;
            this.pbClose.Location = new System.Drawing.Point(935, 0);
            this.pbClose.Margin = new System.Windows.Forms.Padding(0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(35, 35);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 4;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(15)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(970, 730);
            this.Controls.Add(this.labelTitleTab);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.mainLayoutPanel.ResumeLayout(false);
            this.panelMainLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Panel panelMainLeft;
        private System.Windows.Forms.Label labelHLine_1;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.PictureBox pbPanelLeft;
        private System.Windows.Forms.Panel panelMainRight;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTitleTab;
        private System.Windows.Forms.Label labelHLine_2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnVideos;
        private System.Windows.Forms.Button btnChannels;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnFollowing;
        private System.Windows.Forms.Label label1;
    }
}