using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Saba
{
    public partial class FormPlaySetting : Form
    {
        public int repeatNum = 1;
        public int NumOfAyeh = 1;
        public int SelectedAyeh = 0;

        public FormPlaySetting()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            repeatNum = Convert.ToInt32(comboBox1.Text);
            SelectedAyeh = comboBox_SatrtAyeh.SelectedIndex;
            Close();
        }

        private void FormPlaySetting_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public void setCombo()
        {
            comboBox_SatrtAyeh.Items.Add("ابتدا");
            for (int i = 1; i <= NumOfAyeh; i++)
            {
                comboBox_SatrtAyeh.Items.Add(i);
            }
            comboBox_SatrtAyeh.SelectedIndex = 0;
        }


    }
}
