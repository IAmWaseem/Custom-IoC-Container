using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Abstractions
{
    public interface IReader
    {
        DateTime GetCreatedOn();
        string Read();   
    }
}
