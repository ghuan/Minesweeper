using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class ImageUtil
    {
        private static Rectangle pressFace = new Rectangle(0, 0, (24 - 0), (24 - 0));
        private static Rectangle startFace = new Rectangle(0, 96, (24 - 0), (96 - 72));
        private static Rectangle frontFace = new Rectangle(0, 72, (24 - 0), (24 - 0));
        private static Rectangle failFace = new Rectangle(0, 48, (24 - 0), (24 - 0));
        private static Rectangle successFace = new Rectangle(0, 24, (24 - 0), (24 - 0));

        private static Rectangle timeImageRec0 = new Rectangle(0, 252, (14 - 0), 24);
        private static Rectangle timeImageRec1 = new Rectangle(0, 229, (14 - 0), 24);
        private static Rectangle timeImageRec2 = new Rectangle(0, 206, (14 - 0), 24);
        private static Rectangle timeImageRec3 = new Rectangle(0, 183, (14 - 0), 24);
        private static Rectangle timeImageRec4 = new Rectangle(0, 160, (14 - 0), 24);
        private static Rectangle timeImageRec5 = new Rectangle(0, 137, (14 - 0), 24);
        private static Rectangle timeImageRec6 = new Rectangle(0, 114, (14 - 0), 24);
        private static Rectangle timeImageRec7 = new Rectangle(0, 91, (14 - 0), 24);
        private static Rectangle timeImageRec8 = new Rectangle(0, 68, (14 - 0), 24);
        private static Rectangle timeImageRec9 = new Rectangle(0, 45, (14 - 0), 24);

        private static Rectangle mineImageRec = new Rectangle(0, 0, (24 - 0), 24);
        private static Rectangle mineImageDownRec = new Rectangle(0, 300, (24 - 0), 24);
        private static Rectangle mineRec = new Rectangle(0, 60, (24 - 0), 24);
        private static Rectangle mineRec1 = new Rectangle(0, 100, (24 - 0), 24);

        public static Image startFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, startFace);
        public static Image pressFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, pressFace);
        public static Image frontFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, frontFace);
        public static Image successFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, successFace);
        public static Image failFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, failFace);

        public static Image timeImage0 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec0);
        public static Image timeImage1 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec1);
        public static Image timeImage2 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec2);
        public static Image timeImage3 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec3);
        public static Image timeImage4 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec4);
        public static Image timeImage5 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec5);
        public static Image timeImage6 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec6);
        public static Image timeImage7 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec7);
        public static Image timeImage8 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec8);
        public static Image timeImage9 = AcquireRectangleImage(Properties.Resources.Digits, timeImageRec9);

        public static Image mineImage = AcquireRectangleImage(Properties.Resources.Mines, mineImageRec);
        public static Image mineDownImage = AcquireRectangleImage(Properties.Resources.Mines, mineImageDownRec);
        public static Image minImage = AcquireRectangleImage(Properties.Resources.Mines, mineRec);
        public static Image minImage1 = AcquireRectangleImage(Properties.Resources.Mines, mineRec1);
        /// <summary>
        /// 截取图像的矩形区域
        /// </summary>
        /// <param name="source">源图像对应picturebox1</param>
        /// <param name="rect">矩形区域，如上初始化的rect</param>
        /// <returns>矩形区域的图像</returns>
        public static Image AcquireRectangleImage(Image source, Rectangle rect)
        {
            if (source == null || rect.IsEmpty) return null;
            Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, source.PixelFormat);

            using (Graphics grSmall = Graphics.FromImage(bmSmall))
            {
                grSmall.DrawImage(source,
                new System.Drawing.Rectangle(0, 0, bmSmall.Width, bmSmall.Height),
                rect,
                GraphicsUnit.Pixel);
                grSmall.Dispose();
            }
            return bmSmall;
        }
        public static Image getTimeImage(int time) {
            int y = 0;
            if (time == 0) {
                
                y = 252;
            } else if (time == 1)
            {
                y = 229;
            }
            else if (time == 2)
            {
                y = 206;
            }
            else if (time == 3)
            {
                y = 183;
            }
            else if (time == 4)
            {
                y = 160;
            }
            else if (time == 5)
            {
                y = 137;
            }
            else if (time == 6)
            {
                y = 114;
            }
            else if (time == 7)
            {
                y = 91;
            }
            else if (time == 8)
            {
                y = 68;
            }
            else if (time == 9)
            {
                y = 45;
            }
            
            Rectangle timeImageRec = new Rectangle(0, y, (14 - 0), 24);
            return AcquireRectangleImage(Properties.Resources.Digits, timeImageRec);
        }

        public static void writeLog(string str)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + "\\log.txt", true))
            {
                file.WriteLine(str);// 直接追加文件末尾，换行
                file.Flush();
                file.Close();
            }
        }
    }
}
