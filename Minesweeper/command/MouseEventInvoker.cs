using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    /**
     * 鼠标事件命令调用者
     * **/
    public class MouseEventInvoker
    {
        private Dictionary<PictureBox, Dictionary<MouseUpDown, Dictionary<MouseButtons, MouseEventCommand>>> commands = new Dictionary<PictureBox, Dictionary<MouseUpDown, Dictionary<MouseButtons, MouseEventCommand>>>();
        public void bindCommand(PictureBox box, MouseUpDown mouseUpDown, MouseButtons mouseButton, MouseEventCommand command) {
            if (commands.ContainsKey(box))
            {
                if (commands[box].ContainsKey(mouseUpDown))
                {
                    commands[box][mouseUpDown].Add(mouseButton, command);
                }
                else {
                    Dictionary<MouseButtons, MouseEventCommand> commandDict = new Dictionary<MouseButtons, MouseEventCommand>();
                    commandDict.Add(mouseButton, command);
                    commands[box].Add(mouseUpDown, commandDict);
                }
            }
            else {
                Dictionary<MouseButtons, MouseEventCommand> commandDict = new Dictionary<MouseButtons, MouseEventCommand>();
                commandDict.Add(mouseButton, command);
                Dictionary<MouseUpDown, Dictionary<MouseButtons, MouseEventCommand>> upDownDict = new Dictionary<MouseUpDown, Dictionary<MouseButtons, MouseEventCommand>>();
                upDownDict.Add(mouseUpDown, commandDict);
                commands.Add(box, upDownDict);
            }
        }
        public void execute(PictureBox box, MouseUpDown mouseUpDown, MouseButtons mouseButton) {
            MouseEventCommand mouseEventCommand;
            mouseEventCommand = commands.ContainsKey(box) ? (commands[box].ContainsKey(mouseUpDown) ? (commands[box][mouseUpDown].ContainsKey(mouseButton) ? commands[box][mouseUpDown][mouseButton] : null) : null) : null;
            if (mouseEventCommand != null) {
                mouseEventCommand.execute();
            }
        }

        public void callMouseDownEvent(object sender, MouseEventArgs e) {
            this.execute((PictureBox)sender, MouseUpDown.DOWN, e.Button);
        }
        public void callMouseUpEvent(object sender, MouseEventArgs e)
        {
            this.execute((PictureBox)sender, MouseUpDown.UP, e.Button);
        }
    }
}
