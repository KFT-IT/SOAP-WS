using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WS_LOGIN_COMPRESSED.gp_view;
using System.Threading;

namespace WS_LOGIN_COMPRESSED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* WebService reference, v4, cookie container defined in app.config */
        gp_view.UnitOperativeSoapClient _serviceObj = new gp_view.UnitOperativeSoapClient();

        private void button1_Click(object sender, EventArgs e)
        {
            if (_serviceObj.Login("KK", "XXXX", "XXXX"))
                MessageBox.Show("login ok");
            else
                MessageBox.Show("error");

            _serviceObj.SetPreferredDatum(Datum.WGS84);

            Int16 minutes_shift = _serviceObj.GetShiftFromGMT();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // call this method only the first time; it contains a lot of data (config, admin data...) about units.
            // it is very bandwidth and time consuming
            //gpUnitPosition[] pos = _serviceObj.GetUnitsInfoAndPosition("");

            gpUnitPosition[] pos = _serviceObj.GetUnitsPosition("");
            MessageBox.Show(pos.Length.ToString() + " units found");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (true)
            {
                gpUnitPosition[] pos = _serviceObj.GetUnitsPosition("");

                //if (DataReceivedEvent)
                //    DataReceivedEvent(this, new EventArgs(pos));

                Thread.Sleep(60 * 1000);

            }
        }


    }
}