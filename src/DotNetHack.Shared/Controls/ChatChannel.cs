using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Shared.Controls
{
    /// <summary>
    /// ChatChannel
    /// </summary>
    [ToolboxItem(true)]
    public partial class ChatChannel : UserControl
    {
        /// <summary>
        /// ChatChannel
        /// </summary>
        public ChatChannel(string channelName)
        {
            ChannelName = channelName;

            InitializeComponent();
        }

        /// <summary>
        /// ChannelName
        /// </summary>
        public string ChannelName { get; set; }
    }
}
