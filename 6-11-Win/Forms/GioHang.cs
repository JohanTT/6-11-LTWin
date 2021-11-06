using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _6_11_Win.Forms
{
    public partial class GioHang : Form
    {
        public GioHang()
        {
            InitializeComponent();
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

        private void GioHang_Load(object sender, EventArgs e)
        {
            ChinhNen();
        }
    }
}
