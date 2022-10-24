using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class UserSetForm : Form
    {
        public UserSetForm()
        {
            InitializeComponent();
        }

        private void userSetButton_Click(object sender, EventArgs e)
        {
            try {
                this.minesweeperForm.minesSet.set(int.Parse(this.totalMinesNumberField.Value.ToString())
                    , int.Parse(this.xCountNumberField.Value.ToString())
                    , int.Parse(this.yCountNumberField.Value.ToString()));
                Dictionary<String, String> data = this.minesweeperForm.minesSet.getDictData();
                foreach (KeyValuePair<string, string> kvp in data)
                {
                    OperateIniFile.WriteIniData(this.minesweeperForm.defaultSetIniFileSection, kvp.Key, kvp.Value
                        , AppDomain.CurrentDomain.BaseDirectory + "\\" + this.minesweeperForm.setFileName);
                }
                this.minesweeperForm.builder.resetGame();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UserSetForm_Load(object sender, EventArgs e)
        {
            this.totalMinesNumberField.Value = this.minesweeperForm.minesSet.TotalMines;
            this.xCountNumberField.Value = this.minesweeperForm.minesSet.XCount;
            this.yCountNumberField.Value = this.minesweeperForm.minesSet.YCount;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
