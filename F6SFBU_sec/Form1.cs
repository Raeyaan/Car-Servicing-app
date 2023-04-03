using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F6SFBU_sec
{
    public  partial class Form1 : Form
    {
        WorkParser Parser = new WorkParser();
        internal static  List<Work> workSheet = new List<Work>();
        public Form1()
        {
            

            InitializeComponent();
            this.CenterToScreen();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;


            Worksheet.Enabled = false;
            Payment.Enabled = false;
        }
        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                workSheet = Parser.LoadFile<Work>(openFileDialog1.FileName);

                /*StreamReader streamReader = null;
                try
                {

                    string fileName = openFileDialog1.FileName;
                    streamReader = new StreamReader(fileName);
                    Input(streamReader);

                    //openMenuItem.Enabled = false;
                    //votingMenuItem.Enabled = true;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
                finally
                {

                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }

                }*/

            }
            openToolStripMenuItem.Enabled = false;
            Worksheet.Enabled = true;
            Payment.Enabled = false; 
        }
        /*private void Input(StreamReader streamReader)
        {
            string test = "";

            string line="";
            string[] data;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();

                data = line.Split(';');
               works.Add(new Work(data[0], int.Parse(data[1]), int.Parse(data[2])));
            }
            
            
        }*/

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Worksheet workForm = new Worksheet();
            workForm.CreateLayout(workSheet);

            workForm.ShowDialog();
            openToolStripMenuItem.Enabled = false;
            Worksheet.Enabled = false;
            Payment.Enabled = true;
        }

        private void About_Click(object sender, EventArgs e)
        {
          About about = new About();
            about.Labels();
            about.ShowDialog(); 
        }

        private void Payment_Click(object sender, EventArgs e)
        {
            Payment paymentform = new Payment();
            paymentform.ShowDialog();
            Payment.Enabled = false;
            openToolStripMenuItem.Enabled = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
       
    }
}
