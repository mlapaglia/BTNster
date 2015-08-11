using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BTNster;
using Meebey.SmartIrc4net;

namespace BTNster.IRCBots
{
    public class Bot
    {
        #region Private Properties

        /// <summary>
        /// The thread responsible for listening to the IRC server, allows the rest of the bot to remain active
        /// </summary>
        private Thread listenThread;

        /// <summary>
        /// Used to tell the listen thread to stop listening
        /// </summary>
        private volatile bool IRCEnabled = true;

        /// <summary>
        /// Whether the UI is requesting the bot to disconnect
        /// </summary>
        private bool isDisconnectRequested = false;

        #endregion

        #region Protected Properties

        /// <summary>
        /// Abbreviation of the currently connected IRC server, used for debugging UI output
        /// </summary>
        protected string ircServerAbbreviation;

        /// <summary>
        /// The IRC client used to communicate with the server
        /// </summary>
        protected IrcClient irc;

        /// <summary>
        /// Lock file for the configuration and filters objects, ensuring both the bot and the parent UI thread
        /// call them safely
        /// </summary>
        protected readonly object _Locker;

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns whether the bot is connected or not
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (irc != null)
                {
                    return irc.IsConnected;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Constructor

        public Bot()
        {
            irc = new IrcClient();

            irc.SendDelay = 200;
            irc.AutoRetry = true;
            irc.ActiveChannelSyncing = false;

            irc.OnChannelMessage += irc_OnChannelMessage;
            irc.OnQueryMessage += irc_OnChannelMessage;
            irc.OnConnecting += irc_OnConnecting;
            irc.OnConnected += irc_OnConnected;
            irc.OnDisconnecting += irc_OnDisconnecting;
            irc.OnDisconnected += irc_OnDisconnected;
            irc.OnRegistered += irc_OnRegistered;
            irc.OnJoin += irc_OnJoin;
            irc.OnPart += irc_OnPart;
            irc.OnError += irc_OnError;
        }

        #endregion

        #region Abstract IRC Methods

        protected void irc_OnRegistered(object sender, EventArgs e)
        {
            irc.SendMessage(SendType.Message, "nickserv", String.Concat("IDENTIFY ", "password"));

            Thread.Sleep(2000);
            irc.RfcJoin("#whatbot");
        }

        #endregion

        #region Protected Events

        /// <summary>
        /// Handles errors sent from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnError(object sender, Meebey.SmartIrc4net.ErrorEventArgs e)
        {
        }

        /// <summary>
        /// Update the UI when we start connecting to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnConnecting(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Once we're connected, log in and LISTEN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnConnected(object sender, EventArgs e)
        {
            irc.Login("mlapaglia|test", "mlapaglia|test");

            //chill out here while the bot is running until we get the disconnect event

            listenThread = new Thread(new ThreadStart(IrcListenThread));
            listenThread.Start();
        }

        /// <summary>
        /// Handles the disconnecting starting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnDisconnecting(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        /// <summary>
        /// Handles being disconnected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnDisconnected(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// If we've received a message, check to see if it's the owner or the announce channel then parse accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnChannelMessage(object sender, IrcEventArgs e)
        {

        }

        /// <summary>
        /// Update the UI status strip once we are in the announce channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnJoin(object sender, JoinEventArgs e)
        {

        }

        /// <summary>
        /// Updates the UI status strip when we leave a channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void irc_OnPart(object sender, PartEventArgs e)
        {
           
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sends a message to a channel/user
        /// </summary>
        /// <param name="channel">channel/user to send message to</param>
        /// <param name="message">message text</param>
        private void SendMessage(string destination, string message)
        {
            irc.SendMessage(SendType.Message, destination, message);
        }

        /// <summary>
        /// The thread used for listening to IRC messages
        /// </summary>
        private void IrcListenThread()
        {
            while (IRCEnabled && irc.IsConnected)
            {
                irc.Listen();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Used to disconnect the bot from the IRC server
        /// </summary>
        /// <returns></returns>
        public void Disconnect()
        {
            try
            {
                if (irc.IsConnected)
                {
                    listenThread.Abort();
                    listenThread.Join();
                    irc.Disconnect();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Used to connect the bot to the IRC server
        /// </summary>
        /// <returns></returns>
        public void Connect()
        {
            irc.UseSsl = true;
            irc.Connect("irc.what-network.net", 6697);
        }

        #endregion
    }
}
