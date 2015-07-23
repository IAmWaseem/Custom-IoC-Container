using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Abstractions
{
    public interface IWriter
    {
        DateTime GetCreatedOn();
        void Write(string data);
    }
}
