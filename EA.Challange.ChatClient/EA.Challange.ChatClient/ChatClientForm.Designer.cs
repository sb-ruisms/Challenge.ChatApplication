using System.ComponentModel;
using System.Windows.Forms;

namespace EA.Challange.ChatClient
{
    partial class ChatClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatClientForm));
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.lblCurrentUserId = new System.Windows.Forms.Label();
            this.lblHostIP = new System.Windows.Forms.Label();
            this.txtHostIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.gbChatBuddies = new System.Windows.Forms.GroupBox();
            this.lblCurrentBuddyId = new System.Windows.Forms.Label();
            this.txtChattingWith = new System.Windows.Forms.TextBox();
            this.lblChattingWith = new System.Windows.Forms.Label();
            this.btnSelectChatBuddy = new System.Windows.Forms.Button();
            this.cbxSelectChatBuddy = new System.Windows.Forms.ComboBox();
            this.lblSelectChatBuddy = new System.Windows.Forms.Label();
            this.gbChatWindow = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblEnterChat = new System.Windows.Forms.Label();
            this.lbChatWindow = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.gbConnect.SuspendLayout();
            this.gbChatBuddies.SuspendLayout();
            this.gbChatWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.lblCurrentUserId);
            this.gbConnect.Controls.Add(this.lblHostIP);
            this.gbConnect.Controls.Add(this.txtHostIP);
            this.gbConnect.Controls.Add(this.btnConnect);
            this.gbConnect.Controls.Add(this.txtPort);
            this.gbConnect.Controls.Add(this.lblPort);
            this.gbConnect.Controls.Add(this.lblUsername);
            this.gbConnect.Controls.Add(this.txtUsername);
            this.gbConnect.Location = new System.Drawing.Point(10, 44);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(323, 116);
            this.gbConnect.TabIndex = 0;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Connect";
            // 
            // lblCurrentUserId
            // 
            this.lblCurrentUserId.AutoSize = true;
            this.lblCurrentUserId.Location = new System.Drawing.Point(21, 94);
            this.lblCurrentUserId.Name = "lblCurrentUserId";
            this.lblCurrentUserId.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentUserId.TabIndex = 7;
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Location = new System.Drawing.Point(163, 24);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(49, 13);
            this.lblHostIP.TabIndex = 6;
            this.lblHostIP.Text = "Host IP*:";
            // 
            // txtHostIP
            // 
            this.txtHostIP.Location = new System.Drawing.Point(211, 20);
            this.txtHostIP.Name = "txtHostIP";
            this.txtHostIP.Size = new System.Drawing.Size(100, 20);
            this.txtHostIP.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(166, 56);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(98, 21);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(46, 57);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(14, 60);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(33, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port*:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 23);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(42, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Name*:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(46, 20);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // gbChatBuddies
            // 
            this.gbChatBuddies.Controls.Add(this.lblCurrentBuddyId);
            this.gbChatBuddies.Controls.Add(this.txtChattingWith);
            this.gbChatBuddies.Controls.Add(this.lblChattingWith);
            this.gbChatBuddies.Controls.Add(this.btnSelectChatBuddy);
            this.gbChatBuddies.Controls.Add(this.cbxSelectChatBuddy);
            this.gbChatBuddies.Controls.Add(this.lblSelectChatBuddy);
            this.gbChatBuddies.Location = new System.Drawing.Point(343, 44);
            this.gbChatBuddies.Name = "gbChatBuddies";
            this.gbChatBuddies.Size = new System.Drawing.Size(296, 116);
            this.gbChatBuddies.TabIndex = 1;
            this.gbChatBuddies.TabStop = false;
            this.gbChatBuddies.Text = "Chat Buddies";
            // 
            // lblCurrentBuddyId
            // 
            this.lblCurrentBuddyId.AutoSize = true;
            this.lblCurrentBuddyId.Location = new System.Drawing.Point(17, 87);
            this.lblCurrentBuddyId.Name = "lblCurrentBuddyId";
            this.lblCurrentBuddyId.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentBuddyId.TabIndex = 10;
            // 
            // txtChattingWith
            // 
            this.txtChattingWith.Enabled = false;
            this.txtChattingWith.Location = new System.Drawing.Point(112, 57);
            this.txtChattingWith.Name = "txtChattingWith";
            this.txtChattingWith.Size = new System.Drawing.Size(121, 20);
            this.txtChattingWith.TabIndex = 9;
            // 
            // lblChattingWith
            // 
            this.lblChattingWith.AutoSize = true;
            this.lblChattingWith.Location = new System.Drawing.Point(9, 60);
            this.lblChattingWith.Name = "lblChattingWith";
            this.lblChattingWith.Size = new System.Drawing.Size(99, 13);
            this.lblChattingWith.TabIndex = 8;
            this.lblChattingWith.Text = "Now Chatting With:";
            // 
            // btnSelectChatBuddy
            // 
            this.btnSelectChatBuddy.Location = new System.Drawing.Point(246, 18);
            this.btnSelectChatBuddy.Name = "btnSelectChatBuddy";
            this.btnSelectChatBuddy.Size = new System.Drawing.Size(44, 21);
            this.btnSelectChatBuddy.TabIndex = 7;
            this.btnSelectChatBuddy.Text = "Go";
            this.btnSelectChatBuddy.UseVisualStyleBackColor = true;
            this.btnSelectChatBuddy.Click += new System.EventHandler(this.btnSelectChatBuddy_Click);
            // 
            // cbxSelectChatBuddy
            // 
            this.cbxSelectChatBuddy.FormattingEnabled = true;
            this.cbxSelectChatBuddy.Location = new System.Drawing.Point(112, 19);
            this.cbxSelectChatBuddy.Name = "cbxSelectChatBuddy";
            this.cbxSelectChatBuddy.Size = new System.Drawing.Size(121, 21);
            this.cbxSelectChatBuddy.TabIndex = 1;
            // 
            // lblSelectChatBuddy
            // 
            this.lblSelectChatBuddy.AutoSize = true;
            this.lblSelectChatBuddy.Location = new System.Drawing.Point(9, 23);
            this.lblSelectChatBuddy.Name = "lblSelectChatBuddy";
            this.lblSelectChatBuddy.Size = new System.Drawing.Size(98, 13);
            this.lblSelectChatBuddy.TabIndex = 0;
            this.lblSelectChatBuddy.Text = "Select Chat Buddy:";
            // 
            // gbChatWindow
            // 
            this.gbChatWindow.Controls.Add(this.btnSend);
            this.gbChatWindow.Controls.Add(this.txtMessage);
            this.gbChatWindow.Controls.Add(this.lblEnterChat);
            this.gbChatWindow.Controls.Add(this.lbChatWindow);
            this.gbChatWindow.Location = new System.Drawing.Point(11, 176);
            this.gbChatWindow.Name = "gbChatWindow";
            this.gbChatWindow.Size = new System.Drawing.Size(628, 268);
            this.gbChatWindow.TabIndex = 2;
            this.gbChatWindow.TabStop = false;
            this.gbChatWindow.Text = "Chat Window";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(560, 236);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(58, 21);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(59, 237);
            this.txtMessage.MaxLength = 500;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(495, 20);
            this.txtMessage.TabIndex = 2;
            // 
            // lblEnterChat
            // 
            this.lblEnterChat.AutoSize = true;
            this.lblEnterChat.Location = new System.Drawing.Point(8, 240);
            this.lblEnterChat.Name = "lblEnterChat";
            this.lblEnterChat.Size = new System.Drawing.Size(50, 13);
            this.lblEnterChat.TabIndex = 1;
            this.lblEnterChat.Text = "Enter IM:";
            // 
            // lbChatWindow
            // 
            this.lbChatWindow.FormattingEnabled = true;
            this.lbChatWindow.Location = new System.Drawing.Point(9, 19);
            this.lbChatWindow.Name = "lbChatWindow";
            this.lbChatWindow.Size = new System.Drawing.Size(609, 212);
            this.lbChatWindow.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 13);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 3;
            // 
            // ChatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.gbChatWindow);
            this.Controls.Add(this.gbChatBuddies);
            this.Controls.Add(this.gbConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EA.Challenge.ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClientForm_FormClosing);
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.gbChatBuddies.ResumeLayout(false);
            this.gbChatBuddies.PerformLayout();
            this.gbChatWindow.ResumeLayout(false);
            this.gbChatWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GroupBox gbConnect;
        public Button btnConnect;
        public TextBox txtPort;
        public Label lblPort;
        public Label lblUsername;
        public TextBox txtUsername;
        public Label lblHostIP;
        public TextBox txtHostIP;
        public GroupBox gbChatBuddies;
        public ComboBox cbxSelectChatBuddy;
        public Label lblSelectChatBuddy;
        public Button btnSelectChatBuddy;
        public TextBox txtChattingWith;
        public Label lblChattingWith;
        public GroupBox gbChatWindow;
        public Button btnSend;
        public TextBox txtMessage;
        public Label lblEnterChat;
        public ListBox lbChatWindow;
        public Label lblCurrentUserId;
        public Label lblCurrentBuddyId;
        public Label lblError;
    }
}

