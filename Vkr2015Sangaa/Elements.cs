using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vkr2015Sangaa
{
    class Elements
    {
        public float H;
        public float W;
        public float S;
  //      public float Sk;

        public float x;
        public float y;
     //   public float x1;
     //   public float y1;

        public bool flag = false;
        public Elements(float h,float w,float r)
        {
            x = 0;
            y = 0;
            H = h + r;
            W = w + r;
            S = H * W;
         //   Sk = S;
            //
            //x1 = ;
            //y1 = w + r;
            Rand();
        }
        /*public void Rotation()
        {
            float t = H;
            H = W;
            W = t;
            //
            t = x1;
            y1 = x1;
            x1 = t;
        }*/
        public void Creat()
        {
            
        }

        public void Rand()
        {
           /* Random rand = new Random();
            x = rand.Next(200);
            y = rand.Next(200);*/
        }
    }
}
