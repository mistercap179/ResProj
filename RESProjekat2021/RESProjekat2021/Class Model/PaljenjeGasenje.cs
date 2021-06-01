using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat2021.Class_Model
{
    public class PaljenjeGasenje
    {
        public bool upaljenWorker1 { get; set; }
        public bool upaljenWorker2 { get; set; }
        public bool upaljenWorker3 { get; set; }
        public bool upaljenWorker4 { get; set; }

        public PaljenjeGasenje()
        {
            upaljenWorker1 = true;
            upaljenWorker2 = true;
            upaljenWorker3 = true;
            upaljenWorker4 = true;
        }

        public PaljenjeGasenje(bool stanje1,bool stanje2,bool stanje3,bool stanje4)
        {
            this.upaljenWorker1 = stanje1;
            this.upaljenWorker2 = stanje2;
            this.upaljenWorker3 = stanje3;
            this.upaljenWorker4 = stanje4;
        }

        public PaljenjeGasenje(PaljenjeGasenje paljenje)
        {
            this.upaljenWorker1 = paljenje.upaljenWorker1;
            this.upaljenWorker2 = paljenje.upaljenWorker2;
            this.upaljenWorker3 = paljenje.upaljenWorker3;
            this.upaljenWorker4 = paljenje.upaljenWorker4;
        }
    }
}
