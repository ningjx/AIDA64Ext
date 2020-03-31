using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIDAFormsControlLibrary
{
    public partial class Instrument1 : BaseControl
    {
        public Instrument1()
        {
            //InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);
        }

    }
}
