using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class SetBoxMouseUpCommand : MouseEventCommand
    {
        private MinesweeperForm minesweeperForm;
        public SetBoxMouseUpCommand(MinesweeperForm minesweeperForm) {
            this.minesweeperForm = minesweeperForm;
        }
        public override void execute()
        {
            this.minesweeperForm.setBox.Image = ImageUtil.defaultSetImage;
            if (this.minesweeperForm.userSetForm == null)
            {
                this.minesweeperForm.userSetForm = new UserSetForm();
                this.minesweeperForm.userSetForm.minesweeperForm = this.minesweeperForm;
            }
            this.minesweeperForm.userSetForm.StartPosition = this.minesweeperForm.StartPosition;
            this.minesweeperForm.userSetForm.ShowDialog();
        }
    }
}
