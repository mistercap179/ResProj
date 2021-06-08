using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoggerClass
{
    public class Logger
    {
        public void PorukaWritera(int id, int code, int value)
        {
            string s = "Writer je poslao sledece podatke LoadBalanceru: id-" + id + ", code:" + code + ", value:" + value;
            UpisiUFajl(s);
        }

        public static void PoslatiPodaciZaReader(DateTime d1, DateTime d2,int code, int worker)
        {
            string s = "Reader je poslao sledece podatke workeru: Vremenski interval od:" + d1.ToString() + " do " + d2.ToString() + ", broj workera: " + worker + " code: " + code;
            UpisiUFajl(s);
        }

        public static void PrimljeniPodaciZaReader(CollectionDescription cd)
        {
            string s = "Worker je poslao sledece podatke readeru: dataset: " + cd.DataSet + " code: " + cd.HistoricalCollection.listaWorkerPropertys[0].Code + " value: " + cd.HistoricalCollection.listaWorkerPropertys[0].WorkerValue + " timestamp: " + cd.HistoricalCollection.listaWorkerPropertys[0].TimeStamp;
            UpisiUFajl(s);
        }

        public void UgasiWorkerZahtjev()
        {
            string s = "Writer salje LoadBalanceru zahtjev da ugasi workera.";
            UpisiUFajl(s);
        }
        public void UpaljenWorker(int i)
        {
            string s = "LoadBalancer je upalio worker-a i broj upaljenih workera je: " + i;
            UpisiUFajl(s);
        }
        public void NijeUpaljenWorker(int i)
        {
            string s = "LoadBalancer nije uspio upaliti worker-a i broj upaljenih workera je: " + i;
            UpisiUFajl(s);
        }
        public void NijeUgasenWorker(int i)
        {
            string s = "LoadBalancer nije uspio ugasiti worker-a i broj upaljenih workera je: " + i;
            UpisiUFajl(s);
        }
        public void UgasenWorker(int i)
        {
            string s = "LoadBalancer je ugasio worker-a i broj upaljenih workera je: " + i;
            UpisiUFajl(s);
        }

        public void UpaliWorkerZahtjev()
        {
            string s = "Writer salje LoadBalanceru zahtjev da upali workera.";
            UpisiUFajl(s);
        }

        public static void UpisUBazu(int dataset, CodeEnum code, int value)
        {
            string s = "Upisani podaci u bazu [DataSet" + dataset + "]. ";
            UpisiUFajl(s);
        }

        

        public static void UpisiUFajl(string poruka)//ovde ga upisujem u korisnici.txt
        {
            string putanja = "Logger.txt";
            FileStream stream = new FileStream(putanja, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(poruka);
            sw.Close();
            stream.Close();
        }
    }
}
