using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerClass
{
    public class Worker
    {
        /*
        WorkerProperty worker1 = new WorkerProperty(CodeEnum.CODE_ANALOG,100,DateTime.Now);
        WorkerProperty worker2 = new WorkerProperty(CodeEnum.CODE_DIGITAL, 200, DateTime.Now);
        HistoricalCollection historicalCollection = new HistoricalCollection();
        CollectionDescription collectionDescription = new CollectionDescription();
        public void Upis()
        {
            historicalCollection.listaWorkerPropertys = new List<WorkerProperty>();

            historicalCollection.listaWorkerPropertys.Add(worker1);
            historicalCollection.listaWorkerPropertys.Add(worker2);

            collectionDescription.DataSet = 1;
            collectionDescription.ID = 2;
            collectionDescription.HistoricalCollection= new HistoricalCollection();

            collectionDescription.HistoricalCollection.listaWorkerPropertys = historicalCollection.listaWorkerPropertys;
            
            PristupBazi.UpdateDBperDataSet(collectionDescription);
            
        }
        */
        public void PorukaOdLoadBalancera(List<Description> descriptions)
        {
            try
            {
                if (descriptions == null)
                {
                    throw new Exception();
                }

                CollectionDescription collectionDescription = new CollectionDescription();

                foreach(Description description in descriptions)
                {
                    HistoricalCollection historicalCollection = new HistoricalCollection();
                    historicalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                    foreach (Item item in description.ListaItema)
                    {
                        WorkerProperty workerProperty = new WorkerProperty();
                        workerProperty.Code = item.Code;
                        workerProperty.WorkerValue = item.Value;
                        workerProperty.TimeStamp = DateTime.Now;
                       //historicalCollection.listaWorkerPropertys=new List<WorkerProperty>();
                       // HistoricalCollection historicalCollection = new HistoricalCollection();                         // prepakivanje
                        historicalCollection.listaWorkerPropertys.Add(workerProperty);

                        collectionDescription.ID = description.Id;
                        collectionDescription.DataSet = description.DataSet;
                        collectionDescription.HistoricalCollection = historicalCollection;
                    }
                }

                PristupBazi.UpdateDBperDataSet(collectionDescription);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
