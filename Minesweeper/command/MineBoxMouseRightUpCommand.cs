using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineBoxMouseRightUpCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        private PictureBox mineBox;

        public MineBoxMouseRightUpCommand(MinesweeperForm minesweeperForm, PictureBox mineBox)
        {
            this.minesweeperForm = minesweeperForm;
            this.mineBox = mineBox;
        }
        public override void execute()
        {
            if (this.minesweeperForm.gameState == 1)
            {
                if (mineBox.Image == ImageUtil.mineImage)
                {
                    mineBox.Image = ImageUtil.mineTagImage;
                    this.minesweeperForm.currentTotalMines--;
                }
                else if (mineBox.Image == ImageUtil.mineTagImage)
                {
                    mineBox.Image = ImageUtil.mineQImage;
                    this.minesweeperForm.currentTotalMines++;
                }
                else if (mineBox.Image == ImageUtil.mineQImage)
                {
                    mineBox.Image = ImageUtil.mineImage;
                }
            }
            this.minesweeperForm.builder.mineCount();
        }

    }
}
