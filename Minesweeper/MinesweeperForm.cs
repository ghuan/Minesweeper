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
    public partial class MinesweeperForm : Form,UserSetObserver
    {
        
        public MinesweeperForm()
        {
            InitializeComponent();
            timer.Interval = 1000D;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timerCount);

        }
        private void timerCount(object sender, EventArgs e)
        {
            //timer.Stop();
            this.gameTime++;
            string times = this.gameTime + "";

            if (times.Length == 1)
            {
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
            char[] ts = times.ToCharArray();
            this.secondThousandBox.Image = ImageUtil.getTimeImage(int.Parse(ts[0] + ""));
            this.secondHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ts[1] + ""));
            this.secondTenBox.Image = ImageUtil.getTimeImage(int.Parse(ts[2] + ""));
            this.secondOneBox.Image = ImageUtil.getTimeImage(int.Parse(ts[3] + ""));

        }
        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            this.faceBox.Image = ImageUtil.startFaceImage;
            this.setBox.Image = ImageUtil.defaultSetImage;

            this.builder.mineCount();
            this.secondHundredBox.Image = ImageUtil.timeImage0;
            this.secondThousandBox.Image = ImageUtil.timeImage0;
            this.secondOneBox.Image = ImageUtil.timeImage0;
            this.secondTenBox.Image = ImageUtil.timeImage0;

            try {
                //读取配置文件
                Dictionary<String, String> minesSysSet = OperateIniFile.ReadIniDataAll(this.defaultSetIniFileSection, AppDomain.CurrentDomain.BaseDirectory + "\\" + this.setFileName);
                this.minesSet.set(minesSysSet);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
           
        }

        /**
         * form边框 画线
         * **/
        private void MinesweeperForm_Paint(object sender, PaintEventArgs e)

        {
            e.Graphics.Clear(Color.White);
            int widthOther = 17;
            int heightOther = 56;
            int width = this.minesSet.XCount * 20;
            int height = this.minesSet.YCount * 20;
            
            Graphics g = this.CreateGraphics();
            
            Pen p = new Pen(Brushes.Blue);
            p.Color = System.Drawing.Color.LightGray;
            p.Width = 8;
            g.DrawLine(p, new Point(2,5), new Point(width+widthOther, 5));

            Pen p0 = new Pen(Brushes.Blue);
            p0.Color = System.Drawing.Color.Gray;
            g.DrawLine(p0, new Point(2, 8), new Point(width + widthOther, 8));

            Pen p00 = new Pen(Brushes.Blue);
            p00.Color = System.Drawing.Color.Gray;
            g.DrawLine(p00, new Point(2, 49), new Point(width + widthOther-7, 49));

            Pen p1 = new Pen(Brushes.Blue);
            p1.Color = System.Drawing.Color.LightGray;
            p1.Width = 8;
            g.DrawLine(p1, new Point(6, 5), new Point(6, height+heightOther));

            Pen p11 = new Pen(Brushes.Blue);
            p11.Color = System.Drawing.Color.Gray;
            g.DrawLine(p11, new Point(9, 8), new Point(9, height + heightOther+1));

            Pen p2 = new Pen(Brushes.Blue);
            p2.Color = System.Drawing.Color.LightGray;
            p2.Width = 6;
            g.DrawLine(p2, new Point(2, height + heightOther-2), new Point(width + widthOther, height + heightOther-2));

            Pen p3 = new Pen(Brushes.Blue);
            p3.Color = System.Drawing.Color.LightGray;
            p3.Width = 6;
            g.DrawLine(p3, new Point(width + widthOther-3, height + heightOther-2), new Point(width + widthOther-3, 5));

            Pen p4 = new Pen(Brushes.Blue);
            p4.Color = System.Drawing.Color.LightGray;
            p4.Width = 7;
            g.DrawLine(p4, new Point(2, 45), new Point(width + widthOther, 45));

            Pen p5 = new Pen(Brushes.Blue);
            p5.Color = System.Drawing.Color.LightGray;
            p5.Width = 32;
            g.DrawLine(p5, new Point(10, 25), new Point(width + widthOther-7, 25));

        }

        /**
         * 根据minesSet动态布局棋盘
         * **/
        public void updateLayout() {
            int widthOther = 17;
            int heightOther = 58;
            int totalMinesMap = this.minesSet.XCount * this.minesSet.YCount;
            this.currentTotalMines = this.minesSet.TotalMines;
            this.initTotalMines = this.currentTotalMines;
            this.initMinesMap = new int[totalMinesMap];
            this.faceBox.Location = new System.Drawing.Point(((widthOther + this.minesSet.XCount * 20) - 80) / 2, 12);
            this.setBox.Location = new System.Drawing.Point(this.faceBox.Location.X+36, 12);
            this.secondOneBox.Location = new System.Drawing.Point(((widthOther + this.minesSet.XCount * 20) - 30), 13);
            this.secondTenBox.Location = new System.Drawing.Point(this.secondOneBox.Location.X - 13, 13);
            this.secondHundredBox.Location = new System.Drawing.Point(this.secondTenBox.Location.X - 13, 13);
            this.secondThousandBox.Location = new System.Drawing.Point(this.secondHundredBox.Location.X - 13, 13);
            this.ClientSize = new System.Drawing.Size(widthOther + this.minesSet.XCount * 20, heightOther + this.minesSet.YCount*20);
            if (totalMinesMap > 0) {
                foreach (KeyValuePair<int, PictureBox> kvp in minesDict) {
                    kvp.Value.Dispose();
                }
                this.minesDict.Clear();
            }
            for (int i = 0; i < totalMinesMap; i++)
            {
                this.minesDict.Add(i, new System.Windows.Forms.PictureBox());
            }
            int f = 0;
            int n = 0;
            int m = 0;
            foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
            {
                n++;

                ((System.ComponentModel.ISupportInitialize)(kvp.Value)).BeginInit();
                // 
                // pb
                // 

                kvp.Value.Image = ((System.Drawing.Image)(ImageUtil.mineImage));
                kvp.Value.Location = new System.Drawing.Point(10 + f, 50 + m);
                kvp.Value.Size = new System.Drawing.Size(20, 20);
                kvp.Value.Name = "" + n;
                kvp.Value.TabStop = false;
                this.mouseEventInvoker.bindCommand(kvp.Value, MouseUpDown.DOWN, MouseButtons.Left, new MineBoxMouseLeftDownCommand(this, kvp.Value));
                this.mouseEventInvoker.bindCommand(kvp.Value, MouseUpDown.UP, MouseButtons.Left, new MineBoxMouseLeftUpCommand(this, kvp.Value));
                this.mouseEventInvoker.bindCommand(kvp.Value, MouseUpDown.DOWN, MouseButtons.Middle, new MineBoxMouseMidDownCommand(this, kvp.Value));
                this.mouseEventInvoker.bindCommand(kvp.Value, MouseUpDown.UP, MouseButtons.Middle, new MineBoxMouseMidUpCommand(this, kvp.Value));
                this.mouseEventInvoker.bindCommand(kvp.Value, MouseUpDown.UP, MouseButtons.Right, new MineBoxMouseRightUpCommand(this, kvp.Value));
                kvp.Value.MouseDown += this.mouseEventInvoker.callMouseDownEvent;
                kvp.Value.MouseUp += this.mouseEventInvoker.callMouseUpEvent;
                this.Controls.Add(kvp.Value);
                ((System.ComponentModel.ISupportInitialize)(kvp.Value)).EndInit();
                f = f + 20;
                if (n % this.minesSet.XCount == 0)
                {
                    f = 0;
                    m = m + 20;
                }
            }
            this.builder.resetGame();
        }

        /**
         * 观察者模式，用户设置更新，动态改变布局
         * **/
        public void update()
        {
            this.updateLayout();
        }
    }
}
