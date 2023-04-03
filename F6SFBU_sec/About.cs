using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F6SFBU_sec
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        internal void Labels()
        {
            label1.Text = "Raeyaan Shahid";
            label2.Text = DateTime.Now.ToString();

        } 


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Controls.Add(button1);


        }
    }
}
