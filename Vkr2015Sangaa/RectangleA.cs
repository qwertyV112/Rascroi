using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vkr2015Sangaa
{
    class Rectangle
    {
       public Image Brevno = Image.GetInstance();
       public float X0;
       public float Y0;
       public float H;
       public float W;
       public float S;
       public float Sk;

       public void Creat(float x, float y, float x1, float y1)
       {
           this.X0 = x;
           this.Y0 = y;
           this.H = x1;
           this.W = y1;
           this.S = this.W * this.W;
           this.Sk = this.S;
          // this.Render();
       }
       public void Render(){
           Brevno.Rectangle(X0,Y0,H,W);
      }
    }
}
