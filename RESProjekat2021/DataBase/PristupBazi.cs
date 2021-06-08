using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class PristupBazi
    {
        //Azuriranje baze prema DataSetu iz Descriptiona
        public static void UpdateDBperDataSet(CollectionDescription cdescription)
        {
            using (var db = new DataBase())
            {
                WorkerProperty wp1 = cdescription.HistoricalCollection.listaWorkerPropertys[0];
                WorkerProperty wp2 = cdescription.HistoricalCollection.listaWorkerPropertys[1];

                var pronadjiSve = db.DescriptionT.Where(x => x.DataSet == (int)cdescription.DataSet);

                var code1 = pronadjiSve.Where(x => x.Code == (int)wp1.Code).FirstOrDefault();
                var code2 = pronadjiSve.Where(x => x.Code == (int)wp2.Code).FirstOrDefault();


                code1 = ConvertWorkerPropertyToBase(wp1);

                PristupBazi.UpdateWorkerProperty(code1, db);
                db.SaveChanges();


                code2 = ConvertWorkerPropertyToBase(wp2);
                PristupBazi.UpdateWorkerProperty(code2, db);
                db.SaveChanges();
            }
        }


        //citanje iz baze
        public static List<WorkerProperty> GetWorkerProperties()
        {
            List<WorkerProperty> workerProperties = new List<WorkerProperty>();
            using (var baza = new DataBase())
            {
                foreach (var bazaDescription in baza.DescriptionT)
                {
                    workerProperties.Add(ConvertBPropertyToWorker(bazaDescription));
                }
            }
            return workerProperties;
        }

        //dodavanje u bazu
        public static void UpdateWorkerProperty(DescriptionT descriptionT, DataBase baza)
        {
            var pronadji = baza.DescriptionT.Where(x => x.Code == (int)descriptionT.Code);
            DescriptionT dT = pronadji.FirstOrDefault();

            baza.DescriptionT.Remove(dT);
            baza.DescriptionT.Add(descriptionT);
        }




        //Konvertovanje iz Wroker Propertija u Property iz baze
        public static DescriptionT ConvertWorkerPropertyToBase(WorkerProperty workerProperty)
        {
            return new DescriptionT
            {
                Code = (int)workerProperty.Code,
                Value = workerProperty.WorkerValue,
                TimeStamp = workerProperty.TimeStamp,
                DataSet = ((int)workerProperty.Code + 1) / 2
            };
        }

        //Konvertovanje iz property-ja iz baze u Worker property
        public static WorkerProperty ConvertBPropertyToWorker(DescriptionT descriptionT)
        {
            return new WorkerProperty
            {
                Code = (CodeEnum)descriptionT.Code,
                WorkerValue = (int)descriptionT.Value,
                TimeStamp = (DateTime)descriptionT.TimeStamp
            };
        }


       



    }
}
