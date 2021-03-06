using RESProjekat2021.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerClass;
using LoggerClass;

namespace LoadBalancerClass
{
    public class LoadBalancer : ILoadBalancer
    {
        public List<Description> listaDescriptiona = new List<Description>();
        public List<Item> privremenaListItema = new List<Item>();

        public List<Worker> workers = new List<Worker>() { new Worker(),new Worker()};
        public int i = 0;
        public Logger Logger = new Logger();
        //public Worker worker = new Worker(); 
        public void PorukaOdWritera(int id,int code,int value)//,bool worker1,bool worker2,bool worker3,bool worker4)
        {
            Logger.PorukaWritera(id, code, value);
            Item item = new Item(code,value);                                           //writer item
            privremenaListItema.Add(item);                                                                      

            int dataset = 0;
            if (code == 1 || code == 2)
            {
                dataset = 1;
            }
            else if(code == 3 || code == 4)
            {
                dataset = 2;
            }
            else if(code == 5 || code == 6)
            {
                dataset = 3;
            }
            else if(code == 7 || code == 8)
            {
                dataset = 4;
            }

            Description description = new Description(dataset,id,privremenaListItema);
            listaDescriptiona.Add(description);
            RoundRobin();
            
        }


        public void RoundRobin()
        {
            if (workers.Count == 1)
            {
                i = 0;
            }

            if (i < workers.Count())
            {
                workers[i].PorukaOdLoadBalancera(listaDescriptiona);
            }

            if (workers.Count > i + 1)
            {
                i++;
            }
            else if (workers.Count <= i + 1)
            {
                i = 0;
            }
      
        }
/*
        public int Index()
        {
            if(workers.Count == 1)
            {
                i = 0;
            }
            if(workers.Count > i + 1)
            {
                i++;
            }
            else if(workers.Count <= i + 1)
            {
                i = 0;
            }

            return i;
        }
        */

        public bool UpaliW()
        {
            if(workers.Count + 1 <= 4)
            {

                workers.Add(new Worker());
                Console.WriteLine("Upalili ste novog workera!");
                Logger.UpaljenWorker(workers.Count);
                return true;
            }
            else
            {
                Console.WriteLine("Ne moze vise od 4 workera!");
                Logger.NijeUpaljenWorker(workers.Count);
                return false;
            }
        }
        public bool UgasiW()
        {
            if(workers.Count == 1)
            {
                Console.WriteLine("Poslednji worker se ne moze biti ugasen!");
                Logger.NijeUgasenWorker(workers.Count);
                return false;
            }
            else
            {
                workers.RemoveAt(workers.Count - 1);
                Console.WriteLine("Ugasili ste workera!");
                Logger.UgasenWorker(workers.Count);
                return true;
            }

        }

    }
}
