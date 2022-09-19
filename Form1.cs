using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen myPen;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("15");
            comboBox1.SelectedIndex = 1;

            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            myPen = new Pen(Color.Black, 5);
            myPen.StartCap = myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox myPictureBox = (PictureBox)sender;
            myPen.Color = myPictureBox.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!=-1 && y != -1)
            {
                //set the new width of the pen if the user change it
                string selectedItem = comboBox1.SelectedItem.ToString();
                int selectedItemValue = int.Parse(selectedItem);
                myPen.Width = selectedItemValue;

                g.DrawLine(myPen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }
      
    }
}
