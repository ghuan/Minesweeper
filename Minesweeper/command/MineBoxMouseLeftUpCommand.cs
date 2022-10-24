using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineBoxMouseLeftUpCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        private PictureBox mineBox;

        public MineBoxMouseLeftUpCommand(MinesweeperForm minesweeperForm, PictureBox mineBox) {
            this.minesweeperForm = minesweeperForm;
            this.mineBox = mineBox;
        }
        public override void execute()
        {
            int minenum = int.Parse(mineBox.Name);
            if (this.minesweeperForm.gameState == 0)
            {//开始游戏，随机分配地雷
                this.minesweeperForm.gameState = 1;
                this.minesweeperForm.gameTime = 0;

                this.minesweeperForm.initMines = this.minesweeperForm.builder.getRandomMines(this.minesweeperForm.initTotalMines, this.minesweeperForm.initMinesMap.Length, minenum);//随机分配地雷
                this.minesweeperForm.timer.Start();
                //(sender as PictureBox).Image = ImageUtil.mineDownImage;
                this.minesweeperForm.faceBox.Image = ImageUtil.startFaceImage;
                this.minesweeperForm.builder.checkMine(mineBox);
            }
            else if (this.minesweeperForm.gameState == 1 && mineBox.Image == ImageUtil.mineDownImage)
            {
                bool ismine = false;
                foreach (int m in this.minesweeperForm.initMines)
                {
                    if (minenum == m)
                    {
                        ismine = true;
                    }

                }
                if (ismine)
                {
                    this.minesweeperForm.faceBox.Image = ImageUtil.failFaceImage;
                    mineBox.Image = ImageUtil.minImage;
                    foreach (int m in this.minesweeperForm.initMines)
                    {
                        if (minenum != m)
                        {
                            foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
                            {
                                if (kvp.Value.Image == ImageUtil.mineTagImage)
                                {
                                    bool sfmine = false;
                                    foreach (int mn in this.minesweeperForm.initMines)
                                    {
                                        if (kvp.Value.Name.Equals("" + mn))
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
                                    if (kvp.Value.Name.Equals(m + ""))
                                    {
                                        kvp.Value.Image = ImageUtil.minImage1;

                                    }
                                }

                            }
                        }


                    }
                    this.minesweeperForm.timer.Stop();
                    this.minesweeperForm.gameState = 2;

                }
                else
                {
                    mineBox.Image = ImageUtil.mineDownImage;
                    this.minesweeperForm.faceBox.Image = ImageUtil.startFaceImage;
                    this.minesweeperForm.builder.checkMine(mineBox);
                    if (this.minesweeperForm.builder.checkSuccess())
                    {
                        this.minesweeperForm.faceBox.Image = ImageUtil.successFaceImage;
                        this.minesweeperForm.timer.Stop();
                        this.minesweeperForm.gameState = 2;
                        MessageBox.Show("恭喜您，通关成功！");
                    }
                }
            }
            this.minesweeperForm.builder.mineCount();
        }

        
    }
}
