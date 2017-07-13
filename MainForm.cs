using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitPic
{
    public partial class MainForm : Form
    {
        Image mBaseImg = null;
        string mPathname = "";

        Point mBPt;                     //开始选择的位置
        Rectangle mRect;                //当前选中的矩形
        bool bSeled = false;            //是否处于选择过程中

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            string filename = files.GetValue(0) as string;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            this.pictureBox1.Load(filename);
            if (mBaseImg != null)
                mBaseImg.Dispose();
            mBaseImg = pictureBox1.Image.Clone() as Image;

            mPathname = filename;
            this.Text = filename;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //左键按下时开始选择
                mBPt = e.Location;
                if (mRect != null)                  //如果已经有一个选区了，先删除
                {
                    using (Graphics g = pictureBox1.CreateGraphics())   
                    {
                        var rect = pictureBox1.RectangleToScreen(mRect);
                        ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
                    }

                    mRect = new Rectangle(mBPt, new Size(0, 0));
                }
                bSeled = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right && mRect != null && mRect.Contains(e.Location))
            {
                //在选区中点击右键，弹出选区的子图片窗口
                //由于图片是以缩放的形式显示在picturebox上的，这时要根据缩放的比例来计算出选区在原始图片中的位置
                int originalWidth = this.pictureBox1.Image.Width;
                int originalHeight = this.pictureBox1.Image.Height;  

                PropertyInfo rectangleProperty = this.pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
                Rectangle rectangle = (Rectangle)rectangleProperty.GetValue(this.pictureBox1, null);

                int currentWidth = rectangle.Width;
                int currentHeight = rectangle.Height;

                double rate = (double)currentHeight / (double)originalHeight;

                int black_left_width = (currentWidth == this.pictureBox1.Width) ? 0 : (this.pictureBox1.Width - currentWidth) / 2;
                int black_top_height = (currentHeight == this.pictureBox1.Height) ? 0 : (this.pictureBox1.Height - currentHeight) / 2;
              
                int zoom_x = mRect.Left - black_left_width;
                int zoom_y = mRect.Top - black_top_height;

                double original_x = (double)zoom_x / rate;
                double original_y = (double)zoom_y / rate;

                double original_w = (double)mRect.Width / rate;
                double original_h = (double)mRect.Height / rate;

                using (var bm = new Bitmap(mBaseImg))
                {
                    SubImgForm sub = new SubImgForm(mPathname);
                    sub.pictureBox1.Image = bm.Clone(new Rectangle((int)original_x, (int)original_y, (int)original_w, (int)original_h), bm.PixelFormat);
                    sub.ShowDialog();
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bSeled)
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    var rect = pictureBox1.RectangleToScreen(mRect);
                    ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);

                    mRect = new Rectangle(Math.Min(mBPt.X, e.X), Math.Min(mBPt.Y, e.Y), Math.Abs(e.X - mBPt.X), Math.Abs(e.Y - mBPt.Y));
                    rect = pictureBox1.RectangleToScreen(mRect);

                    ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (bSeled)
            {
                bSeled = false;
            }
        }
    }
}
