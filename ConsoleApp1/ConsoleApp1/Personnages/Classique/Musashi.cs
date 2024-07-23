using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Musashi : Personnage
    {
        public Musashi() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Musashi;
            RecupererPdv();
            degatsBonus++;
        }


    }
}
