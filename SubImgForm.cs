using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitPic
{
    public partial class SubImgForm : Form
    {
        string mBaseName = "";

        public SubImgForm(string filename)
        {
            InitializeComponent();
            mBaseName = filename;
        }

        public void Rotate(float angle)
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.Dispose();
            pictureBox1.Image = Rotate(b, angle);
            b.Dispose();
        }

        /// <summary>  
        /// 以逆时针为方向对图像进行旋转  
        /// </summary>  
        /// <param name="b">位图流</param>  
        /// <param name="angle">旋转角度[0,360](前台给的)</param>  
        /// <returns></returns>  
        public Bitmap Rotate(Bitmap b, float angle)
        {
            angle = angle % 360;

            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            //原图的宽和高  
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图  
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);

            g.InterpolationMode = InterpolationMode.Bilinear;

            g.SmoothingMode = SmoothingMode.HighQuality;

            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);

            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);

            //重至绘图的所有变换  
            g.ResetTransform();

            g.Save();
            g.Dispose();
            return dsImage;
        }

        private void SubImgForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    bt_left.PerformClick();
                    break;
                case Keys.Right:
                    bt_right.PerformClick();
                    break;
                case Keys.Up:
                case Keys.Down:
                    bt_180.PerformClick();
                    break;
                case Keys.PageUp:
                    bt_left01.PerformClick();
                    break;
                case Keys.PageDown:
                    bt_right01.PerformClick();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_save_Click(object sender, EventArgs e)
        {
            string dir = System.IO.Path.GetDirectoryName(mBaseName);
            string bn = System.IO.Path.GetFileNameWithoutExtension(mBaseName);
            string ext = System.IO.Path.GetExtension(mBaseName);

            //当前目录下生成 原名-NUM 的文件
            string name = "";
            for (int i = 1; ; ++i)
            {
                name = dir + System.IO.Path.DirectorySeparatorChar + bn + "-" + i.ToString() + ext;
                if (!System.IO.File.Exists(name))
                    break;
            }

            pictureBox1.Image.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
            Close();
        }

        private void bt_left_Click(object sender, EventArgs e)
        {
            float rate = float.Parse((sender as Button).Tag as string);
            Rotate(rate);
        }   
    }
}
