using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIP.Abstractions;

namespace DIP.Implementation
{
    public class PrinterWriter : IWriter
    {
        private DateTime _createdOn;

        public PrinterWriter()
        {
            _createdOn = DateTime.Now;
        }

        public void Write(string data)
        {
            Console.WriteLine(string.Format("Writing to \"Printer\": [{0}]", data));
        }

        public DateTime GetCreatedOn()
        {
            return _createdOn;
        }
    }
}
