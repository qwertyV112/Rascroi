using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vkr2015Sangaa
{
    abstract class Objec
    {
        public float Height;
        public float Width;
        public float S;
        public float H;
        //
        public float x1;
        public float y1;
        public float x;
        public float y;
        //
        //

        public void Create(float height, float width, float h)
        {
            this.Height = height;
            this.Width = width;
            this.H = h;
            this.S = this.Height * this.Height;
        }
    }
}
