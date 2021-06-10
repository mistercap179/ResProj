using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat2021.Class_Model
{
    public interface IReader
    {
        void slanjeW(DateTime d1, DateTime d2, int code);
        void PoslatiZaReader(DateTime d1, DateTime d2, int code);
    }
}
