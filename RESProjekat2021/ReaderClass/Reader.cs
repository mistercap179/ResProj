using System;
using System.Collections.Generic;
using RESProjekat2021.Class_Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerClass;
using DataBase;
using System.Globalization;
using System.Threading;
using LoggerClass;

namespace ReaderClass
{
    
    class Reader
    {
        public Reader()
        {
            Worker = new Worker();
          
        }
        public Worker Worker;
        public Logger Logger = new Logger();

        public  static CollectionDescription test1 = new CollectionDescription();
        

        static void Main(string[] args)
        {
           
        string exit = "";
            while (exit != "N")
            {
                Console.WriteLine("DateTime FORMAT: [MM/dd/yyyy HH:mm:ss]");
                Console.WriteLine("Unesite DateTime1: ");
                string datum1 = Console.ReadLine();
                DateTime d1 = DateTime.ParseExact(datum1, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                Console.WriteLine("Unesite DateTime2: ");
                string datum2 = Console.ReadLine();
                DateTime d2 = DateTime.ParseExact(datum2, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                Console.WriteLine("Koji Worker zelite da iscitate[1-4]:");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Za koji kod zelite da citate[1-8]");
                int code = Int32.Parse(Console.ReadLine());
                Console.WriteLine("DT1: " + d1.ToString());
                Console.WriteLine("DT2: " + d2.ToString());

                Logger.PoslatiPodaciZaReader(d1, d2, code, id);
                test1 = Worker.slanjeWorkeru(d1, d2, id, code);
                

                for (int i = 0; i < test1.HistoricalCollection.listaWorkerPropertys.Count; i++)
                {
                    Console.WriteLine("\n\nDataset : {0}\nCode : {1}\nValue : {2}\nTimeStamp : {3}", test1.DataSet, test1.HistoricalCollection.listaWorkerPropertys[i].Code, test1.HistoricalCollection.listaWorkerPropertys[i].WorkerValue, test1.HistoricalCollection.listaWorkerPropertys[i].TimeStamp);
                }
                Console.WriteLine("Da li zelite nastaviti [Y/N]");
                exit = Console.ReadLine();
            }


       }
    }
}
