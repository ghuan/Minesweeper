using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineBoxMouseLeftDownCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        private PictureBox mineBox;
        public MineBoxMouseLeftDownCommand(MinesweeperForm minesweeperForm, PictureBox mineBox) {
            this.minesweeperForm = minesweeperForm;
            this.mineBox = mineBox;
        }
        public override void execute()
        {
            if (this.minesweeperForm.gameState != 2 && mineBox.Image == ImageUtil.mineImage)
            {
                mineBox.Image = ImageUtil.mineDownImage;
                this.minesweeperForm.faceBox.Image = ImageUtil.frontFaceImage;
            }
        }
    }
}
