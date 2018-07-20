using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WS_LOGIN_COMPRESSED_WEBREF.gp_view;

namespace WS_LOGIN_COMPRESSED_WEBREF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        gp_view.UnitOperative t = new gp_view.UnitOperative();
        private void button1_Click(object sender, EventArgs e)
        {
            t.CookieContainer = new System.Net.CookieContainer();
            t.EnableDecompression = true;

            if (t.Login("KK", "XXXX", "XXXX"))
                MessageBox.Show("login ok");
            else
                MessageBox.Show("error");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gpUnitPosition[] pos = t.GetUnitsPosition("");
            MessageBox.Show(pos.Length.ToString() + " units found");

        }

        private void button3_Click(object sender, EventArgs e)
        {

            HistoryFile file = t.GetHistoryFileForUnitSingle("CODE", new DateTime(2013, 10, 4), HistoryFileType.STO, 0);
            MessageBox.Show(file.fileContent.Length + " bytes");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cMission_places_service[] pl = t.GetAllPlaces();
            MessageBox.Show(pl.Length + " places");

        }
    }
}
