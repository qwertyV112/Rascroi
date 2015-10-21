using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vkr2015Sangaa;

namespace Vkr2015Sangaa
{
    class Image
    {
        private static Image instance;
        public Graphics image1;
        public Pen pen;
        public Pen pen2;
        public PictureBox Map;
        public float scale;
        public float scaleRazm;

        private static Image configManager;

        public static Image GetInstance()
        {
            // для исключения возможности создания двух объектов 
            // при многопоточном приложении
            if (configManager == null)
            {
                lock (typeof(Image))
                {
                    if (configManager == null)
                        configManager = new Image();
                }
            }

            return configManager;
        }
        public void Create(){
            Map = new PictureBox();
            Map.Width = 400 ;
            Map.Height = 400;
            Map.Location = new System.Drawing.Point(350, 13);
            Map.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            pen = new Pen(Color.Red);
            pen2 = new Pen(Color.Green);
            image1 = Map.CreateGraphics();
        }
        public  Image()
        {
            
            /*
                  pen = new Pen(Color.Green);
            image = pictureBox1.CreateGraphics();
            float r = Convert.ToSingle(textBox1.Text); // Исправить ... Block
            block Brewno = new block(r, pictureBox1.Height);*/

        }
        public void Ellipse(float x, float y)
        {
            image1.DrawEllipse(pen, x +scaleRazm, y + scaleRazm, 2, 2);
        }

        public void Rectangle(float x, float y, float x1, float y1)
        {
            image1.DrawRectangle(pen2, x + scaleRazm, y + scaleRazm, x1 , y1 );
        }
        public void Rectangle3(float x, float y, float x1, float y1)
        {
            image1.DrawRectangle(pen, x + scaleRazm, y + scaleRazm, x1, y1);
        }
        public void Rectangle1(float x, float y, float x1, float y1)
        {
            image1.DrawRectangle(pen, x + scaleRazm, y + scaleRazm, x1 + scaleRazm, y1 + scaleRazm);
            /*
                         //this.Ky = (h / 2) - (this.a / 2);
            //this.Kx = (w / 2) - (this.a / 2);
            float I = Convert.ToSingle((3 * Math.PI) / 4); //(3 * Math.PI)/4
            this.Ky = this.CordY(I);
            this.Kx = this.CordX(I);
            this.a *= this.t1;
            image.DrawRectangle(pen, Brewno.Kx + pictureBox1.Width / 2, Brewno.Ky + pictureBox1.Width / 2, Brewno.a, Brewno.a);
             * */
        }
    }
}
