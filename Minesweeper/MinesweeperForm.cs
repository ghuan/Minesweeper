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
        System.Timers.Timer timer = new System.Timers.Timer();
        int[] mines = new int[150];
        public MinesweeperForm()
        {
            InitializeComponent();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
          
            
        }

        
        private void MinesweeperForm_Paint(object sender, PaintEventArgs e)

        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Blue);
            p.Color = System.Drawing.Color.LightGray;
            p.Width = 8;
            g.DrawLine(p, new Point(2,5), new Point(537, 5));

            Pen p0 = new Pen(Brushes.Blue);
            p0.Color = System.Drawing.Color.Gray;
            g.DrawLine(p0, new Point(2, 8), new Point(537, 8));

            Pen p00 = new Pen(Brushes.Blue);
            p00.Color = System.Drawing.Color.Gray;
            g.DrawLine(p00, new Point(2, 49), new Point(530, 49));

            Pen p1 = new Pen(Brushes.Blue);
            p1.Color = System.Drawing.Color.LightGray;
            p1.Width = 8;
            g.DrawLine(p1, new Point(6, 5), new Point(6, 456));

            Pen p11 = new Pen(Brushes.Blue);
            p11.Color = System.Drawing.Color.Gray;
            g.DrawLine(p11, new Point(9, 8), new Point(9, 457));

            Pen p2 = new Pen(Brushes.Blue);
            p2.Color = System.Drawing.Color.LightGray;
            p2.Width = 6;
            g.DrawLine(p2, new Point(2, 454), new Point(537, 454));

            Pen p3 = new Pen(Brushes.Blue);
            p3.Color = System.Drawing.Color.LightGray;
            p3.Width = 6;
            g.DrawLine(p3, new Point(534, 454), new Point(534, 5));

            Pen p4 = new Pen(Brushes.Blue);
            p4.Color = System.Drawing.Color.LightGray;
            p4.Width = 7;
            g.DrawLine(p4, new Point(2, 45), new Point(537, 45));

            Pen p5 = new Pen(Brushes.Blue);
            p5.Color = System.Drawing.Color.LightGray;
            p5.Width = 32;
            g.DrawLine(p5, new Point(10, 25), new Point(530, 25));

            

            this.pictureBox1.Image = ImageUtil.startFaceImage;
           
            this.pictureBox2.Image = ImageUtil.timeImage1;
            this.pictureBox3.Image = ImageUtil.timeImage5;
            this.pictureBox33.Image = ImageUtil.timeImage0;
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
            resetGame();
            timer.Stop();
            this.gameTime = 0;
            this.pictureBox5.Image = ImageUtil.timeImage0;
            this.pictureBox4.Image = ImageUtil.timeImage0;
            this.pictureBox7.Image = ImageUtil.timeImage0;
            this.pictureBox6.Image = ImageUtil.timeImage0;
            

        }



        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as PictureBox).Image = ImageUtil.mineDownImage;
            this.pictureBox1.Image = ImageUtil.frontFaceImage;
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show((sender as PictureBox).Name);
            (sender as PictureBox).Image = ImageUtil.mineImage;
            int minenum = int.Parse((sender as PictureBox).Name);
            if (this.gameState == 0)
            {//开始游戏，随机分配地雷
                this.gameState = 1;
                this.gameTime = 0;
                
                mines = getRandomNum(150, 1, 520, minenum);//从520个地雷区里随机分配150个真实地雷
                                                           // foreach (int a in mines) { ImageUtil.writeLog(a+""); }

                timer.Interval = 1000D;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timerCount);
                timer.Start();
                (sender as PictureBox).Image = ImageUtil.mineDownImage;
            }
            else {
                bool ismine = false;
                foreach (int a in mines) {
                    if (minenum == a)
                    {
                        ismine = true;
                    }
                    
                }
                if (ismine)
                {
                    (sender as PictureBox).Image = ImageUtil.minImage;
                    foreach (int a in mines)
                    {
                        if (minenum != a) {
                            foreach (KeyValuePair<int, PictureBox> kvp in dict)
                            {
                                if (kvp.Value.Name.Equals(a + "")) {
                                    kvp.Value.Image = ImageUtil.minImage1;
                                }
                            }
                        }
                        

                    }

                }
                else {
                    (sender as PictureBox).Image = ImageUtil.mineDownImage;
                }
            }
            this.pictureBox1.Image = ImageUtil.startFaceImage;
        }

        private void timerCount(object sender, EventArgs e) {
            //timer.Stop();
            this.gameTime++;
            string times = this.gameTime + "";

            if (times.Length == 1) {
                times = "000" + times;
            }
            if (times.Length == 2)
            {
                times = "00" + times;
            }
            if (times.Length == 3)
            {
                times = "0" + times;
            }
            char[] aa = times.ToCharArray();
            this.pictureBox5.Image = ImageUtil.getTimeImage(int.Parse(aa[0] + ""));
            this.pictureBox4.Image = ImageUtil.getTimeImage(int.Parse(aa[1] + ""));
            this.pictureBox7.Image = ImageUtil.getTimeImage(int.Parse(aa[2] + ""));
            this.pictureBox6.Image = ImageUtil.getTimeImage(int.Parse(aa[3] + ""));
           
        }
        public int[] getRandomNum(int num, int minValue, int maxValue,int num1)
        {
            if ((maxValue + 1 - minValue - num < 0))
                maxValue += num - (maxValue + 1 - minValue);
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[num];
            int tmp = 0;
            StringBuilder sb = new StringBuilder(num * maxValue.ToString().Trim().Length);

            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue);
                while (sb.ToString().Contains("#" + tmp.ToString().Trim() + "#") && !(tmp.ToString().Trim().Equals(num1+"")))
                    tmp = ra.Next(minValue, maxValue + 1);
                arrNum[i] = tmp;
                sb.Append("#" + tmp.ToString().Trim() + "#");
            }
            return arrNum;
        }
        private void resetGame() {
            foreach (KeyValuePair<int, PictureBox> kvp in dict)
            {

                kvp.Value.Image = ((System.Drawing.Image)(ImageUtil.mineImage));
               
            }
            this.gameState = 0;
        }
    }
}
