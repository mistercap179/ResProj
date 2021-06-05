using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WriterClass
{
    class Program
    {
        static void Main(string[] args)
        {

            Writer writer = new Writer();
            Thread t1 = new Thread(writer.Slanje);
            Thread t2 = new Thread(writer.PaliGasiWorkera);
            t1.Start();
            t2.Start();
        }
    }
}
