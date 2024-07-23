using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Hideyoshi : Personnage
    {
        public Hideyoshi() : base()
        {
            pvMax = 4;
            nom = CstPersonnages.Hideyoshi;
            RecupererPdv();
            nbCartesAPiochees++;
        }

    }
}
