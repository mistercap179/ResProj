using LoadBalancerClass;
using RESProjekat2021.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WriterClass
{
    public class Writer : IWriter
    {
        public Writer()
        {
             LoadBalancer= new LoadBalancer();
        }
        //public PaljenjeGasenje paljenjeGasenje = new PaljenjeGasenje();        // ili u okviru while-a
        public LoadBalancer LoadBalancer;// = new LoadBalancer(); 
        
        public void Slanje() // thread 1
        {
            int id = 0;
            while (true)
            {
                try
                {
                    int code = RandomBroj(1, 9);                // 9 jer ne uzima u obzir gornju granicu
                    if(code == 2)                               // za digitalne
                    {
                        int value = RandomBroj(0, 2);
                        LoadBalancer.PorukaOdWritera(id, code, value);//, paljenjeGasenje.upaljenWorker1, paljenjeGasenje.upaljenWorker2, paljenjeGasenje.upaljenWorker3, paljenjeGasenje.upaljenWorker4);
                    }
                    else
                    {
                        int value = RandomBroj(0, 1001);         // ostali signali
                        LoadBalancer.PorukaOdWritera(id, code, value);//, paljenjeGasenje.upaljenWorker1, paljenjeGasenje.upaljenWorker2, paljenjeGasenje.upaljenWorker3, paljenjeGasenje.upaljenWorker4);
                    }

                    id++;
                    
                    Thread.Sleep(2000);     // na svake dvije sekunde 

                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        public int RandomBroj(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void PaliGasiWorkera() // thread 2
        {
            while (true)//slanje podataka ka Load Balanceru
            {
                Console.WriteLine("Sta zelite da radite?");
                Console.WriteLine("1. Upali novi Worker.");
                Console.WriteLine("2. Ugasi postojeci Worker.");
                Console.Write("Vas odgovor: ");
                int caseSwitch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==================================");

                switch (caseSwitch)
                {
                    case 1:
                        //UpaliWorker();
                        UpaliWorkera();
                        Console.WriteLine("==================================");
                        break;

                    case 2:
                        //UgasiWorker();
                        UgasiWorkera();
                        Console.WriteLine("==================================");
                        break;
                }
            }
        }

        public bool UpaliWorkera()
        {
            bool stanje = LoadBalancer.UpaliW();
            return stanje;
        }

        public bool UgasiWorkera()
        {
            bool stanje = LoadBalancer.UgasiW();
            return stanje;
        }

    }
}
