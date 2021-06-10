using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat2021.Class_Model
{
    public interface ILogger
    {
       // bool PrimljeniPodaciZaReader(CollectionDescription cd);
        bool PoslatiPodaciZaReader(DateTime d1, DateTime d2, int code);
        void UpisiUFajl(string s);
    }
}
