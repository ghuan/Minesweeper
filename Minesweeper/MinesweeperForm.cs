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
        System.Timers.Timer timer = new System.Timers.Timer();
        public MinesweeperForm()
        {
            InitializeComponent();
            timer.Interval = 1000D;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timerCount);

        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            this.faceBox.Image = ImageUtil.startFaceImage;
            this.setBox.Image = ImageUtil.defaultSetImage;

            //this.mineNumOneBox.Image = ImageUtil.timeImage1;
            //this.mineNumTenBox.Image = ImageUtil.timeImage5;
            //this.mineNumHundredBox.Image = ImageUtil.timeImage0;
            mineCount();
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

        private void faceBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.faceBox.Image = ImageUtil.pressFaceImage;
        }

        private void faceBox_MouseUp(object sender, MouseEventArgs e)
        {
            resetGame();
        }
        private void setBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.setBox.Image = ImageUtil.pressSetImage;
        }

        private void setBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.setBox.Image = ImageUtil.defaultSetImage;
            if (this.userSetForm == null) {
                this.userSetForm = new UserSetForm();
                this.userSetForm.minesweeperForm = this;
            }
            this.userSetForm.StartPosition = this.StartPosition;
            this.userSetForm.ShowDialog();
        }


        /**
         * 雷区鼠标按下事件 
         **/
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (this.gameState != 2 && (sender as PictureBox).Image == ImageUtil.mineImage)
                {
                    (sender as PictureBox).Image = ImageUtil.mineDownImage;
                    this.faceBox.Image = ImageUtil.frontFaceImage;
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if ((sender as PictureBox).Image != ImageUtil.mineImage && (sender as PictureBox).Image != ImageUtil.mineQImage && (sender as PictureBox).Image != ImageUtil.mineTagImage && (sender as PictureBox).Image != ImageUtil.mineDownImage)
                {
                    int thisMines = ImageUtil.getMineCount((sender as PictureBox).Image);
                    int mine = int.Parse((sender as PictureBox).Name);
                    if (thisMines != 0)
                    {
                        int[] aroundMines = MinesUtil.getAroundMines(mine,this.minesSet.XCount);
                        dictTmp = new Dictionary<int, Image>();
                        foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                        {
                            foreach (int b in aroundMines)
                            {
                                if (kvp.Value.Name.Equals(b + ""))
                                {
                                    if (kvp.Value.Image == ImageUtil.mineImage || kvp.Value.Image == ImageUtil.mineQImage)
                                    {
                                        dictTmp.Add(b, kvp.Value.Image);
                                        kvp.Value.Image = ImageUtil.mineDownImage;
                                    }
                                   
                                }
                            }
                        }
                    }
                }
            }

        }

        /**
         * 雷区鼠标松开事件 
         **/
        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Right)
            {
                if (this.gameState == 1)
                {
                    if ((sender as PictureBox).Image == ImageUtil.mineImage) {
                        (sender as PictureBox).Image = ImageUtil.mineTagImage;
                        this.currentTotalMines--;
                    }
                    else if ((sender as PictureBox).Image == ImageUtil.mineTagImage)
                    {
                        (sender as PictureBox).Image = ImageUtil.mineQImage;
                        this.currentTotalMines++;
                    }
                    else if ((sender as PictureBox).Image == ImageUtil.mineQImage)
                    {
                        (sender as PictureBox).Image = ImageUtil.mineImage;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            
            {
                int minenum = int.Parse((sender as PictureBox).Name);
                if (this.gameState == 0)
                {//开始游戏，随机分配地雷
                    this.gameState = 1;
                    this.gameTime = 0;

                    this.initMines = MinesUtil.getRandomMines(this.initTotalMines, this.initMinesMap.Length, minenum);//随机分配地雷
                    timer.Start();
                    //(sender as PictureBox).Image = ImageUtil.mineDownImage;
                    this.faceBox.Image = ImageUtil.startFaceImage;
                    checkMine(sender);
                }
                else if (this.gameState == 1 && (sender as PictureBox).Image == ImageUtil.mineDownImage)
                {
                    bool ismine = false;
                    foreach (int m in this.initMines)
                    {
                        if (minenum == m)
                        {
                            ismine = true;
                        }

                    }
                    if (ismine)
                    {
                        this.faceBox.Image = ImageUtil.failFaceImage;
                        (sender as PictureBox).Image = ImageUtil.minImage;
                        foreach (int m in this.initMines)
                        {
                            if (minenum != m)
                            {
                                foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                                {
                                    if (kvp.Value.Image == ImageUtil.mineTagImage)
                                    {
                                        bool sfmine = false;
                                        foreach (int mn in this.initMines) {
                                            if (kvp.Value.Name.Equals("" + mn)) {
                                                sfmine = true;
                                                break;
                                            }
                                        }
                                        if (!sfmine) {
                                            kvp.Value.Image = ImageUtil.minImage2;
                                        }
                                    }
                                    else {
                                        if (kvp.Value.Name.Equals(m + ""))
                                        {
                                            kvp.Value.Image = ImageUtil.minImage1;

                                        }
                                    }
                                    
                                }
                            }


                        }
                        timer.Stop();
                        this.gameState = 2;

                    }
                    else
                    {
                        (sender as PictureBox).Image = ImageUtil.mineDownImage;
                        this.faceBox.Image = ImageUtil.startFaceImage;
                        checkMine(sender);
                        if (checkSuccess()) {
                            this.faceBox.Image = ImageUtil.successFaceImage;
                            timer.Stop();
                            this.gameState = 2;
                            MessageBox.Show("恭喜您，通关成功！");
                        }
                    }
                }
                else
                {

                }
            }else if (e.Button == MouseButtons.Middle)
            {
                if ((sender as PictureBox).Image != ImageUtil.mineImage && (sender as PictureBox).Image != ImageUtil.mineQImage && (sender as PictureBox).Image != ImageUtil.mineTagImage && (sender as PictureBox).Image != ImageUtil.mineDownImage) {
                    int thisMines = ImageUtil.getMineCount((sender as PictureBox).Image);
                    int mine = int.Parse((sender as PictureBox).Name);
                    if (thisMines != 0) {
                        int[] aroundMines = MinesUtil.getAroundMines(mine,this.minesSet.XCount);
                        foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                        {
                            foreach (KeyValuePair<int, Image> kvp1 in dictTmp) {
                                if (kvp.Value.Name.Equals(""+kvp1.Key)) {
                                    kvp.Value.Image = kvp1.Value;
                                }
                            }
                            

                        }
                        int count = 0;
                        int num = 0;
                        Dictionary<int, PictureBox> dict1 = new Dictionary<int, PictureBox>();
                        foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                        {
                            foreach (int b in aroundMines) {
                                if (kvp.Value.Name.Equals(b + ""))
                                {
                                    num++;
                                    
                                    if (kvp.Value.Image == ImageUtil.mineTagImage)
                                    {
                                        count++;
                                    }
                                    else {
                                        dict1.Add(num, kvp.Value);
                                    }
                                }
                            }
                        }
                        if (count == thisMines) {

                            foreach (KeyValuePair<int, PictureBox> kvp in dict1) {
                                if (kvp.Value.Image == ImageUtil.mineImage) {
                                    copy_pbClick(kvp.Value);
                                }
                                
                            }
                        }
                    }
                }
            }
            mineCount();

        }

        private void copy_pbClick(PictureBox picture) {

            int minenum = int.Parse(picture.Name);

            bool ismine = false;
            foreach (int a in this.initMines)
            {
                if (minenum == a)
                {
                    ismine = true;
                }

            }
            if (ismine)
            {
                this.faceBox.Image = ImageUtil.failFaceImage;
                picture.Image = ImageUtil.minImage;
                foreach (int a in this.initMines)
                {
                    if (minenum != a)
                    {
                        foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                        {
                            if (kvp.Value.Image == ImageUtil.mineTagImage)
                            {
                                bool sfmine = false;
                                foreach (int aa in this.initMines)
                                {
                                    if (kvp.Value.Name.Equals("" + aa))
                                    {
                                        sfmine = true;
                                        break;
                                    }
                                }
                                if (!sfmine)
                                {
                                    kvp.Value.Image = ImageUtil.minImage2;
                                }
                            }
                            else
                            {
                                if (kvp.Value.Name.Equals(a + ""))
                                {
                                    kvp.Value.Image = ImageUtil.minImage1;

                                }
                            }
                        }
                    }


                }
                timer.Stop();
                this.gameState = 2;

            }
            else
            {
                picture.Image = ImageUtil.mineDownImage;
                this.faceBox.Image = ImageUtil.startFaceImage;
                checkMine(picture);
                if (checkSuccess())
                {
                    this.faceBox.Image = ImageUtil.successFaceImage;
                   
                    timer.Stop();
                    this.gameState = 2;
                    MessageBox.Show("恭喜您，通关成功！");
                }
            }
        }
        private bool checkSuccess() {
            int tag = 0;
            foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
            {
                if (kvp.Value.Image == ImageUtil.mineImage || kvp.Value.Image == ImageUtil.mineTagImage || kvp.Value.Image == ImageUtil.mineQImage) {
                    tag++;
                }
            }
            if (tag == this.initTotalMines)
            {
                return true;
            }
            else {
                return false;
            }
        }
        private void checkMine(object sender) {
            try {
                int mine = int.Parse((sender as PictureBox).Name);
                int countmines = 0;//周围雷数
                int[] aroundMines = MinesUtil.getAroundMines(mine,this.minesSet.XCount);
                
                foreach (int a in this.initMines)
                {
                    foreach (int b in aroundMines)
                    {
                        if (a == b)
                        {
                            countmines++;
                        }
                    }
                }
                if (countmines != 0)
                {//设置周围雷数
                    (sender as PictureBox).Image = ImageUtil.getMineCountImage(countmines);

                }
                else
                {
                    (sender as PictureBox).Image = ImageUtil.mineDownImage;
                    foreach (int emine in aroundMines)
                    {
                        if (emine != mine && emine != 0)
                        {
                            foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
                            {
                                if (kvp.Value.Name.Equals(emine + "") && kvp.Value.Image == ImageUtil.mineImage)
                                {
                                    checkMine(kvp.Value);
                                }
                            }

                        }

                    }
                }
            } catch (Exception e){
                MessageBox.Show(e.Message);
            }
            
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
            char[] ts = times.ToCharArray();
            this.secondThousandBox.Image = ImageUtil.getTimeImage(int.Parse(ts[0] + ""));
            this.secondHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ts[1] + ""));
            this.secondTenBox.Image = ImageUtil.getTimeImage(int.Parse(ts[2] + ""));
            this.secondOneBox.Image = ImageUtil.getTimeImage(int.Parse(ts[3] + ""));
           
        }

        private void mineCount()
        {
            //timer.Stop();
            
            
            if (this.currentTotalMines < 0)
            {
                string mines = -this.currentTotalMines + "";
                if (mines.Length == 1)
                {
                    mines = "0" + mines;
                }
                
                char[] ms = mines.ToCharArray();
                this.mineNumOneBox.Image = ImageUtil.timeImageF;
                this.mineNumTenBox.Image = ImageUtil.getTimeImage(int.Parse(ms[0] + ""));
                this.mineNumHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ms[1] + ""));
            }
            else {
                string mines = this.currentTotalMines + "";
                if (mines.Length == 1)
                {
                    mines = "00" + mines;
                }
                if (mines.Length == 2)
                {
                    mines = "0" + mines;
                }
                char[] ms = mines.ToCharArray();
                this.mineNumOneBox.Image = ImageUtil.getTimeImage(int.Parse(ms[0] + ""));
                this.mineNumTenBox.Image = ImageUtil.getTimeImage(int.Parse(ms[1] + ""));
                this.mineNumHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ms[2] + ""));
            }
        }
       
        /**
         * 重置游戏
         **/
        public void resetGame() {
            this.faceBox.Image = ImageUtil.startFaceImage;
            this.secondThousandBox.Image = ImageUtil.timeImage0;
            this.secondHundredBox.Image = ImageUtil.timeImage0;
            this.secondTenBox.Image = ImageUtil.timeImage0;
            this.secondOneBox.Image = ImageUtil.timeImage0;
            foreach (KeyValuePair<int, PictureBox> kvp in minesDict)
            {
                kvp.Value.Image = ((System.Drawing.Image)(ImageUtil.mineImage));
            }
            this.gameState = 0;
            this.currentTotalMines = this.minesSet.TotalMines;
            this.gameTime = 0;
            mineCount();
            timer.Stop();
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
                kvp.Value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
                kvp.Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);
                this.Controls.Add(kvp.Value);
                ((System.ComponentModel.ISupportInitialize)(kvp.Value)).EndInit();
                f = f + 20;
                if (n % this.minesSet.XCount == 0)
                {
                    f = 0;
                    m = m + 20;
                }
            }
            this.resetGame();
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
