using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Management_System.ServiceReference1;

namespace Client_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            clientC c = new clientC()
            {
                UserId = Convert.ToInt32(txt_UserId.Text),
            };
            Service1Client service = new Service1Client();

            if (service.deleteClient(c) == 1)
            {
                MessageBox.Show("Client Successfully Deleted");
                txt_UserId.Clear();
            }
        }

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            clientC c = new clientC()
            {
                UserId = Convert.ToInt32(txt_UserId.Text),
                name = txt_Name.Text,
                gender = txt_Gender.Text,
                ResidentialAdd = txt_Resad.Text,
                WorkAdd = txt_WAdd.Text,
                PostalAdd = txtPAdd.Text,
                mobileNumber = txt_CellNum.Text,
                workNumber = txt_WWork.Text

            };
            Service1Client service = new Service1Client();

            if (service.updateClient(c) == 1)
            {
                MessageBox.Show("Client Successfully Updated");
                txt_UserId.Clear();
                txt_Name.Clear();
                txt_Gender.Clear();
                txt_Resad.Clear();
                txt_WAdd.Clear();
                txtPAdd.Clear();
                txt_CellNum.Clear();
                txt_WWork.Clear();

            }
        }
    }
}
