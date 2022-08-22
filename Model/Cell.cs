using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Model
{
    internal class Cell
    {
        bool hasBomb;
        bool isDiscover;

        public Cell(bool hasBomb)
        {
            this.hasBomb = hasBomb;
        }


    }
}
