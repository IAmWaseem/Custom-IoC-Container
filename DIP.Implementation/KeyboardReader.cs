using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIP.Abstractions;

namespace DIP.Implementation
{
    public class KeyboardReader : IReader
    {

        private DateTime _createdOn;

        public KeyboardReader()
        {
            _createdOn = DateTime.Now;
        }

        public string Read()
        {
            return "Reading from \"Keyboard\"";
        }

        public DateTime GetCreatedOn()
        {
            return _createdOn;
        }
    }
}
