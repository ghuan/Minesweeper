using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    /**
     * 命令模式
     * @autor huan.gao
     * @date 2022-10-24 13:51:32
     * **/
    public abstract class MouseEventCommand
    {

        public abstract void execute();
    }
}
