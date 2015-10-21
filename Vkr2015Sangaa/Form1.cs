using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vkr2015Sangaa
{
    public partial class Form1 : Form
    {
        Image Picture ;
        brevno Kryg;
        Rascroi one;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float r = Convert.ToSingle(textBox1.Text);
            Kryg = new brevno(r);
            Kryg.Create();

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            one = new Rascroi(Convert.ToSingle(textBox2.Text),Kryg.Kvadr);
            for (int i = 0; i < dataGridView1.RowCount -1; i++)
            {
                one.Add(Convert.ToSingle(dataGridView1.Rows[i].Cells[0].Value), Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value));
            }
            one.Sort();
            one.Map();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Picture = Image.GetInstance(); 
            Picture.Create();
            this.Controls.Add(Picture.Map);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
