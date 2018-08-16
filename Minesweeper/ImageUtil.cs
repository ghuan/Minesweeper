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

        private static Rectangle timeImageRecF = new Rectangle(0, 0, (14 - 0), 24);
        private static Rectangle timeImageRecNull = new Rectangle(0, 22, (14 - 0), 24);
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
        private static Rectangle mineTagImageRec = new Rectangle(0, 20, (24 - 0), 24);
        private static Rectangle mineQImageRec = new Rectangle(0, 40, (24 - 0), 24);
        private static Rectangle mineImageDownRec = new Rectangle(0, 300, (24 - 0), 24);
        private static Rectangle mineRec = new Rectangle(0, 60, (24 - 0), 24);
        private static Rectangle mineRec2 = new Rectangle(0, 80, (24 - 0), 24);
        private static Rectangle mineRec1 = new Rectangle(0, 100, (24 - 0), 24);
        private static Rectangle mineCount1Rec = new Rectangle(0, 280, (24 - 0), 24);
        private static Rectangle mineCount2Rec = new Rectangle(0, 260, (24 - 0), 24);
        private static Rectangle mineCount3Rec = new Rectangle(0, 240, (24 - 0), 24);
        private static Rectangle mineCount4Rec = new Rectangle(0, 220, (24 - 0), 24);
        private static Rectangle mineCount5Rec = new Rectangle(0, 200, (24 - 0), 24);
        private static Rectangle mineCount6Rec = new Rectangle(0, 180, (24 - 0), 24);
        private static Rectangle mineCount7Rec = new Rectangle(0, 160, (24 - 0), 24);
        private static Rectangle mineCount8Rec = new Rectangle(0, 120, (24 - 0), 24);

        public static Image startFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, startFace);
        public static Image pressFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, pressFace);
        public static Image frontFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, frontFace);
        public static Image successFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, successFace);
        public static Image failFaceImage = AcquireRectangleImage(Properties.Resources.Face4Bit, failFace);

        public static Image timeImageF = AcquireRectangleImage(Properties.Resources.Digits, timeImageRecF);
        public static Image timeImageNull = AcquireRectangleImage(Properties.Resources.Digits, timeImageRecNull);
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
        public static Image mineTagImage = AcquireRectangleImage(Properties.Resources.Mines, mineTagImageRec);
        public static Image mineQImage = AcquireRectangleImage(Properties.Resources.Mines, mineQImageRec);
        public static Image mineDownImage = AcquireRectangleImage(Properties.Resources.Mines, mineImageDownRec);
        public static Image minImage = AcquireRectangleImage(Properties.Resources.Mines, mineRec);
        public static Image minImage1 = AcquireRectangleImage(Properties.Resources.Mines, mineRec1);
        public static Image minImage2 = AcquireRectangleImage(Properties.Resources.Mines, mineRec2);
        public static Image mineCount1Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount1Rec);
        public static Image mineCount2Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount2Rec);
        public static Image mineCount3Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount3Rec);
        public static Image mineCount4Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount4Rec);
        public static Image mineCount5Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount5Rec);
        public static Image mineCount6Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount6Rec);
        public static Image mineCount7Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount7Rec);
        public static Image mineCount8Image = AcquireRectangleImage(Properties.Resources.Mines, mineCount8Rec);
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
        public static int getMineCount(Image image) {
            if (image == mineCount1Image) {
                return 1;
            }
            if (image == mineCount2Image)
            {
                return 2;
            }
            if (image == mineCount3Image)
            {
                return 3;
            }
            if (image == mineCount4Image)
            {
                return 4;
            }
            if (image == mineCount5Image)
            {
                return 5;
            }
            if (image == mineCount6Image)
            {
                return 6;
            }
            if (image == mineCount7Image)
            {
                return 7;
            }
            if (image == mineCount8Image)
            {
                return 8;
            }
            return 0;
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

        public static Image getMineCountImage(int count) {
            switch (count) {
                case 1:
                    return mineCount1Image;
                case 2:
                    return mineCount2Image;
                case 3:
                    return mineCount3Image;
                case 4:
                    return mineCount4Image;
                case 5:
                    return mineCount5Image;
                case 6:
                    return mineCount6Image;
                case 7:
                    return mineCount7Image;
                case 8:
                    return mineCount8Image;
            }
            return null;
                 
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
