using DIP.Abstractions;
using DIP.HighLevelModule;
using DIP.Implementation;
using DIP.MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            DIRegistration(container);
            Copy copy = new Copy(container);
            copy.DoCopy();

            Console.Read();

            Copy copy2 = new Copy(container);
            copy2.DoCopy();

            Console.Read();
            Console.Read();
        }

        private static void DIRegistration(Container container)
        {
            container.Register<IReader, KeyboardReader>(LifeTimeOptions.ContainerControlledLifeTimeOption);
            container.Register<IWriter, PrinterWriter>(LifeTimeOptions.TransientLifeTimeOption);
        }
    }
}
