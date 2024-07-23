using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Goemon : Personnage
    {
        public Goemon() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Goemon;
            RecupererPdv();
            nbAtkParTour++;
        }

    }
}
