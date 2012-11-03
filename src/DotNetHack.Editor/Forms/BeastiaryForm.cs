using DotNetHack.Shared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor.Forms
{
    public partial class BeastiaryForm : Form
    {
        public BeastiaryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BeastiaryForm
        /// </summary>
        /// <param name="tileMapping"></param>
        public BeastiaryForm(TileMapping.MappedTile tileMapping)
        {

        }


    }
}
