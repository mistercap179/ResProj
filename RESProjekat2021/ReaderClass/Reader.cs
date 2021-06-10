using System;
using System.Collections.Generic;
using RESProjekat2021.Class_Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerClass;
using System.Globalization;
using System.Threading;
using LoggerClass;

namespace ReaderClass
{
    
    public class Reader : IReader
    {
        public Reader()
        {
            Worker = new Worker();
            Logger = new Logger();
            
        }
        public Worker Worker;

        public Logger Logger;

       
        //public Logger Logger = new Logger();

        public  static CollectionDescription test1 = new CollectionDescription();

        public void slanjeW(DateTime d1, DateTime d2, int code)
        {
            test1 = Worker.slanjeWorkeru(d1, d2, code);

        }
        public void PoslatiZaReader(DateTime d1, DateTime d2, int code)
        {
             Logger.PoslatiPodaciZaReader(d1, d2, code);
        }
        static void Main(string[] args)
        {

            string exit = "";
            while (exit != "N")
            {
                try
                {
                    Console.WriteLine("DateTime FORMAT: [MM/dd/yyyy HH:mm:ss]");
                    Console.WriteLine("Unesite DateTime1: ");
                    string datum1 = Console.ReadLine();
                    DateTime d1 = DateTime.ParseExact(datum1, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    if (d1 == null)
                    {
                        throw new Exception("Pogresno ste unjeli datum");
                    }
                    Console.WriteLine("Unesite DateTime2: ");
                    string datum2 = Console.ReadLine();
                    DateTime d2 = DateTime.ParseExact(datum2, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    if (d2 == null)
                    {
                        throw new Exception("Pogresno ste unjeli datum");
                    }
                   
                    Console.WriteLine("Za koji kod zelite da citate[1-8]");
                    int code = Int32.Parse(Console.ReadLine());
                    if(code < 1 || code > 8)
                    {
                        throw new Exception("Vrijednost koda mora biti u opsegu od 1 do 8");
                    }
                    Console.WriteLine("DT1: " + d1.ToString());
                    Console.WriteLine("DT2: " + d2.ToString());

                    Reader reader = new Reader();
                    reader.PoslatiZaReader(d1, d2, code);
                    reader.slanjeW(d1, d2, code);
                   


                    for (int i = 0; i < test1.HistoricalCollection.listaWorkerPropertys.Count; i++)
                    {
                        Console.WriteLine("\n\nDataset : {0}\nCode : {1}\nValue : {2}\nTimeStamp : {3}", test1.DataSet, test1.HistoricalCollection.listaWorkerPropertys[i].Code, test1.HistoricalCollection.listaWorkerPropertys[i].WorkerValue, test1.HistoricalCollection.listaWorkerPropertys[i].TimeStamp);
                    }

                    while (exit != "N" && exit != "Y")
                    {
                        Console.WriteLine("Da li zelite nastaviti [Y/N]");
                        exit = Console.ReadLine();
                        Console.WriteLine("Niste unjeli Y ili N \n");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }


       }
    }
}
