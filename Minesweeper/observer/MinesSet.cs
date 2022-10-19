using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    /**
     * 用户设置
     * @author huan.gao 
     * @date 2022-10-17 17:31:55
     **/
    public class MinesSet:UserSetObservable
    {
        //地雷数
        private int totalMines = 50;
        //横坐标地图块个数
        private int xCount = 20;
        //纵坐标地图块个数
        private int yCount = 20;

        public int TotalMines
        {
            get => totalMines;
            set {
                totalMines = value;
                this.notify();
            }
        }
       
        public int XCount { 
            get => xCount;
            set
            {
                xCount = value;
                this.notify();

            }
        }
        public int YCount { 
            get => yCount;
            set
            {
                yCount = value;
                this.notify();
            }
        }
        public void set(int totalMines, int xCount,int yCount) {
            if (totalMines < 0)
            {
                throw new Exception("地雷数不能小于0个");
            }
            if (xCount < 0)
            {
                throw new Exception("雷区不能小于0个");
            }
            if (xCount < 10)
            {
                throw new Exception("横向雷区不能小于10个");
            }
            if (yCount < 0)
            {
                throw new Exception("雷区不能小于0个");
            }
            if (totalMines > xCount * yCount)
            {
                throw new Exception("地雷数不能大于雷区数");
            }
            this.totalMines = totalMines;
            this.xCount = xCount;
            this.yCount = yCount;
            this.notify();
        }
        public void set(Dictionary<String, String> data)
        {
            if (data != null)
            {
                foreach (KeyValuePair<String, String> kvp in data)
                {
                    int v = int.Parse(kvp.Value);
                    switch (kvp.Key)
                    {
                        case "totalMines":
                            if (v < 0)
                            {
                                throw new Exception("地雷数不能小于0个");
                            }
                            this.totalMines = v;
                            break;
                        case "xCount":
                            if (v < 0)
                            {
                                throw new Exception("雷区不能小于0个");
                            }
                            this.xCount = v;
                            break;
                        case "yCount":
                            if (v < 0)
                            {
                                throw new Exception("雷区不能小于0个");
                            }
                            this.yCount = v;
                            break;
                    }
                }
                if (this.totalMines > this.xCount*this.yCount) {
                    throw new Exception("地雷数不能大于雷区数");
                }
                this.notify();
            }
        }
        public Dictionary<String, String> getDictData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("totalMines", this.totalMines.ToString());
            result.Add("xCount", this.xCount.ToString());
            result.Add("yCount", this.yCount.ToString());
            return result;
        }
    }
}
