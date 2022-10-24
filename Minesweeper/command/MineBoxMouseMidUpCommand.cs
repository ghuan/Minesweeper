using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineBoxMouseMidUpCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        private PictureBox mineBox;

        public MineBoxMouseMidUpCommand(MinesweeperForm minesweeperForm, PictureBox mineBox)
        {
            this.minesweeperForm = minesweeperForm;
            this.mineBox = mineBox;
        }
        public override void execute()
        {
            if (mineBox.Image != ImageUtil.mineImage && mineBox.Image != ImageUtil.mineQImage && mineBox.Image != ImageUtil.mineTagImage && mineBox.Image != ImageUtil.mineDownImage)
            {
                int thisMines = ImageUtil.getMineCount(mineBox.Image);
                int mine = int.Parse(mineBox.Name);
                if (thisMines != 0)
                {
                    int[] aroundMines = this.minesweeperForm.builder.getAroundMines(mine, this.minesweeperForm.minesSet.XCount);
                    foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
                    {
                        foreach (KeyValuePair<int, Image> kvp1 in this.minesweeperForm.dictTmp)
                        {
                            if (kvp.Value.Name.Equals("" + kvp1.Key))
                            {
                                kvp.Value.Image = kvp1.Value;
                            }
                        }


                    }
                    int count = 0;
                    int num = 0;
                    Dictionary<int, PictureBox> dict1 = new Dictionary<int, PictureBox>();
                    foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
                    {
                        foreach (int b in aroundMines)
                        {
                            if (kvp.Value.Name.Equals(b + ""))
                            {
                                num++;

                                if (kvp.Value.Image == ImageUtil.mineTagImage)
                                {
                                    count++;
                                }
                                else
                                {
                                    dict1.Add(num, kvp.Value);
                                }
                            }
                        }
                    }
                    if (count == thisMines)
                    {

                        foreach (KeyValuePair<int, PictureBox> kvp in dict1)
                        {
                            if (kvp.Value.Image == ImageUtil.mineImage)
                            {
                                this.minesweeperForm.builder.copy_mineClick(kvp.Value);
                            }

                        }
                    }
                }
            }
            this.minesweeperForm.builder.mineCount();
        }

    }
}
