using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class MinesUtil
    {
        /**
         * 获取当前点击雷区的周围雷区
         * **/
        public static int[] getAroundMines(int mine,int mineXCount)
        {
            int x = mine / mineXCount + (mine % mineXCount > 0 ? 1 : 0);
            int frontX = x - 1;
            int afterX = x + 1;
            int[] aroundMines = new int[9];
            if (frontX > 0)
            {
                aroundMines[0] = mine - (mineXCount+1) < (frontX - 1) * mineXCount + 1 ? 0 : mine - (mineXCount + 1);
                aroundMines[1] = mine - mineXCount;
                aroundMines[2] = mine - (mineXCount - 1) > (frontX - 1) * mineXCount + mineXCount ? 0 : mine - (mineXCount - 1);
            }
            else
            {
                aroundMines[0] = 0;
                aroundMines[1] = 0;
                aroundMines[2] = 0;
            }
            aroundMines[3] = mine - 1 < (x - 1) * mineXCount + 1 ? 0 : mine - 1;
            aroundMines[4] = 0;
            aroundMines[5] = mine + 1 > (x - 1) * mineXCount + mineXCount ? 0 : mine + 1;
            if (afterX > 0)
            {
                aroundMines[6] = mine + (mineXCount - 1) < (afterX - 1) * mineXCount + 1 ? 0 : mine + (mineXCount - 1);
                aroundMines[7] = mine + mineXCount;
                aroundMines[8] = mine + (mineXCount + 1) > (afterX - 1) * mineXCount + mineXCount ? 0 : mine + (mineXCount + 1);
            }
            else
            {
                aroundMines[6] = 0;
                aroundMines[7] = 0;
                aroundMines[8] = 0;
            }
            return aroundMines;
        }

        /**
        * 随机分配地雷
        * @author huan.gao
        * @date 2022-10-18 15:33:07
        **/
        public static int[] getRandomMines(int initMinesNum, int initTotalMinesNum, int minesIndex)
        {
            int minValue = 1;
            if ((initTotalMinesNum + 1 - minValue - initMinesNum < 0))
                initTotalMinesNum += initMinesNum - (initTotalMinesNum + 1 - minValue);
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[initMinesNum];
            int tmp = 0;
            StringBuilder sb = new StringBuilder(initMinesNum * initTotalMinesNum.ToString().Trim().Length);
            sb.Append("#" + minesIndex.ToString().Trim() + "#");
            for (int i = 0; i <= initMinesNum - 1; i++)
            {
                tmp = ra.Next(minValue, initTotalMinesNum);
                while (sb.ToString().Contains("#" + tmp.ToString().Trim() + "#"))
                    tmp = ra.Next(minValue, initTotalMinesNum + 1);
                arrNum[i] = tmp;
                sb.Append("#" + tmp.ToString().Trim() + "#");
            }
            return arrNum;
        }
    }
}
