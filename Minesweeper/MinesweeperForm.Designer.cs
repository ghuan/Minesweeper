using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class MinesweeperForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperForm));
            this.builder = new MinesweeperBuilder(this);

            this.minesSet = new MinesSet();
            this.minesSet.addObserver(this);
            this.faceBox = new System.Windows.Forms.PictureBox();
            this.setBox = new System.Windows.Forms.PictureBox();
            this.mineNumOneBox = new System.Windows.Forms.PictureBox();
            this.mineNumTenBox = new System.Windows.Forms.PictureBox();
            this.mineNumHundredBox = new System.Windows.Forms.PictureBox();
            this.secondOneBox = new System.Windows.Forms.PictureBox();
            this.secondTenBox = new System.Windows.Forms.PictureBox();
            this.secondHundredBox = new System.Windows.Forms.PictureBox();
            this.secondThousandBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.faceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumOneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumTenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumHundredBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondOneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondHundredBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondThousandBox)).BeginInit();
            //初始化装载命令
            this.mouseEventInvoker.bindCommand(this.faceBox, MouseUpDown.DOWN, MouseButtons.Left, new FaceBoxMouseDownCommand(this));
            this.mouseEventInvoker.bindCommand(this.faceBox, MouseUpDown.DOWN, MouseButtons.Right, new FaceBoxMouseDownCommand(this));
            this.mouseEventInvoker.bindCommand(this.faceBox, MouseUpDown.UP, MouseButtons.Left, new FaceBoxMouseUpCommand(this));
            this.mouseEventInvoker.bindCommand(this.faceBox, MouseUpDown.UP, MouseButtons.Right, new FaceBoxMouseUpCommand(this));
            this.mouseEventInvoker.bindCommand(this.setBox, MouseUpDown.DOWN, MouseButtons.Left, new SetBoxMouseDownCommand(this));
            this.mouseEventInvoker.bindCommand(this.setBox, MouseUpDown.DOWN, MouseButtons.Right, new SetBoxMouseDownCommand(this));
            this.mouseEventInvoker.bindCommand(this.setBox, MouseUpDown.UP, MouseButtons.Left, new SetBoxMouseUpCommand(this));
            this.mouseEventInvoker.bindCommand(this.setBox, MouseUpDown.UP, MouseButtons.Right, new SetBoxMouseUpCommand(this));

            this.SuspendLayout();
            // 
            // faceBox
            // 
            this.faceBox.Location = new System.Drawing.Point(0, 0);
            this.faceBox.Name = "faceBox";
            this.faceBox.Size = new System.Drawing.Size(25, 24);
            this.faceBox.TabIndex = 0;
            this.faceBox.TabStop = false;
            this.faceBox.MouseDown += this.mouseEventInvoker.callMouseDownEvent;
            this.faceBox.MouseUp += this.mouseEventInvoker.callMouseUpEvent;
            // 
            // setBox
            // 
            this.setBox.Location = new System.Drawing.Point(0, 0);
            this.setBox.Name = "setBox";
            this.setBox.Size = new System.Drawing.Size(25, 24);
            this.setBox.TabIndex = 0;
            this.setBox.TabStop = false;
            this.setBox.MouseDown += this.mouseEventInvoker.callMouseDownEvent;
            this.setBox.MouseUp += this.mouseEventInvoker.callMouseUpEvent;
            // 
            // mineNumOneBox
            // 
            this.mineNumOneBox.Location = new System.Drawing.Point(18, 13);
            this.mineNumOneBox.Name = "mineNumOneBox";
            this.mineNumOneBox.Size = new System.Drawing.Size(14, 24);
            this.mineNumOneBox.TabIndex = 1;
            this.mineNumOneBox.TabStop = false;
            // 
            // mineNumTenBox
            // 
            this.mineNumTenBox.Location = new System.Drawing.Point(31, 13);
            this.mineNumTenBox.Name = "mineNumTenBox";
            this.mineNumTenBox.Size = new System.Drawing.Size(14, 24);
            this.mineNumTenBox.TabIndex = 2;
            this.mineNumTenBox.TabStop = false;
            // 
            // mineNumHundredBox
            // 
            this.mineNumHundredBox.Location = new System.Drawing.Point(44, 13);
            this.mineNumHundredBox.Name = "mineNumHundredBox";
            this.mineNumHundredBox.Size = new System.Drawing.Size(14, 24);
            this.mineNumHundredBox.TabIndex = 2;
            this.mineNumHundredBox.TabStop = false;
            // 
            // secondOneBox
            // 
            this.secondOneBox.Location = new System.Drawing.Point(0, 0);
            this.secondOneBox.Name = "secondOneBox";
            this.secondOneBox.Size = new System.Drawing.Size(14, 24);
            this.secondOneBox.TabIndex = 6;
            this.secondOneBox.TabStop = false;
            // 
            // secondTenBox
            // 
            this.secondTenBox.Location = new System.Drawing.Point(0, 0);
            this.secondTenBox.Name = "secondTenBox";
            this.secondTenBox.Size = new System.Drawing.Size(14, 24);
            this.secondTenBox.TabIndex = 5;
            this.secondTenBox.TabStop = false;
            // 
            // secondHundredBox
            // 
            this.secondHundredBox.Location = new System.Drawing.Point(0, 0);
            this.secondHundredBox.Name = "secondHundredBox";
            this.secondHundredBox.Size = new System.Drawing.Size(14, 24);
            this.secondHundredBox.TabIndex = 4;
            this.secondHundredBox.TabStop = false;
            // 
            // secondThousandBox
            // 
            this.secondThousandBox.Location = new System.Drawing.Point(0, 0);
            this.secondThousandBox.Name = "secondThousandBox";
            this.secondThousandBox.Size = new System.Drawing.Size(14, 24);
            this.secondThousandBox.TabIndex = 3;
            this.secondThousandBox.TabStop = false;
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.secondOneBox);
            this.Controls.Add(this.secondTenBox);
            this.Controls.Add(this.secondHundredBox);
            this.Controls.Add(this.secondThousandBox);
            this.Controls.Add(this.mineNumOneBox);
            this.Controls.Add(this.mineNumTenBox);
            this.Controls.Add(this.mineNumHundredBox);
            this.Controls.Add(this.faceBox);
            this.Controls.Add(this.setBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.MinesweeperForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MinesweeperForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.faceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumOneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumTenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineNumHundredBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondOneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondHundredBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondThousandBox)).EndInit();
            this.ResumeLayout(false);            

        }

        #endregion        

        public System.Windows.Forms.PictureBox faceBox;
        public System.Windows.Forms.PictureBox setBox;
        public System.Windows.Forms.PictureBox mineNumOneBox;
        public System.Windows.Forms.PictureBox mineNumTenBox;
        public System.Windows.Forms.PictureBox mineNumHundredBox;
        public System.Windows.Forms.PictureBox secondHundredBox;
        public System.Windows.Forms.PictureBox secondThousandBox;
        public System.Windows.Forms.PictureBox secondOneBox;
        public System.Windows.Forms.PictureBox secondTenBox;
        //计时
        public System.Timers.Timer timer = new System.Timers.Timer();
        //构造类
        public MinesweeperBuilder builder;
        //游戏状态 0未开始 1进行中 2结束
        public int gameState = 0;
        //游戏时间
        public int gameTime = 0;
        //游戏设置
        public MinesSet minesSet;
        //雷区PictureBox缓存
        public Dictionary<int, PictureBox> minesDict = new Dictionary<int, PictureBox>();
        //当前地雷数
        public int currentTotalMines;
        //初始化地雷数
        public int initTotalMines;
        //初始化雷区（包括无雷区）
        public int[] initMinesMap;
        //初始化雷区
        public int[] initMines;
        //配置文件名
        public string setFileName = "set.ini";
        public string defaultSetIniFileSection = "default";
        //设置窗口
        public UserSetForm userSetForm;

        public Dictionary<int, Image> dictTmp;
        //命令调用者
        private MouseEventInvoker mouseEventInvoker = new MouseEventInvoker();
    }

}

