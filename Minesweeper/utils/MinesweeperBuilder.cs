using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MinesweeperBuilder
    {
        private MinesweeperForm minesweeperForm;
        public MinesweeperBuilder(MinesweeperForm minesweeperForm) {
            this.minesweeperForm = minesweeperForm;
        }

        /**
         * 获取当前点击雷区的周围雷区
         * **/
        public int[] getAroundMines(int mine,int mineXCount)
        {
            int x = mine / mineXCount + (mine % mineXCount > 0 ? 1 : 0);
            int frontX = x - 1;
            int afterX = x + 1;
            int[] aroundMines = new int[9];
            if (frontX > 0)
            {
                aroundMines[0] = mine - (mineXCount+1) < (frontX - 1) * mineXCount + 1 ? 0 : mine - (mineXCount + 1);
                aroundMines[1] = mine - mineXCount;
                aroundMines[2] = mine - (mineXCount - 1) > (frontX - 1) * mineXCount + mineXCount ? 0 : mine - (mineXCount - 1);
            }
            else
            {
                aroundMines[0] = 0;
                aroundMines[1] = 0;
                aroundMines[2] = 0;
            }
            aroundMines[3] = mine - 1 < (x - 1) * mineXCount + 1 ? 0 : mine - 1;
            aroundMines[4] = 0;
            aroundMines[5] = mine + 1 > (x - 1) * mineXCount + mineXCount ? 0 : mine + 1;
            if (afterX > 0)
            {
                aroundMines[6] = mine + (mineXCount - 1) < (afterX - 1) * mineXCount + 1 ? 0 : mine + (mineXCount - 1);
                aroundMines[7] = mine + mineXCount;
                aroundMines[8] = mine + (mineXCount + 1) > (afterX - 1) * mineXCount + mineXCount ? 0 : mine + (mineXCount + 1);
            }
            else
            {
                aroundMines[6] = 0;
                aroundMines[7] = 0;
                aroundMines[8] = 0;
            }
            return aroundMines;
        }

        /**
        * 随机分配地雷
        * @author huan.gao
        * @date 2022-10-18 15:33:07
        **/
        public int[] getRandomMines(int initMinesNum, int initTotalMinesNum, int minesIndex)
        {
            int minValue = 1;
            if ((initTotalMinesNum + 1 - minValue - initMinesNum < 0))
                initTotalMinesNum += initMinesNum - (initTotalMinesNum + 1 - minValue);
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[initMinesNum];
            int tmp = 0;
            StringBuilder sb = new StringBuilder(initMinesNum * initTotalMinesNum.ToString().Trim().Length);
            sb.Append("#" + minesIndex.ToString().Trim() + "#");
            for (int i = 0; i <= initMinesNum - 1; i++)
            {
                tmp = ra.Next(minValue, initTotalMinesNum);
                while (sb.ToString().Contains("#" + tmp.ToString().Trim() + "#"))
                    tmp = ra.Next(minValue, initTotalMinesNum + 1);
                arrNum[i] = tmp;
                sb.Append("#" + tmp.ToString().Trim() + "#");
            }
            return arrNum;
        }

        public void checkMine(PictureBox sender)
        {
            try
            {
                int mine = int.Parse(sender.Name);
                int countmines = 0;//周围雷数
                int[] aroundMines = getAroundMines(mine, minesweeperForm.minesSet.XCount);

                foreach (int a in minesweeperForm.initMines)
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
                    sender.Image = ImageUtil.getMineCountImage(countmines);

                }
                else
                {
                    sender.Image = ImageUtil.mineDownImage;
                    foreach (int emine in aroundMines)
                    {
                        if (emine != mine && emine != 0)
                        {
                            foreach (KeyValuePair<int, PictureBox> kvp in minesweeperForm.minesDict)
                            {
                                if (kvp.Value.Name.Equals(emine + "") && kvp.Value.Image == ImageUtil.mineImage)
                                {
                                    checkMine(kvp.Value);
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public bool checkSuccess()
        {
            int tag = 0;
            foreach (KeyValuePair<int, PictureBox> kvp in minesweeperForm.minesDict)
            {
                if (kvp.Value.Image == ImageUtil.mineImage || kvp.Value.Image == ImageUtil.mineTagImage || kvp.Value.Image == ImageUtil.mineQImage)
                {
                    tag++;
                }
            }
            if (tag == this.minesweeperForm.initTotalMines)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void mineCount()
        {
            //timer.Stop();


            if (this.minesweeperForm.currentTotalMines < 0)
            {
                string mines = -this.minesweeperForm.currentTotalMines + "";
                if (mines.Length == 1)
                {
                    mines = "0" + mines;
                }

                char[] ms = mines.ToCharArray();
                this.minesweeperForm.mineNumOneBox.Image = ImageUtil.timeImageF;
                this.minesweeperForm.mineNumTenBox.Image = ImageUtil.getTimeImage(int.Parse(ms[0] + ""));
                this.minesweeperForm.mineNumHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ms[1] + ""));
            }
            else
            {
                string mines = this.minesweeperForm.currentTotalMines + "";
                if (mines.Length == 1)
                {
                    mines = "00" + mines;
                }
                if (mines.Length == 2)
                {
                    mines = "0" + mines;
                }
                char[] ms = mines.ToCharArray();
                this.minesweeperForm.mineNumOneBox.Image = ImageUtil.getTimeImage(int.Parse(ms[0] + ""));
                this.minesweeperForm.mineNumTenBox.Image = ImageUtil.getTimeImage(int.Parse(ms[1] + ""));
                this.minesweeperForm.mineNumHundredBox.Image = ImageUtil.getTimeImage(int.Parse(ms[2] + ""));
            }
        }

        /**
        * 重置游戏
        **/
        public void resetGame()
        {
            this.minesweeperForm.faceBox.Image = ImageUtil.startFaceImage;
            this.minesweeperForm.secondThousandBox.Image = ImageUtil.timeImage0;
            this.minesweeperForm.secondHundredBox.Image = ImageUtil.timeImage0;
            this.minesweeperForm.secondTenBox.Image = ImageUtil.timeImage0;
            this.minesweeperForm.secondOneBox.Image = ImageUtil.timeImage0;
            foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
            {
                kvp.Value.Image = ((System.Drawing.Image)(ImageUtil.mineImage));
            }
            this.minesweeperForm.gameState = 0;
            this.minesweeperForm.currentTotalMines = this.minesweeperForm.minesSet.TotalMines;
            this.minesweeperForm.gameTime = 0;
            mineCount();
            this.minesweeperForm.timer.Stop();
        }

        public void copy_mineClick(PictureBox picture)
        {

            int minenum = int.Parse(picture.Name);

            bool ismine = false;
            foreach (int a in this.minesweeperForm.initMines)
            {
                if (minenum == a)
                {
                    ismine = true;
                }

            }
            if (ismine)
            {
                this.minesweeperForm.faceBox.Image = ImageUtil.failFaceImage;
                picture.Image = ImageUtil.minImage;
                foreach (int a in this.minesweeperForm.initMines)
                {
                    if (minenum != a)
                    {
                        foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
                        {
                            if (kvp.Value.Image == ImageUtil.mineTagImage)
                            {
                                bool sfmine = false;
                                foreach (int aa in this.minesweeperForm.initMines)
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
                this.minesweeperForm.timer.Stop();
                this.minesweeperForm.gameState = 2;

            }
            else
            {
                picture.Image = ImageUtil.mineDownImage;
                this.minesweeperForm.faceBox.Image = ImageUtil.startFaceImage;
                checkMine(picture);
                if (checkSuccess())
                {
                    this.minesweeperForm.faceBox.Image = ImageUtil.successFaceImage;

                    this.minesweeperForm.timer.Stop();
                    this.minesweeperForm.gameState = 2;
                    MessageBox.Show("恭喜您，通关成功！");
                }
            }
        }
    }
}
