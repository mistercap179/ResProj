using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerClass;

namespace LoadBalancerClass
{
    public class LoadBalancer
    {
        public List<Description> listaDescriptiona = new List<Description>();
        public List<Item> privremenaListItema = new List<Item>();
        public Worker worker = new Worker(); 
        public void PorukaOdWritera(int id,int code,int value)//,bool worker1,bool worker2,bool worker3,bool worker4)
        {
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
            worker.PorukaOdLoadBalancera(listaDescriptiona);
        }
    }
}
