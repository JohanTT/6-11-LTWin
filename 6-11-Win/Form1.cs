using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_11_Win
{
    public partial class Form1 : Form
    {
        //Fields
        private Button currentButton;
        //private Random random;
        //private int tmpIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            //random = new Random();
            button1.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color ChonMauNen(int i) // Chọn màu cho mỗi cái chủ đề, Mỗi chủ đề chỉ được chọn 1
        {
            /*
            int i = random.Next(MauNen.DSMau.Count);
            while (tmpIndex == i)
            {
                i = random.Next(MauNen.DSMau.Count);
            }
            tmpIndex = i;
            */
            string color = MauNen.DSMau[i]; // Chọn màu cụ thể thay vì cho ngẫu nhiên và có tổng cộng là tận 28 màu
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender, int i) // Làm nổi các nút và thay đổi màu khi được chọn
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ChonMauNen(i);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point); // Làm cho chữ to lên khi chọn
                    panelTitleBar.BackColor = color;
                    panel2.BackColor = MauNen.ChangeColorBrightness(color, -0.3);
                    label1.BackColor = MauNen.ChangeColorBrightness(color, -0.3);
                    MauNen.MauChinh = color;
                    MauNen.MauPhu = MauNen.ChangeColorBrightness(color, -0.3);
                    button1.Visible = true;
                }
            }
        }

        private void DisableButton() // Khi không chọn thì chữ sẽ không còn nổi lên nữa
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromName("DarkTurquoise");
                    previousBtn.ForeColor = Color.FromArgb(255, 255, 192);
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point); // Làm cho chữ to lên khi chọn

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender, int i) // Dùng để mở các Form con mỗi khi chọn các nút
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender, i);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // chỉnh màu Giỏ hàng là 1
        {
            OpenChildForm(new Forms.GioHang(), sender, 1); // Cho Màu mỗi cái khác nhau thay đổi bởi số int i
            //ActivateButton(sender);
        }

        private void button2_Click(object sender, EventArgs e) // Chỉnh màu của ký gửi là 2
        {
            OpenChildForm(new Forms.KyGui(), sender, 2);
            //ActivateButton(sender);
        }

        private void button3_Click(object sender, EventArgs e) // Chỉnh màu của sản phẩm là 3
        {
            OpenChildForm(new Forms.SanPham(), sender, 3);
            //ActivateButton(sender);
        }

        private void button4_Click(object sender, EventArgs e) // chỉnh màu của tài khoản là 4
        {
            OpenChildForm(new Forms.TaiKhoan(), sender, 4);
            //ActivateButton(sender);
        }

        private void button5_Click(object sender, EventArgs e) // chỉnh màu của cài đặt là 5
        {
            OpenChildForm(new Forms.CaiDat(), sender, 5);
            //ActivateButton(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "TRANG CHỦ";
            panelTitleBar.BackColor = Color.FromName("MenuHighlight");
            panel2.BackColor = Color.FromName("Navy");
            label1.BackColor = Color.FromName("Navy");
            currentButton = null;
            button1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button6_Click(object sender, EventArgs e) // thay cho dấu x để thoát ra khỏi chương trình
        {
            Application.Exit();
        } 

        private void button7_Click(object sender, EventArgs e) // Phóng to full màn hình
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void button8_Click(object sender, EventArgs e) // Thu nhỏ màn hình
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }        
}