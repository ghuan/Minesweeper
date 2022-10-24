using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class FaceBoxMouseUpCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        public FaceBoxMouseUpCommand(MinesweeperForm minesweeperForm)
        {
            this.minesweeperForm = minesweeperForm;
        }
        public override void execute()
        {
            this.minesweeperForm.builder.resetGame();
        }
    }
}
