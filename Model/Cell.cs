﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Model
{
    internal class Cell
    {
        private bool hasBomb;
        private bool isDiscover;

        public Cell(bool hasBomb)
        {
            this.HasBomb = hasBomb;
        }

        public bool HasBomb { get => hasBomb; set => hasBomb = value; }
        public bool IsDiscover { get => isDiscover; set => isDiscover = value; }
    }
}
