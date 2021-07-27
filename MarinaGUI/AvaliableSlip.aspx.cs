﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarinaGUI
{
    public partial class AvaliableSlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DockSelector.DockSelect += DockSelector_DockSelect; // subscribe to the event
        }

        // method to handle the event CourseSelect
        private void DockSelector_DockSelect(object sender, Controls.DockEventArgs e)
        {
            lstSlips.DataSource = e.SlipID;
        }
    }
}