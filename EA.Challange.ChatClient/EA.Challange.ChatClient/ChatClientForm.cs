using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EA.Challange.ChatClient.Contracts.IService;
using EA.Challange.ChatClient.Models.Models;
using EA.Challange.ChatClient.Service.Service;
using NLog;
using ILogger = EA.Challange.ChatClient.Contracts.IService.ILogger;
using Logger = EA.Challange.ChatClient.Service.Service.Logger;

namespace EA.Challange.ChatClient
{
    public partial class ChatClientForm : Form
    {
        private static readonly ILogger _logger = new Logger();
        private readonly IUserConnect _userConnect = new UserConnect(_logger);
        private readonly IMessaging _messaging = new Messaging(_logger);
        private volatile bool _stopPolling;
        private volatile bool _stopPollingHb;
        private Thread buddyPollThread, chatPollThread;
    
        public ChatClientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connects Or Disconnects User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputsToConnect())
                {
                    var user = new User()
                    {
                        UserId = btnConnect.Text == "Connect" ? Guid.NewGuid().ToString() : lblCurrentUserId.Text,
                        UserName = txtUsername.Text
                    };

                    if (btnConnect.Text == "Connect")
                    {
                        var message = _userConnect.ConnectUser(txtHostIP.Text, txtPort.Text, user);
                        ShowMessage(Enums.NLogType.Info, message);
                        lblCurrentUserId.Text = user.UserId;
                        btnConnect.Text = "Disconnect";

                        buddyPollThread = new Thread(() =>
                        {
                            while (true)
                            {
                                BindChatBuddyComboBox(txtHostIP.Text, txtPort.Text, user);
                                Thread.Sleep(5000);
                            }
                        });
                        _stopPollingHb = false;
                        buddyPollThread.IsBackground = true;
                        buddyPollThread.Start();
                    }
                    else
                    {
                        var message = _userConnect.DisconnectUser(txtHostIP.Text, txtPort.Text, user);
                        btnConnect.Text = "Connect";

                        cbxSelectChatBuddy.DataSource = null;
                        txtChattingWith.Text = string.Empty;
                        lblCurrentBuddyId.Text = string.Empty;

                        ShowMessage(Enums.NLogType.Info, message);
                        _stopPollingHb = true;
                        if (chatPollThread != null) chatPollThread.Join();
                    }
                }
                else
                {
                    ShowMessage(Enums.NLogType.Error, "One or more required fields are missing");
                }
            }
            catch(Exception ex)
            {
                ShowMessage(Enums.NLogType.Error, "Error occurred while trying to fetch users");
            }
        }

        /// <summary>
        /// Selects Chat buddy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectChatBuddy_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputsToConnect())
                {
                    var selectedUserId = cbxSelectChatBuddy.SelectedValue.ToString();
                    lblCurrentBuddyId.Text = selectedUserId;
                    txtChattingWith.Text = cbxSelectChatBuddy.Text;
                    lbChatWindow.Items.Clear();

                    chatPollThread = new Thread(() =>
                    {
                        while (!_stopPollingHb)
                        {
                            GetChat(txtHostIP.Text, txtPort.Text, selectedUserId, lblCurrentUserId.Text,
                                txtChattingWith.Text);
                        }
                    });
                    _stopPollingHb = false;
                    chatPollThread.IsBackground = true;
                    chatPollThread.Start();
                }
                else
                {
                    ShowMessage(Enums.NLogType.Error, "Required fields are empty.");
                }
            }
            catch (Exception)
            {
                ShowMessage(Enums.NLogType.Error, "Error occurred while trying to select Chat Buddy.");
            }
        }
        
        /// <summary>
        /// Sends chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtChattingWith.Text == string.Empty)
                {
                    ShowMessage(Enums.NLogType.Error, "Select a chat buddy to proceed.");
                    return;
                }
                var msg = new Models.Models.Message()
                {
                    MessageFrom = new User { UserId = lblCurrentUserId.Text, UserName = txtUsername.Text },
                    MessageTo = new User { UserId = lblCurrentBuddyId.Text, UserName = txtChattingWith.Text },
                    MessageText = txtMessage.Text,
                    MessageId = Guid.NewGuid().ToString(),
                    MessageTimeStamp = DateTime.Now
                };

                var boolString = SendChat(txtHostIP.Text, txtPort.Text, msg);
                if (boolString == "False")
                {
                    lbChatWindow.Items.Add(string.Format("[{0}]: {1} {2}",
                            DateTime.Now.ToString("M/d/yyyy hh:mm:ss"),
                            txtChattingWith.Text, " - is not connected anymore."));

                    cbxSelectChatBuddy.DataSource = null;
                    txtChattingWith.Text = string.Empty;
                    lblCurrentBuddyId.Text = string.Empty;
                }
                else
                {
                    lbChatWindow.Items.Add(string.Format("[{0}]: {1}>> {2}", DateTime.Now.ToString("M/d/yyyy hh:mm:ss"),
                                    txtUsername.Text, txtMessage.Text));
                    txtMessage.Text = string.Empty;
                }
            }
            catch
            {
                ShowMessage(Enums.NLogType.Error, "Error while trying to send the message. Please try again");
            }
        }
        
        /// <summary>
        /// Binds the Chat buddy list to the combo box
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        private void BindChatBuddyComboBox(string address, string port, User user)
        {
            try
            {
                var users = _userConnect.GetAllConnectedUsers(address, port, user.UserId);
                var cbxSource = new Dictionary<string, string>();
                users.ForEach(e =>
                {
                    cbxSource.Add(e.UserId, e.UserName);
                });

                if (cbxSource.Count > 0)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        cbxSelectChatBuddy.DataSource = new BindingSource(cbxSource, null);
                        cbxSelectChatBuddy.DisplayMember = "Value";
                        cbxSelectChatBuddy.ValueMember = "Key";
                    });
                }
            }
            catch{ }
        }

        /// <summary>
        /// Gets all the chat from to userId
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <param name="fromUsername"></param>
        private void GetChat(string address, string port, string fromUserId, string toUserId, string fromUsername)
        {
            try
            {
                var messages = _messaging.GetMessage(address, port, fromUserId, toUserId);
                if (messages.Count>0)
                {
                    Invoke((MethodInvoker) delegate
                    {
                        messages.ForEach(message =>
                        {
                            lbChatWindow.Items.Add(string.Format("[{0}]: {1}>> {2}",
                                DateTime.Now.ToString("M/d/yyyy hh:mm:ss"),
                                fromUsername, message));
                        });
                    });
                }
            }
            catch{}
        }

        /// <summary>
        /// Sends chat to server
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        private string SendChat(string address, string port, Models.Models.Message message)
        {
           return _messaging.SendMessage(address, port, message);
        }

        /// <summary>
        /// Return Validated inputs
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputsToConnect()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
                return false;
            if (string.IsNullOrEmpty(txtHostIP.Text))
                return false;
            if (string.IsNullOrEmpty(txtPort.Text))
                return false;
            return true;
        }

        /// <summary>
        /// Show Error
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        private void ShowMessage(Enums.NLogType mode, string message)
        {
            switch (mode)
            {
                case Enums.NLogType.Error:
                    lblError.Text = string.Format("Error: {0}", message);
                    lblError.ForeColor = System.Drawing.Color.Red;
                    break;
                case Enums.NLogType.Info:
                    lblError.Text = string.Format("Info: {0}", message);
                    lblError.ForeColor = System.Drawing.Color.Blue;
                    break;
                case Enums.NLogType.Warn:
                    lblError.Text = string.Format("Warning: {0}", message);
                    lblError.ForeColor = System.Drawing.Color.OrangeRed;
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
        }

        /// <summary>
        /// Event form closing disconnect users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidateInputsToConnect()) { Application.Exit(); return; }
            var user = new User()
            {
                UserId = lblCurrentUserId.Text,
                UserName = txtUsername.Text
            };
            var message = _userConnect.DisconnectUser(txtHostIP.Text, txtPort.Text, user);
            _stopPolling = true;
            _stopPollingHb = true;
            Application.Exit();
        }

        /// <summary>
        /// Text key down Enter to trigger click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                btnSend.PerformClick();
            }
        }

    }
}
