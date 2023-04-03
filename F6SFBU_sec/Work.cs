using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace F6SFBU_sec
{

     public class Work
    {

        public int MaterialCosts { get; set; }


        public int Time { get; set; }
        public int Costoftime { get; set; }

        public int Workhourcost = 15000;
        public string ServiceName { get; set; }

        public int Totalcost { get { return Time * 250; } }

        public Work(string serviceName, int time, int materialCosts)
        {
            ServiceName = serviceName ?? throw new ArgumentNullException(nameof(serviceName));
            Time = time;
            MaterialCosts = materialCosts;
        }
        public int Timeofcost
        { get
            { 
            if (Time > 30)
            {

                if (Time % 30 == 0)
                {
                    Costoftime = (Time / 30) * 7500;

                }
                else
                {
                    Costoftime = (Time / 30) * 7500 + 7500;

                }

            }



            if (Time < 30)
             {
                    if (Time != 0)
                    {
                        Costoftime = 7500;
                    }

                    else
                    {
                        Costoftime = 0;
                    }
             }
            if(Time == 30) { Costoftime = 7500; }  


                return Costoftime; }

           


        }


 
     } 
}
