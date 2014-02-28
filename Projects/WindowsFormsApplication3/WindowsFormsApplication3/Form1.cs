using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                   
                    Button b = new Button();
                   b.Left = i;
                    b.Top = j;
                    b.Text = string.Format("{0} + {1}", i, j);
                    
                    this.Controls.Add(b);
                    
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.Columns.Add("0", "0");
            for (int i = 0; i < 10; i++)
            {
            
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
            }
    }
}
