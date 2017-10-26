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
using Client_Management_System.ServiceReference1;


namespace Client_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            clientC c = new clientC();
           
            c.name = txt_Name.Text;
            if (rb_Male.Checked)
            {
                c.gender = rb_Male.Text;
            }

            if (radioButton2.Checked)
            {
                c.gender = radioButton2.Text;
            }
            c.ResidentialAdd = txt_ResAddress.Text;
            c.WorkAdd = txtWorkAddress.Text;
            c.PostalAdd = txt_PpostAddress.Text;
            c.mobileNumber = txt_CellNum.Text;
            c.workNumber = txt_wokNum.Text;
          

            Service1Client service = new Service1Client();

            if (service.insertClient(c) == 1)
            {
                MessageBox.Show("Client Successfully Added");
                txt_Name.Clear();   
                rb_Male.Refresh();
                radioButton2.Refresh();
                txt_ResAddress.Clear();
                txtWorkAddress.Clear();
                txt_PpostAddress.Clear();
                txt_CellNum.Clear();
                txt_wokNum.Clear();
                txt_Name.Clear();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<clientC> clients = new List<clientC>();
            Service1Client service = new Service1Client();

            dataGridView1.DataSource = service.getClients();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter("Client_File");
            for(int i = 0; i <dataGridView1.Rows.Count-1;i++)
            {
                writer.Write("Client: " + i);
                writer.Write(" ");
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + ",");
                   
                }
                writer.WriteLine("");
                writer.WriteLine("-----------------------------------------------------------------------------");
            }
            writer.Close();
            MessageBox.Show("Client Data Exported Successfully");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Form2 openForm = new Form2();
            openForm.Show();
            Visible = false;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

