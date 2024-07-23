using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Ushiwaka : Personnage
    {
        public Ushiwaka() : base()
        {
            pvMax = 4;
            nom = CstPersonnages.Ushiwaka;
            RecupererPdv();
        }

        public new void PerdPV(int dgt, bool atkDArme, List<Carte> pioche)
        {           
            ModifierPv(-dgt);
            if (atkDArme == true)
                Piocher(pioche, dgt);
        }
    }
}
