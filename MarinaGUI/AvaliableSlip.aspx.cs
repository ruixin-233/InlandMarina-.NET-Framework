﻿using MarinaData;
using System;
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
            DockSelector.DDL_Dock_Control.Load += new EventHandler(InitSlipDataByDock_UserControl_Clicked);//页面初始化加载dock时的绑定事件
            DockSelector.DockSelect += DockSelector_DockSelect; // subscribe to the event
     
        }

        /// <summary>
        /// 页面初始化加载dock时，根据第一个dock值显示slip
        /// </summary>
        private void InitSlipDataByDock_UserControl_Clicked(object sender, System.EventArgs e)
        {
            string dockID = DockSelector.DDL_Dock_Control.SelectedValue;
            if (!string.IsNullOrEmpty(dockID))
            {
                List<Slip> list = SlipManager.AvailableSlip(int.Parse(dockID));
                showListBoxItem(list);
            }
        }

        // method to handle the event CourseSelect
        private void DockSelector_DockSelect(object sender, Controls.DockEventArgs e)
        {
            //lstSlips.DataSource = e.SlipID;

            List<Slip> list = e.SlipID;
            showListBoxItem(list);

        }

        private void showListBoxItem(List<Slip> list)
        {
            lstSlips.Items.Clear();
            foreach (var slip in list)
            {
                lstSlips.Items.Add(slip.ID.ToString());
            }
        }
    }
}