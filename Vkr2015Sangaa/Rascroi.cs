using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Vkr2015Sangaa
{
    class Rascroi
    {
        public List<Elements> Quad;
        public Image Brevno = Image.GetInstance();
        public List<Rectangle> Kvadr1;
        List<Elements> Pr;
        public List<int> Coun= new List<int>();
        public float Pila;
        public int i = 0;
        public int temp = 0;
        public int index = 0;
        public int index2 = 0;


        public Rascroi(float p, List<Rectangle> K)
        {
            Pila = p;
            Quad = new List<Elements>();
            Kvadr1 = K;
           // float a = 5;
        }
        public void Sort()
        {
            for (int i = 0; i < Quad.Count ; i++)
            {
                float temp = Quad[i].S;
                for (int j = i; j < Quad.Count; j++)
                {
                    if (temp < Quad[j].S)
                    {
                        Elements elem = Quad[j];
                        Quad.RemoveAt(j);
                        Quad.Insert(i, elem);
                    }
                }

            }
        }
        public void Add(float h, float w)
        {
            Elements temp = new Elements(h, w, Pila);
            Quad.Add(temp);


            //Render();
            //BigChek();

        }
        public void Map()
        {
           for(int i=0; i<Kvadr1.Count;i++){
                Search(i);
                Print();
           }

        }
        public void ttt()
        {
            Pr = new List<Elements>(Quad);
            //Pr = Quad;
        }
        public void Map1()
        {
            ttt();
            for (int j = 0; j <Pr.Count; j++)
            {
                Quad = new List<Elements>(Pr);
                index = Quad.Count;
                for (int i = 0; i < Kvadr1.Count; i++)
                {
                    CountObject(3, i);
                    Print();    
                }
                Coun.Add(Quad.Count);
               
            }
        }
        public void Render(int i)
        {
            Brevno.Rectangle(Quad[i].x, Quad[i].y, Quad[i].H, Quad[i].W);
            Brevno.Rectangle3(Quad[i].x + ((Pila) / 2), Quad[i].y + ((Pila) / 2), Quad[i].H - Pila, Quad[i].W - Pila);
        }
        public void Render1(int i)
        {
            Brevno.Rectangle3(Quad[i].x, Quad[i].y, Quad[i].H, Quad[i].W);
            Brevno.Rectangle3(Quad[i].x + ((Pila) / 2), Quad[i].y + ((Pila) / 2), Quad[i].H - Pila, Quad[i].W - Pila);
        }
        public void Print()
        {
            for (int i = 0; i < Quad.Count; i++)
            {
               // Render(i);
            }
        }
        public void Print1()
        {
            for (int i = 0; i < Quad.Count; i++)
            {
                //Render1(i);
            }
        }
        public void CreateElemts(int o)
        {
            float h = Quad[o].H -Pila;
            float w = Quad[o].W - Pila;
            Add(h,w);
            Quad[index].flag = false;
            Quad[index].x =0;
            Quad[index].y = 0;
        }
        public bool qqq(float x2, float y2)
        {
            int r=0;
            for (int d = 0; d < Quad.Count; d++)
            {
                float x1 = Quad[d].x + Quad[d].H;
                float y1 = Quad[d].y + Quad[d].W;
                float x0 = Quad[d].x;
                float y0 = Quad[d].y;

                if ((x2 >= x0 && y2 >= y0 && x2 <= x1 && y2 <= y1 && Quad[d].flag))
                {
                    r++;
                }
            }
            if (r == 0) return true;
            else return false;
        }
        public bool Yslov(float x, float y,int z)
        {
           index2 = 0;
            if (index == 0)
            {
                Quad[0].x = x;
                Quad[0].y = y;
                Quad[0].flag =true;
                index++;
                return true;
            }
            for (int t = 0; t < Quad.Count; t++)
            {
                float x1 = Quad[t].x +Quad[t].H;
                float y1 = Quad[t].y +Quad[t].W;
                float x0 = Quad[t].x;
                float y0 = Quad[t].y;
               
                    if ((x >= x0 && y >= y0 && x <= x1 && y <= y1 &&Quad[t].flag))
                    {
                        return true;
                    }
                    else
                    {
                        if ((x + Quad[t].H) <= (Kvadr1[z].H + Kvadr1[z].X0) && qqq((x + Quad[t].H), y) && !Quad[t].flag)
                        {
                            if ((y + Quad[t].W) <= (Kvadr1[z].W + Kvadr1[z].Y0)&&!Quad[t].flag)
                            {
;
                                index2 = t;
                                return false;
                            }
                        }
                    }
                
            }
            return true;
        }
     

        public void CountObject(int p,int k)
        {
            CreateElemts(p);
            for (float i = Kvadr1[k].Y0; i < (Kvadr1[k].W + Kvadr1[k].Y0); i += 0.5f)
            {
                for (float j = Kvadr1[k].X0; j < (Kvadr1[k].H + Kvadr1[k].X0); j += 0.5f)
                {
                   // if (index == 20) return;
                    if (Yslov(j, i,k)) 
                        continue;
                    else
                    {
                        Quad[index].x = j;
                        Quad[index].y = i;
                        Quad[index].flag = true;
                        Render(index);
                       // Thread.Sleep(100);
                        index++;
                        CreateElemts(p);
                    }
                }
            }
            
        }
        public void Search(int k)
        {
            for (float i = Kvadr1[k].Y0; i < (Kvadr1[k].W + Kvadr1[k].Y0); i += 0.5f)
            {
                for (float j = Kvadr1[k].X0; j < (Kvadr1[k].H + Kvadr1[k].X0); j += 0.5f)
                {
                    if (index == Quad.Count) return;
                    if (Yslov(j, i,k)) continue;
                    else
                    {
                        Quad[index2].x = j;
                        Quad[index2].y = i;
                        Quad[index2].flag = true;
                        Render(index2);
                        Thread.Sleep(100);
                        index++;
                       // Render(index2);
                       // Thread.Sleep(200);
                    }
                }
            }
        }
       
    }
}
