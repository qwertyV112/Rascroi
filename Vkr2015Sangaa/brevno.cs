using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vkr2015Sangaa;

namespace Vkr2015Sangaa
{
    class brevno
    {
        public float R;
        public float D;
        public float X0;
        public float Y0;

        //
        public float X;
        public float X1;
        public float[] radius = new float[5] {(Convert.ToSingle(3 * Math.PI) / 4),((2 *Convert.ToSingle(Math.PI))/3),
                 ((5 * Convert.ToSingle(Math.PI)) / 6),((4* Convert.ToSingle(Math.PI)) / 3),(( Convert.ToSingle(Math.PI)) / 6)};

        public List<Rectangle> Kvadr;
        
        //
        public Image Brevno =Image.GetInstance();
        //public RectangleA A = new RectangleA();
        //
        public float a;
        //

        public brevno(float r)
        {
            this.R = r;
            this.D = this.R * 2;
            Brevno.scale = (Brevno.Map.Height / 2) / R;
            Brevno.scaleRazm = (Brevno.Map.Height - 2) / 2;
        }
        public float CordY(float Radius)
        {
            return Convert.ToSingle(Math.Sin(-Radius) * this.R) *Brevno.scale;// *this.t1;
        }
        public float CordX(float Radius)
        {
            return Convert.ToSingle(Math.Cos(-Radius) * this.R) * Brevno.scale; //* this.t1;
        }
        public void  KvadratA()
        {
          //  Brevno.image1.DrawRectangle(Brevno.pen,);
            //image.DrawRectangle(pen, Brewno.Kx + pictureBox1.Width / 2, Brewno.Ky + pictureBox1.Width / 2, Brewno.a, Brewno.a);
        }
        public void Create()
        {
            //рисует круг
            for (float i = 0; i < 2 * Math.PI; i += 0.005f)
            {
                float y = CordY(i); 
                float x = CordX(i);
               Brevno.Ellipse(x,y);
            }
            //

            CreateRectangle();
        }

        public void RectangleWH()
        {
            a = (this.D * Brevno.scale / Convert.ToSingle(Math.Sqrt(2)));
             X = R * Brevno.scale;
             X1 = (X * Convert.ToSingle(Math.Sqrt(3) / 2)) - (X * Convert.ToSingle(Math.Sqrt(2) / 2));
           
        }
        public void CreateRectangle() {
            Kvadr = new List<Rectangle>();
            RectangleWH();
            CreateRectangleA();
            CreateRectangleB();
            CreateRectangleC();
            CreateRectangleD();
            CreateRectangleE();
        }
        public void CreateRectangleA(){
            Rectangle temp = new Rectangle();
         float y = CordY(radius[0]);
         float x = CordX(radius[0]);
         temp.Creat(x, y, a, a);
         Kvadr.Add(temp);
        }
        public void CreateRectangleB()
        {
            Rectangle temp = new Rectangle();
            float y = CordY(radius[1]);
            float x = CordX(radius[1]);
            temp.Creat(x, y, X, X1);
            Kvadr.Add(temp);
        }
        public void CreateRectangleC()
        {
            Rectangle temp = new Rectangle();
            float y = CordY(radius[2]);
            float x = CordX(radius[2]);
            temp.Creat(x, y, X1, X);
            Kvadr.Add(temp);
        }
        public void CreateRectangleD()
        {
            Rectangle temp = new Rectangle();
            float y = CordY(radius[3]);
            float x = CordX(radius[3]);
            temp.Creat(x, y - X1, X, X1);
            Kvadr.Add(temp);
        }
        public void CreateRectangleE()
        {
            Rectangle temp = new Rectangle();
            float y = CordY(radius[4]);
            float x = CordX(radius[4]);
            temp.Creat(x - X1, y, X1, X);
            Kvadr.Add(temp);
        }
    }
}
