using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineBoxMouseMidDownCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        private PictureBox mineBox;
        public MineBoxMouseMidDownCommand(MinesweeperForm minesweeperForm, PictureBox mineBox)
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
                    this.minesweeperForm.dictTmp = new Dictionary<int, Image>();
                    foreach (KeyValuePair<int, PictureBox> kvp in this.minesweeperForm.minesDict)
                    {
                        foreach (int b in aroundMines)
                        {
                            if (kvp.Value.Name.Equals(b + ""))
                            {
                                if (kvp.Value.Image == ImageUtil.mineImage || kvp.Value.Image == ImageUtil.mineQImage)
                                {
                                    this.minesweeperForm.dictTmp.Add(b, kvp.Value.Image);
                                    kvp.Value.Image = ImageUtil.mineDownImage;
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
