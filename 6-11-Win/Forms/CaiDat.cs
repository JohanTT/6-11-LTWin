using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _6_11_Win.Forms
{
    public partial class CaiDat : Form
    {
        public CaiDat()
        {
            InitializeComponent();
            ChinhNen();
        }

        private void CaiDat_Load_1(object sender, EventArgs s)
        {
            ChinhNen();
        }

        private void ChinhNen()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = MauNen.MauChinh;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = MauNen.MauPhu;

                }
            }
            label1.ForeColor = MauNen.MauChinh;
            //label2.ForeColor = MauNen.MauPhu;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
