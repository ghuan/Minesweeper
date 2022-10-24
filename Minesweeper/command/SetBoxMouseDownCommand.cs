using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class SetBoxMouseDownCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        public SetBoxMouseDownCommand(MinesweeperForm minesweeperForm) {
            this.minesweeperForm = minesweeperForm;
        }
        public override void execute()
        {
            this.minesweeperForm.setBox.Image = ImageUtil.pressSetImage;
        }
    }
}
