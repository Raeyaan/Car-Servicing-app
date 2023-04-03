using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace F6SFBU_sec
{
    public partial class Worksheet : Form
    {

        public int hourmin = 0;
        public int Hourmin
        {
            get { return hourmin; } 
            set { hourmin = value; } 
        }
        public  int timeCost = 0;
        public  int TimeCost
        {
            get { return timeCost; }
            set { timeCost = value; }

        }
        public  int totalWorks = 0;
        public  int TotalWorks
        {
            get { return totalWorks; }
            set { totalWorks = value; }

        }
        public  int totlaMatcost = 0;
        public  int TotlaMatcost
        {
            get { return totlaMatcost; }
            set { totlaMatcost = value; }

        }
        public  int total = 0;
        public  int Total
        {
            get { return total; }
            set { total = value; }
        }
       
        private List<Label> totalCost = new List<Label>();
        private List<Label> labels = new List<Label>();
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        //Controls
        int dist = 10, disty = 50, lbltime = 0, lblMat = 0, lbltotal = 0, numWorksheet = 0;
        public Worksheet()
        {
            InitializeComponent();
        }
        internal static ElementsCalculator RegisteredSheet  = new ElementsCalculator();
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult reg = MessageBox.Show("Are you sure you want to register", "Registration", messageBoxButtons, MessageBoxIcon.Question);
            if(reg  == DialogResult.Yes)
            {
                numWorksheet++;
                RegisteredSheet.Rw += TotalWorks;
                RegisteredSheet.Mc += TotlaMatcost;
                RegisteredSheet.Tc += TimeCost;
                RegisteredSheet.Tot += Total;
                RegisteredSheet.Hm += Hourmin;
                RegisteredSheet.NumW += numWorksheet;
                this.Close();
            }
            else if(reg == DialogResult.No)
            {
                return;
            }
            

            
           
        }

        internal void CreateLayout(List<Work> workSheet)
        {


            Label label;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label titleCost = new Label();
            Label titleTime = new Label();
            Label titleTotal = new Label();
            CheckBox checkBox;
            Form1.workSheet = workSheet;
            titleCost.Location = new Point(dist + 200, disty - 30);
            titleCost.Text = "Time";
            panel1.Controls.Add(titleCost);
            titleTime.Location = new Point(dist + 100, disty - 30);
            titleTime.Text = "Cost";
            panel1.Controls.Add(titleTime);
            titleTotal.Location = new Point(dist + 400, disty - 30);
            titleTotal.Text = "Time Cost p/m ";
            panel1.Controls.Add(titleTotal);

            for (int i = 0; i < workSheet.Count; i++)
            {
               //TextBox
                label = new Label();
                label2 = new Label();
                label3 = new Label();
                label4 = new Label();
                label5 = new Label();
                label.Location = new Point(dist, disty * (i + 1));
                label.Text = workSheet[i].ServiceName;
                label2.Location = new Point(label.Location.X + 100, disty * (i + 1));
                label2.Text = workSheet[i].MaterialCosts.ToString();
                label3.Location = new Point(label.Location.X + 200, disty * (i + 1));
                label3.Text = workSheet[i].Time.ToString();                
                //RadioButton
                checkBox = new CheckBox();

                checkBox.Location = new Point(label.Location.X + 300, disty * (i + 1));
                Label total = new Label();
                total.Location = new Point(label.Location.X + 400, disty * (i + 1));
                total.Text = "";

               

                labels.Add(label);
                labels.Add(label2);
                labels.Add(label3);
                labels.Add(label4);
                labels.Add(label5);
                checkBoxes.Add(checkBox);
                totalCost.Add(total);
                panel1.Controls.Add(checkBox);
                panel1.Controls.Add(total);
                panel1.Controls.Add(label);
                panel1.Controls.Add(label2);
                panel1.Controls.Add(label3);
                panel1.Controls.Add(label4);
                panel1.Controls.Add(label5);
                checkBox.CheckStateChanged += new EventHandler(Allcosts);
            }          
        }      
        private void Allcosts(object sender, EventArgs e)
        {
            lbltime = 0;
            lblMat = 0;
            lbltotal = 0;
            int Numberofworks = 0;
            int lblHourmin = 0; 
            
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked == true)
                {
                    Numberofworks++;
                    lblMat += Form1.workSheet[i].MaterialCosts;
                    lbltime += Form1.workSheet[i].Timeofcost;                 
                    lbltotal = Form1.workSheet[i].Totalcost;
                    totalCost[i].Text = lbltotal.ToString();
                    lblHourmin += Form1.workSheet[i].Time;
                }                
                else
                 {
                        totalCost[i].Text = "";
                 }                             
            }
            TotalWorks = Numberofworks;
            Hourmin = lblHourmin;
            TimeCost = lbltime;
            TotlaMatcost = lblMat;
            Total = lblMat + lbltime;
            label2.Text = TotlaMatcost.ToString();
            label4.Text = TimeCost.ToString();           
        }

     
    }
}
