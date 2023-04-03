using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F6SFBU_sec
{
    public class WorkParser : Loader
    {

        public List<T> LoadFile<T>(string fileName)
        {
            StreamReader streamReader ;
            List<Work> works = new List<Work>();
            try
            {

                 streamReader = new StreamReader( fileName);
                string line = "";
                string[] parts;
                while ((line = streamReader.ReadLine()) != null)
                {
                  
                    parts = line.Split(';');

                    works.Add(new Work(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
                }
                streamReader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
           
            return new List<T>(works as IEnumerable<T> ?? throw new InvalidOperationException());

        }
    }
}
