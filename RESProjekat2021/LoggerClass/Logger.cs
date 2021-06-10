using System;
using System.Collections.Generic;
using RESProjekat2021.Class_Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoggerClass
{
    public class Logger : ILogger
    {
        public bool PorukaWritera(int id, int code, int value)
        {
            string s = ""; 
            s = "\nWriter je poslao sledece podatke LoadBalanceru: id-" + id + ", code:" + code + ", value:" + value;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        public bool PoslatiPodaciZaReader(DateTime d1, DateTime d2,int code)
        {
            string s = "";
            s = "\nReader je poslao sledece podatke workeru: Vremenski interval od:" + d1.ToString() + " do " + d2.ToString() + "Ispisati podatke za Kod: " + code;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        public bool PrimljeniPodaciZaReader(CollectionDescription cd)
        {
            string s = "";
            s = "\nWorker je poslao sledece podatke readeru: dataset: " + cd.DataSet + " code: " + cd.HistoricalCollection.listaWorkerPropertys[0].Code + " value: " + cd.HistoricalCollection.listaWorkerPropertys[0].WorkerValue + " timestamp: " + cd.HistoricalCollection.listaWorkerPropertys[0].TimeStamp;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        public bool UgasiWorkerZahtjev()
        {
            string s = "";
            s = "\nWriter salje LoadBalanceru zahtjev da ugasi workera.";
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }
        public bool UpaljenWorker(int i)
        {
            string s = "";
            s = "\nLoadBalancer je upalio worker-a i broj upaljenih workera je: " + i;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }
        public bool NijeUpaljenWorker(int i)
        {
            string s = "";
            s = "\nLoadBalancer nije uspio upaliti worker-a i broj upaljenih workera je: " + i;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }
        public bool NijeUgasenWorker(int i)
        {
            string s = ""; 
            s = "\nLoadBalancer nije uspio ugasiti worker-a i broj upaljenih workera je: " + i;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }
        public bool UgasenWorker(int i)
        {
            string s = ""; s = "\nLoadBalancer je ugasio worker-a i broj upaljenih workera je: " + i;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        public bool UpaliWorkerZahtjev()
        {
            string s = "";
            s = "\nWriter salje LoadBalanceru zahtjev da upali workera.";
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        public bool UpisUBazu(int dataset, CodeEnum code, CodeEnum code1, int value, int value1)
        {
            string s = "";
            s = "\nUpisani podaci u bazu [DataSet" + dataset + "]. \nKod prvog upisanog: " + code + "   Vrijednost prvog upisanog: " + value + " \nKod drugog upisanog: " + code1 + "   Vrijednost drugog upisanog: " + value1 ;
            if (s == "")
            {
                return false;
            }
            UpisiUFajl(s);
            return true;
        }

        

        public void UpisiUFajl(string poruka)//upis u fajl
        {
            string putanja = "C:\\Users\\Sinisa\\Documents\\GitHub\\ResProj\\RESProjekat2021\\Logger\\Logger.txt";
            FileStream stream = new FileStream(putanja, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream); 
            sw.WriteLine(poruka);
            sw.Close();
            stream.Close();
        }
    }
}
