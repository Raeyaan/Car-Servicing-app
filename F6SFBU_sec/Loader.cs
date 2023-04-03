using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F6SFBU_sec
{
    public interface Loader
    {
        List<T> LoadFile<T>(string filepath);
    }
}
