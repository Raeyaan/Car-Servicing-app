using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F6SFBU_sec
{
    public partial class Payment : Form
    {      
        public Payment()
        {
            InitializeComponent();
        }

         


        private  void Payment_Load(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.FromMinutes(Worksheet.RegisteredSheet.Hm);
            string HM2 = string.Format("{0} Hours {1} Minutes", ts.Hours, ts.Minutes);
            label1.Text = "Work Count";
            label2.Text = Worksheet.RegisteredSheet.Rw.ToString();
            label2.ForeColor = Color.Orange;
            label4.Text = Worksheet.RegisteredSheet.Mc.ToString();
            label4.ForeColor = Color.DarkTurquoise;
            label3.Text = "Material Cost";
            label6.Text = Worksheet.RegisteredSheet.Tc.ToString();
            label5.Text = "Service Cost";
            label6.ForeColor = Color.MediumVioletRed;
            label8.Text = Worksheet.RegisteredSheet.Tot.ToString();
            label7.Text = "Total";
            label8.ForeColor = Color.Gray;
            label10.Text = HM2;
            label10.ForeColor = Color.Chartreuse;
            label9.Text = "Time";
            label11.Text = "Worksheets";
            label12.Text = Worksheet.RegisteredSheet.NumW.ToString();
            label12.ForeColor = Color.Tomato;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons more = MessageBoxButtons.YesNo;
            DialogResult payment = MessageBox.Show("Do you want to add more services", "Payment", more, MessageBoxIcon.Exclamation);
            if(payment  == DialogResult.Yes)
            { 
                Payment p = new ();
                Worksheet sheet = new();
                this.Close();
                sheet.CreateLayout(Form1.workSheet);
                sheet.ShowDialog();
                p.Show();
                
                
              
                

            }
            if(payment == DialogResult.No) 

            {
                           
                this.Close();
                MessageBox.Show("Payment Successful!!", "Success");
                
                
                
            }

        }
    
    }
}
