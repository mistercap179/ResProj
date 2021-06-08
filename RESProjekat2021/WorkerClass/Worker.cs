using DataBase;
using RESProjekat2021.Class_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LoggerClass;


namespace WorkerClass
{
    public class Worker : IWorker
    {
        public CollectionDescription[] DataSet1 { get; set; }
        public CollectionDescription[] DataSet2 { get; set; }
        public CollectionDescription[] DataSet3 { get; set; }
        public CollectionDescription[] DataSet4 { get; set; }

        public Logger Logger = new Logger();

        public Worker()
        {
            this.DataSet1 = new CollectionDescription[2];
            this.DataSet2 = new CollectionDescription[2];
            this.DataSet3= new CollectionDescription[2];
            this.DataSet4 = new CollectionDescription[2];
        }

        public void PorukaOdLoadBalancera(List<Description> descriptions)
        {
            try
            {
                if (descriptions == null)
                {
                    throw new Exception();
                }

                CollectionDescription collectionDescription = new CollectionDescription();
                //HistoricalCollection historicalCollection = new HistoricalCollection();
                foreach (Description description in descriptions)
                {
                    //HistoricalCollection historicalCollection = new HistoricalCollection();
                    //historicalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                    foreach (Item item in description.ListaItema)
                    {
                        WorkerProperty workerProperty = new WorkerProperty();
                        workerProperty.Code = item.Code;
                        workerProperty.WorkerValue = item.Value;
                        workerProperty.TimeStamp = DateTime.Now;
                        //historicalCollection.listaWorkerPropertys=new List<WorkerProperty>();
                        // HistoricalCollection historicalCollection = new HistoricalCollection();                         // prepakivanje
                        //historicalCollection.listaWorkerPropertys.Add(workerProperty);
                        HistoricalCollection historicalCollection = new HistoricalCollection();
                        historicalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                        historicalCollection.listaWorkerPropertys.Add(workerProperty);

                        collectionDescription.ID = description.Id;
                        collectionDescription.DataSet = description.DataSet;
                        collectionDescription.HistoricalCollection = historicalCollection;
                    }
                }

                ProvjeraUpisa(collectionDescription);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void ProvjeraUpisa(CollectionDescription collectionDescription)
        {

            CodeEnum collectionCODE = collectionDescription.HistoricalCollection.listaWorkerPropertys[0].Code;

            if(collectionDescription.DataSet == 1)
            {
                if(CodeEnum.CODE_ANALOG == collectionCODE)
                {
                    DataSet1[0] = collectionDescription;
                }
                else if(CodeEnum.CODE_DIGITAL == collectionCODE)
                {
                    DataSet1[1] = collectionDescription;
                }
            }

            else if (collectionDescription.DataSet == 2)
            {
                if(CodeEnum.CODE_CUSTOM == collectionCODE)
                {
                    DataSet2[0] = collectionDescription;
                }
                else if(CodeEnum.CODE_LIMITSET == collectionCODE)
                {
                    DataSet2[1] = collectionDescription;
                }
            }

            else if (collectionDescription.DataSet == 3)
            {
                if(CodeEnum.CODE_SINGLENODE == collectionCODE)
                {
                    DataSet3[0] = collectionDescription;
                }
                else if(CodeEnum.CODE_MULTIPLENODE == collectionCODE)
                {
                    DataSet3[1] = collectionDescription;
                }
            }
            else if (collectionDescription.DataSet == 4)
            {
                if(CodeEnum.CODE_CONSUMER == collectionCODE)
                {
                    DataSet4[0] = collectionDescription;
                }
                else if(CodeEnum.CODE_SOURCE == collectionCODE)
                {
                    DataSet4[1] = collectionDescription;
                }
            }

            if(DataSet1[0] != null && DataSet1[1] != null)
            {
                CollectionDescription collectionDescription1 = new CollectionDescription();
                collectionDescription1.DataSet = DataSet1[0].DataSet;
                collectionDescription1.ID = DataSet1[0].ID;
                collectionDescription1.HistoricalCollection = new HistoricalCollection();
                collectionDescription1.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                collectionDescription1.HistoricalCollection.listaWorkerPropertys.Add(DataSet1[0].HistoricalCollection.listaWorkerPropertys[0]);
                collectionDescription1.HistoricalCollection.listaWorkerPropertys.Add(DataSet1[1].HistoricalCollection.listaWorkerPropertys[0]);   
                PristupBazi.DodajUBazu(DeadBand(collectionDescription1));
                DataSet1[0] = null;
                DataSet1[1] = null;
            }

            if(DataSet2[0] != null && DataSet2[1] != null)
            {
                CollectionDescription collectionDescription2 = new CollectionDescription();
                collectionDescription2.DataSet = DataSet2[0].DataSet;
                collectionDescription2.ID = DataSet2[0].ID;
                collectionDescription2.HistoricalCollection = new HistoricalCollection();
                collectionDescription2.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                collectionDescription2.HistoricalCollection.listaWorkerPropertys.Add(DataSet2[0].HistoricalCollection.listaWorkerPropertys[0]);
                collectionDescription2.HistoricalCollection.listaWorkerPropertys.Add(DataSet2[1].HistoricalCollection.listaWorkerPropertys[0]);

                PristupBazi.DodajUBazu(DeadBand(collectionDescription2));
                DataSet2[0] = null;
                DataSet2[1] = null;
            }

             if (DataSet3[0] != null && DataSet3[1] != null)
            {
                CollectionDescription collectionDescription3 = new CollectionDescription();
                collectionDescription3.DataSet = DataSet3[0].DataSet;
                collectionDescription3.ID = DataSet3[0].ID;
                collectionDescription3.HistoricalCollection = new HistoricalCollection();
                collectionDescription3.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                collectionDescription3.HistoricalCollection.listaWorkerPropertys.Add(DataSet3[0].HistoricalCollection.listaWorkerPropertys[0]);
                collectionDescription3.HistoricalCollection.listaWorkerPropertys.Add(DataSet3[1].HistoricalCollection.listaWorkerPropertys[0]);
                PristupBazi.DodajUBazu(DeadBand(collectionDescription3));
                DataSet3[0] = null;
                DataSet3[1] = null;
            }
             
             if(DataSet4[0] != null && DataSet4[1] != null)
            {
                CollectionDescription collectionDescription4 = new CollectionDescription();
                collectionDescription4.DataSet = DataSet4[0].DataSet;
                collectionDescription4.ID = DataSet4[0].ID;
                collectionDescription4.HistoricalCollection = new HistoricalCollection();
                collectionDescription4.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();
                collectionDescription4.HistoricalCollection.listaWorkerPropertys.Add(DataSet4[0].HistoricalCollection.listaWorkerPropertys[0]);
                collectionDescription4.HistoricalCollection.listaWorkerPropertys.Add(DataSet4[1].HistoricalCollection.listaWorkerPropertys[0]);
                PristupBazi.DodajUBazu(DeadBand(collectionDescription4));
                DataSet4[0] = null;
                DataSet4[1] = null;
            }
        }


        public CollectionDescription DeadBand(CollectionDescription cd)
        {
            CollectionDescription povratni = new CollectionDescription();
            povratni.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();

            try
            {
                if (cd == null)
                {
                    throw new Exception();
                }

                povratni.DataSet = cd.DataSet;
                povratni.ID = cd.ID;

                List<WorkerProperty> workers = PristupBazi.GetWorkerProperties(); //iz baze

                WorkerProperty wp1 = cd.HistoricalCollection.listaWorkerPropertys[0]; // nove 
                WorkerProperty wp2 = cd.HistoricalCollection.listaWorkerPropertys[1];
                int br = 0;

                foreach (WorkerProperty wp in workers)
                {
                    if (wp.Code == wp1.Code)
                    {
                        br++;

                        if ((wp1.WorkerValue > PristupBazi.NadjiMaxPoCode((int)wp.Code) * 1.02) || wp1.Code == CodeEnum.CODE_DIGITAL)
                        {
                            povratni.DataSet = cd.DataSet;
                            povratni.ID = cd.ID;
                            povratni.HistoricalCollection.listaWorkerPropertys.Add(wp1);
                            break;
                        }
                        else
                        {
                            povratni.DataSet = cd.DataSet;
                            povratni.ID = cd.ID;
                            povratni.HistoricalCollection.listaWorkerPropertys.Add(wp);
                            break;
                        }
                    }
                }

                if (br == 0)
                {
                    povratni.HistoricalCollection.listaWorkerPropertys.Add(wp1);
                }


                br = 0;
                foreach (WorkerProperty wp in workers)
                {
                    if(wp.Code == wp2.Code)
                    {
                        br++;
                        if ((wp2.WorkerValue > PristupBazi.NadjiMaxPoCode((int)wp.Code) * 1.02)||wp2.Code==CodeEnum.CODE_DIGITAL)
                        { 
                            povratni.DataSet = cd.DataSet;
                            povratni.ID = cd.ID;
                            povratni.HistoricalCollection.listaWorkerPropertys.Add(wp2);
                            break;
                        }
                        else
                        {
                            povratni.DataSet = cd.DataSet;
                            povratni.ID = cd.ID;
                            povratni.HistoricalCollection.listaWorkerPropertys.Add(wp);
                            break;
                        }
                    }
                }
                if (br == 0)
                {
                    povratni.HistoricalCollection.listaWorkerPropertys.Add(wp2);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return povratni;
        }
       // public void SlanjeReaderu(CollectionDescription cd) { }
        public static CollectionDescription slanjeWorkeru(DateTime d1, DateTime d2, int id, int code)
        {
            int i = 1;
            CollectionDescription povratniZaReadera = new CollectionDescription();
            List<WorkerProperty> workers = PristupBazi.GetWorkerProperties();
            foreach (WorkerProperty wp in workers)
            {
                if((int)wp.Code == code)
                {
                    if(wp.TimeStamp > d1 && wp.TimeStamp < d2)
                    {
                        povratniZaReadera.DataSet = ((int)(wp.Code) + 1) / 2;
                        povratniZaReadera.HistoricalCollection.listaWorkerPropertys.Add(wp);
                    }
                }
                i++;
            }
            Logger.PrimljeniPodaciZaReader(povratniZaReadera);
            return povratniZaReadera;
        }
       





    }
}
