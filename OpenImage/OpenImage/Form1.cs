using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenImage
{
    public partial class Form1 : Form
    {
        //文件名
        private string curFileName;
        private HiPerfTimer myTimer;


        //图像对象
        private System.Drawing.Bitmap curBitmap;

        public Form1()
        {
            myTimer = new HiPerfTimer();
            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            //创建OpenFileDialog
            OpenFileDialog opnDlg = new OpenFileDialog();
            //为图像选择一个筛选器
            opnDlg.Filter = "所有图像文件 | *.bmp;*.pcx;*.png;*.jpg;*.gif;" +
                "*.tif;*.ico;*.dxf;*.cgm;*.cdr;*.wmf;*.eps;*emf|" +
                "位图(*.bmp;*.jpg;*.png;...)|*.bmp;*.pcx;*.png:*.jpg;*.gif;*.tif;*.ico|" +
                "矢量图(*.wmf;*.eps;*.emf;...)|*.dxf;*.cgm;*.cdr;*.wmf;*.eps;*.emf";
            //设置对话框标题
            opnDlg.Title = "打开图像文件";
            //启用“帮助”按钮
            opnDlg.ShowHelp = true;

            //如果结果为“打开”，选定文件
            if(opnDlg.ShowDialog()==DialogResult.OK)
            {
                //读取当前选中的文件名
                curFileName = opnDlg.FileName;
                // 使用Image.FromFile创建图像对象
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                }
                catch(Exception exp)
                {
                    //抛出异常
                    MessageBox.Show(exp.Message);
                }
            }

            //对窗体进行重新绘制，这样强制执行paint事件处理程序
            Invalidate();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //如果没有创建图像，则退出
            if(curBitmap==null)
            {
                return;
            }

            //调用SaveFileDialog
            SaveFileDialog saveDig = new SaveFileDialog();
            //设置对话框标题
            saveDig.Title = "保存为";
            //改写已存在文件时提示用户
            saveDig.OverwritePrompt = true;
            //为图像选择一个筛选器
            saveDig.Filter = "BMP文件(*.bmp)|*.bmp|" + "Gif文件(*.gif)|*.gif|" + "JPEG文件(*.jpg)|*.jpg|" + "PNG文件(*.png)|*.png";
            //启用“帮助”按钮
            saveDig.ShowHelp = true;

            //如果选择了格式，则保存图像
            if(saveDig.ShowDialog()==DialogResult.OK)
            {
                //获取用户选择的文件名
                string fileName = saveDig.FileName;
                //获取用户选择文件的扩展名
                string strFileExtn = fileName.Remove(0, fileName.Length - 3);

                //保存文件
                switch(strFileExtn)
                {
                    case "bmp":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //获取Graphics对象
            Graphics g = e.Graphics;

            if(curBitmap!=null)
            {
                //使用DrawImage方法绘制图像
                //160，20；显示在主窗体内，图像左上角的坐标
                //curBitmap.Width, curBitmap.Heigth;图像的宽度和高度
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }

        private void buttonPixel_Click(object sender, EventArgs e)
        {
            if(curBitmap!=null)
            {
                //启动计时器
                myTimer.Start();

                Color curColor;
                int ret;

                //二维图像数组循环
                for(int i=0;i<curBitmap.Width;i++)
                {
                    for(int j=0;j<curBitmap.Height;j++)
                    {
                        //获取改点像素的RGB颜色值
                        curColor = curBitmap.GetPixel(i, j);
                        //利用公式Gray(i,j)=0.299×R(i,j)+0.587×G(i,j)+0.144×B(i,j)计算灰度值
                        ret = (int)(curColor.R * 0.299 + curColor.G * 0.587 + curColor.B * 0.144);
                        //设置该点像素的灰度值,R=G=B=ret
                        curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                    }
                }

                //关闭计时器
                myTimer.Stop();
                //在TextBox内显示计时时间
                textBoxTime.Text = myTimer.Duration.ToString("####.##") + "毫秒";

                //对窗体进行重新绘制，这将强制执行Paint事件处理程序
                Invalidate();
            }
        }

        private void buttonMemory_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //启动计时器
                myTimer.Start();

                //位图矩形
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                //以可读写的方式锁定全部位图像素
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                //得到首地址
                IntPtr ptr = bmpData.Scan0;

                //24位bmp位图字节数
                int bytes = curBitmap.Width * curBitmap.Height * 3;
                //定义位图数组
                byte[] rgbValues = new byte[bytes];
                //复制被锁定的位图像素值到该数组内
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                //灰度化
                double colorTemp = 0;
                for (int i = 0; i < rgbValues.Length; i += 3)
                {
                    //利用公式计算灰度值
                    colorTemp = rgbValues[i + 2] * 0.299 + rgbValues[i + 1] * 0.587 + rgbValues[i] * 0.114;
                    //R=G=B
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)colorTemp;
                }

                //把数组复制回位图
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                //解锁位图像素
                curBitmap.UnlockBits(bmpData);

                //关闭计时器
                myTimer.Stop();
                //在TextBox内显示计时时间
                textBoxTime.Text = myTimer.Duration.ToString("####.##") + "毫秒";

                //对窗体进行重新绘制，这样强制执行Paint事件处理程序
                Invalidate();
            }
        }

        ////适用于任意大小24位彩色图像，之上仅适用于24位512×512大小位图
        //private void buttonMemory_Click(object sender, EventArgs e)
        //{
        //    if(curBitmap!=null)
        //    {
        //        //位图矩形
        //        Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
        //        //以可读写的方式锁定全部位图像素
        //        System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
        //        //得到首地址
        //        IntPtr ptr = bmpData.Scan0;

        //        //定义被锁定的数组大小，由位图数据与未用空间组成
        //        int bytes = bmpData.Stride * bmpData.Height;
        //        //定义位图数组
        //        byte[] rgbValues = new byte[bytes];
        //        //复制被锁定的位图像素值到该数组内
        //        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

        //        //灰度化
        //        double colorTemp = 0;
        //        for(int i=0;i<bmpData.Height;i++)
        //        {
        //            //只处理每行中是图像像素的数据，舍弃未用空间
        //            for (int j = 0; j < bmpData.Width*3;j+=3)
        //            {
        //                colorTemp = rgbValues[i * bmpData.Stride + j + 2] * 0.299 + rgbValues[i * bmpData.Stride + j + 1] * 0.587 + rgbValues[i * bmpData.Stride + j] * 0.114;
        //                //R=G=B
        //                rgbValues[i * bmpData.Stride + j] = rgbValues[i * bmpData.Stride + j + 1] = rgbValues[i * bmpData.Stride + j + 2] = (byte)colorTemp;
        //            }
                        
        //        }

        //        //把数组复制回位图
        //        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
        //        //解锁位图像素
        //        curBitmap.UnlockBits(bmpData);
        //        //对窗体进行重新绘制，这样强制执行Paint事件处理程序
        //        Invalidate();
        //    }
        //}

        private void buttonPointer_Click(object sender, EventArgs e)
        {
             if(curBitmap!=null)
            {
                //启动计时器
                myTimer.Start();

                //位图矩形
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                //以可读写的方式锁定全部位图像素
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);

                byte temp=0;
                 //启动不安全模式
                 unsafe
                 {
                     //得到首地址
                     byte* ptr=(byte*)(bmpData.Scan0);
                     //二维图像循环
                     for(int i=0;i<bmpData.Height;i++)
                     {
                         for(int j=0;j<bmpData.Width;j++)
                         {
                             temp=(byte)(0.299*ptr[2]+0.587*ptr[1]+0.144*ptr[0]);
                             //R=G=B
                             ptr[0]=ptr[1]=ptr[2]=temp;
                             ptr+=3;
                         }
                         //指向下一行数组的首个字节
                         ptr+=bmpData.Stride-bmpData.Width*3;
                     }
                 }

                 //解锁位图像素
                 curBitmap.UnlockBits(bmpData);

                 //关闭计时器
                 myTimer.Stop();
                 //在TextBox内显示计时时间
                 textBoxTime.Text = myTimer.Duration.ToString("####.##") + "毫秒";

                 //对窗体进行绘制，这样强制执行Paint事件处理程序
                 Invalidate();
             }
        }
    }
}
