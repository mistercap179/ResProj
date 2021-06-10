using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat2021.Class_Model
{
    public interface IWorker
    {
        void PorukaOdLoadBalancera(List<Description> descriptions);

        void ProvjeraUpisa(CollectionDescription collectionDescription);

        CollectionDescription DeadBand(CollectionDescription cd);

      // CollectionDescription slanjeWorkeru(DateTime d1, DateTime d2, int code);

    }
}
