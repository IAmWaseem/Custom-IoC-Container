using DIP.Abstractions;
using DIP.MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.HighLevelModule
{
    public class Copy
    {
        private Container _container;
        private IReader _reader;
        private IWriter _writer;

        public Copy(Container container)
        {
            _container = container;
            _reader = _container.Resolve<IReader>();
            _writer = _container.Resolve<IWriter>();
            Console.WriteLine(string.Format("Reader Created On: {0}.", _reader.GetCreatedOn()));
            Console.WriteLine(string.Format("Writer Created On: {0}.", _writer.GetCreatedOn()));
        }

        public void DoCopy()
        {
            string stData = _reader.Read();
            _writer.Write(stData);
        }
    }
}
