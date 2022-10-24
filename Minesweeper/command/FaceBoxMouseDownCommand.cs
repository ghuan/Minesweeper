using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class FaceBoxMouseDownCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        public FaceBoxMouseDownCommand(MinesweeperForm minesweeperForm) {
            this.minesweeperForm = minesweeperForm;
        }
        public override void execute()
        {
            this.minesweeperForm.faceBox.Image = ImageUtil.pressFaceImage;
        }
    }
}
