using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Benkei : Personnage
    {
        public Benkei() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Benkei;
            RecupererPdv();
            armure++;
        }

    }
}
