using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        
        public MinesweeperForm()
        {
            InitializeComponent();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(new UserControl1());
            
        }

        
        private void MinesweeperForm_Paint(object sender, PaintEventArgs e)

        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Blue);
            p.Color = System.Drawing.Color.LightGray;
            p.Width = 8;
            g.DrawLine(p, new Point(2, 30), new Point(357, 30));

            Pen p0 = new Pen(Brushes.Blue);
            p0.Color = System.Drawing.Color.Gray;
            g.DrawLine(p0, new Point(2, 33), new Point(357, 33));

            Pen p00 = new Pen(Brushes.Blue);
            p00.Color = System.Drawing.Color.Gray;
            g.DrawLine(p00, new Point(2, 74), new Point(347, 74));

            Pen p1 = new Pen(Brushes.Blue);
            p1.Color = System.Drawing.Color.LightGray;
            p1.Width = 8;
            g.DrawLine(p1, new Point(6, 30), new Point(6, 402));

            Pen p11 = new Pen(Brushes.Blue);
            p11.Color = System.Drawing.Color.Gray;
            g.DrawLine(p11, new Point(9, 33), new Point(9, 402));

            Pen p2 = new Pen(Brushes.Blue);
            p2.Color = System.Drawing.Color.LightGray;
            p2.Width = 6;
            g.DrawLine(p2, new Point(2, 400), new Point(357, 400));

            Pen p3 = new Pen(Brushes.Blue);
            p3.Color = System.Drawing.Color.LightGray;
            p3.Width = 6;
            g.DrawLine(p3, new Point(354, 400), new Point(354, 30));

            Pen p4 = new Pen(Brushes.Blue);
            p4.Color = System.Drawing.Color.LightGray;
            p4.Width = 7;
            g.DrawLine(p4, new Point(2, 70), new Point(357, 70));

            Pen p5 = new Pen(Brushes.Blue);
            p5.Color = System.Drawing.Color.LightGray;
            p5.Width = 32;
            g.DrawLine(p5, new Point(10, 50), new Point(350, 50));

            

            this.pictureBox1.Image = ImageUtil.startFaceImage;
           
            this.pictureBox2.Image = ImageUtil.timeImage4;
            this.pictureBox3.Image = ImageUtil.timeImage0;

            this.pictureBox4.Image = ImageUtil.timeImage0;
            this.pictureBox5.Image = ImageUtil.timeImage0;
            this.pictureBox6.Image = ImageUtil.timeImage0;
            this.pictureBox7.Image = ImageUtil.timeImage0;

            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = ImageUtil.pressFaceImage;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = ImageUtil.startFaceImage;
        }



        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pb_Click(object sender, EventArgs e)
        {
            //(sender as PictureBox).Image = 
        }
    }
}
