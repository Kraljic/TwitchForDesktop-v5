using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Forms
{
    class UserPanel : Panel
    {
        public System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        public System.Windows.Forms.Panel panelMainLeft;
        public System.Windows.Forms.Button btnFollow;
        public System.Windows.Forms.Button btnFollowing;
        public System.Windows.Forms.Button btnFollowers;
        public System.Windows.Forms.Button btnHighlights;
        public System.Windows.Forms.Button btnPastBroadcasts;
        public System.Windows.Forms.Button btnOpenChat;
        public System.Windows.Forms.Label labelHLine_1;
        public System.Windows.Forms.Label labelUsername;
        public System.Windows.Forms.PictureBox pbPanelLeft;
        public System.Windows.Forms.Panel panelMainRight;
        public System.Windows.Forms.Button btnSubscribe;
        public System.Windows.Forms.Label labelHLine_2;

        public void InitializeComponent()
        {
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainLeft = new System.Windows.Forms.Panel();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.labelHLine_2 = new System.Windows.Forms.Label();
            this.btnFollow = new System.Windows.Forms.Button();
            this.btnFollowing = new System.Windows.Forms.Button();
            this.btnFollowers = new System.Windows.Forms.Button();
            this.btnHighlights = new System.Windows.Forms.Button();
            this.btnPastBroadcasts = new System.Windows.Forms.Button();
            this.btnOpenChat = new System.Windows.Forms.Button();
            this.labelHLine_1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pbPanelLeft = new System.Windows.Forms.PictureBox();
            this.panelMainRight = new System.Windows.Forms.Panel();
            this.mainLayoutPanel.SuspendLayout();
            this.panelMainLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelLeft)).BeginInit();
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
            this.mainLayoutPanel.TabIndex = 10;
            this.mainLayoutPanel.Size = this.Size;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            // 
            // panelMainLeft
            // 
            this.panelMainLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(20)))), ((int)(((byte)(31)))));
            this.panelMainLeft.Controls.Add(this.btnSubscribe);
            this.panelMainLeft.Controls.Add(this.labelHLine_2);
            this.panelMainLeft.Controls.Add(this.btnFollow);
            this.panelMainLeft.Controls.Add(this.btnFollowing);
            this.panelMainLeft.Controls.Add(this.btnFollowers);
            this.panelMainLeft.Controls.Add(this.btnHighlights);
            this.panelMainLeft.Controls.Add(this.btnPastBroadcasts);
            this.panelMainLeft.Controls.Add(this.btnOpenChat);
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
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSubscribe.ForeColor = System.Drawing.Color.White;
            this.btnSubscribe.Location = new System.Drawing.Point(12, 513);
            this.btnSubscribe.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(278, 36);
            this.btnSubscribe.TabIndex = 9;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            // 
            // labelHLine_2
            // 
            this.labelHLine_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHLine_2.BackColor = System.Drawing.Color.Gray;
            this.labelHLine_2.Location = new System.Drawing.Point(-3, 439);
            this.labelHLine_2.Margin = new System.Windows.Forms.Padding(0);
            this.labelHLine_2.Name = "labelHLine_2";
            this.labelHLine_2.Size = new System.Drawing.Size(300, 7);
            this.labelHLine_2.TabIndex = 8;
            // 
            // btnFollow
            // 
            this.btnFollow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFollow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFollow.ForeColor = System.Drawing.Color.White;
            this.btnFollow.Location = new System.Drawing.Point(12, 467);
            this.btnFollow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(278, 36);
            this.btnFollow.TabIndex = 7;
            this.btnFollow.Text = "Follow";
            this.btnFollow.UseVisualStyleBackColor = true;
            // 
            // btnFollowing
            // 
            this.btnFollowing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFollowing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFollowing.ForeColor = System.Drawing.Color.White;
            this.btnFollowing.Location = new System.Drawing.Point(12, 381);
            this.btnFollowing.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.btnFollowing.Name = "btnFollowing";
            this.btnFollowing.Size = new System.Drawing.Size(278, 36);
            this.btnFollowing.TabIndex = 6;
            this.btnFollowing.Text = "Following";
            this.btnFollowing.UseVisualStyleBackColor = true;
            // 
            // btnFollowers
            // 
            this.btnFollowers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFollowers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollowers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFollowers.ForeColor = System.Drawing.Color.White;
            this.btnFollowers.Location = new System.Drawing.Point(12, 335);
            this.btnFollowers.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFollowers.Name = "btnFollowers";
            this.btnFollowers.Size = new System.Drawing.Size(278, 36);
            this.btnFollowers.TabIndex = 5;
            this.btnFollowers.Text = "Followers";
            this.btnFollowers.UseVisualStyleBackColor = true;
            // 
            // btnHighlights
            // 
            this.btnHighlights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHighlights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHighlights.ForeColor = System.Drawing.Color.White;
            this.btnHighlights.Location = new System.Drawing.Point(12, 289);
            this.btnHighlights.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnHighlights.Name = "btnHighlights";
            this.btnHighlights.Size = new System.Drawing.Size(278, 36);
            this.btnHighlights.TabIndex = 4;
            this.btnHighlights.Text = "Highlights";
            this.btnHighlights.UseVisualStyleBackColor = true;
            // 
            // btnPastBroadcasts
            // 
            this.btnPastBroadcasts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPastBroadcasts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastBroadcasts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPastBroadcasts.ForeColor = System.Drawing.Color.White;
            this.btnPastBroadcasts.Location = new System.Drawing.Point(12, 243);
            this.btnPastBroadcasts.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btnPastBroadcasts.Name = "btnPastBroadcasts";
            this.btnPastBroadcasts.Size = new System.Drawing.Size(278, 36);
            this.btnPastBroadcasts.TabIndex = 3;
            this.btnPastBroadcasts.Text = "Past Broadcasts";
            this.btnPastBroadcasts.UseVisualStyleBackColor = true;
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOpenChat.ForeColor = System.Drawing.Color.White;
            this.btnOpenChat.Location = new System.Drawing.Point(12, 559);
            this.btnOpenChat.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(278, 36);
            this.btnOpenChat.TabIndex = 3;
            this.btnOpenChat.Text = "Chat";
            this.btnOpenChat.UseVisualStyleBackColor = true;
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
            this.pbPanelLeft.Location = new System.Drawing.Point(12, 42);
            this.pbPanelLeft.Name = "pbPanelLeft";
            this.pbPanelLeft.Size = new System.Drawing.Size(278, 111);
            this.pbPanelLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPanelLeft.TabIndex = 0;
            this.pbPanelLeft.TabStop = false;
            // 
            // panelMainRight
            // 
            this.panelMainRight.BackColor = System.Drawing.Color.White;
            this.panelMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainRight.Location = new System.Drawing.Point(300, 0);
            this.panelMainRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainRight.Name = "panelMainRight";
            this.panelMainRight.Size = new System.Drawing.Size(670, 695);
            this.panelMainRight.TabIndex = 1;
            this.panelMainRight.AutoScroll = true;
            //
            // UserPanel
            //
            this.Margin = new Padding(0);
            this.Location = new System.Drawing.Point(0, 0);
            this.Dock = DockStyle.Fill;

            this.Controls.Add(this.mainLayoutPanel);
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelLeft)).EndInit();
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }        
    }
}
