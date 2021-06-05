using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat2021.Class_Model
{
    public interface ILoadBalancer
    {
        void PorukaOdWritera(int id, int code, int value);

        void RoundRobin();

        bool UpaliW();

        bool UgasiW();
    }
}
