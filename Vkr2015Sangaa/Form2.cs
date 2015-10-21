using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Vkr2015Sangaa
{
    public partial class Form2 : Form
    {
        Image Picture;
        brevno Kryg;
        Rascroi one;
        public Form2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            openFileDialog1.Filter = "Data files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] NewFile = File.ReadAllLines(openFileDialog1.SafeFileName);
                int count = 0;
                foreach (string str in NewFile)
                {
                    label3.Text +=" "+ str;
                    if (count > 1)
                    {
                        string[] s = str.Split(' ');
                        dataGridView1.Rows.Insert(count - 2, s[0], s[1]);
                        count++;
                    }
                    if (count == 1)
                    {
                        textBox2.Text = str;
                        count++;
                    }
                    if (count == 0)
                    {
                        textBox1.Text = str;
                        count++;
                    }
                    
                    
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите данные, для построения раскроя");
            }
            else
            {
                float r = Convert.ToSingle(textBox1.Text);
                Kryg = new brevno(r);
                Kryg.Create();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            one = new Rascroi(Convert.ToSingle(textBox2.Text), Kryg.Kvadr);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                one.Add(Convert.ToSingle(dataGridView1.Rows[i].Cells[0].Value), Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value));
            }
            one.Sort();
            one.Map();
            //результаты
            one.Map1();
            
            for (int i = 0; i < one.Coun.Count; i++)
            {
                dataGridView2.Rows.Insert(i, i+1,one.Coun[i]);
            }
                
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Picture = Image.GetInstance();
            Picture.Create();
            this.Controls.Add(Picture.Map);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
