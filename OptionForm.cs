using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjRoboTech23
{
    public partial class OptionForm : Form
    {
        private void OptionForm_Load(object sender, EventArgs e)
        {
           // label2.Text = "this works";
            chkNSFW.Checked = Properties.Settings.Default.chkNSFW;
            chkReligious.Checked = Properties.Settings.Default.chkReligious;
            chkPolitical.Checked = Properties.Settings.Default.chkPolitical;
            chkRacist.Checked = Properties.Settings.Default.chkRacist;
            chkSexist.Checked = Properties.Settings.Default.chkSexist;
            chkExplicit.Checked = Properties.Settings.Default.chkExplicit;
        }
        public OptionForm()
        {
            this.Activated += new EventHandler(OptionForm_Activated);
            this.FormClosing += new FormClosingEventHandler(OptionForm_FormClosing);
            InitializeComponent();
        }
        private void OptionForm_Activated(object sender, EventArgs e)
        {
            // Perform actions when the form is activated
            // ...
            //label2.Text = "this works";
            chkNSFW.Checked = Properties.Settings.Default.chkNSFW;
            chkReligious.Checked = Properties.Settings.Default.chkReligious;
            chkPolitical.Checked = Properties.Settings.Default.chkPolitical;
            chkRacist.Checked = Properties.Settings.Default.chkRacist;
            chkSexist.Checked = Properties.Settings.Default.chkSexist;
            chkExplicit.Checked = Properties.Settings.Default.chkExplicit;
        }

        public bool ChkNSFW
        {
            get { return chkNSFW.Checked; }
            
           
        }
        public bool ChkReligious
        {
            get { return chkReligious.Checked; }

        }
        public bool ChkPolitical
        {
            get { return chkPolitical.Checked; }

        }
        public bool ChkRacist
        {
            get { return chkRacist.Checked; }

        }
        public bool ChkSexist
        {
            get { return chkSexist.Checked; }

        }
        public bool ChkExplicit
        {
            get { return chkExplicit.Checked; }

        }
        private void chkNSFW_CheckedChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
        private void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.chkNSFW = chkNSFW.Checked;
            Properties.Settings.Default.chkReligious = chkReligious.Checked;
            Properties.Settings.Default.chkPolitical = chkPolitical.Checked;
            Properties.Settings.Default.chkRacist = chkRacist.Checked;
            Properties.Settings.Default.chkSexist = chkSexist.Checked;
            Properties.Settings.Default.chkExplicit = chkExplicit.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
