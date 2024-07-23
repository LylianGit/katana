using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Ginchiyo : Personnage
    {
        public Ginchiyo() : base()
        {
            pvMax = 4;
            nom = CstPersonnages.Ginchiyo;
            RecupererPdv();
        }

        //mettre null en param1 si ne se défend pas
        public new void SeDefend(Parade parade, List<Carte> defausse, List<Carte> pioche, Personnage attaquant)
        {
            if (EstAttaquer > 0)
            {
                if (parade == null)
                {

                    if (EstAttaquer > 1)
                        EstAttaquer -= 1;

                    PerdPV(EstAttaquer, true, pioche);
                    //capacité de Tomoe :
                    if (attaquant.GetNom() == "Tomoe")
                    {
                        attaquant.Piocher(pioche, EstAttaquer);
                    }
                    attaquant.dgtInfliges += EstAttaquer;
                }
                else
                    parade.Defausser(defausse, deck);

                EstAttaquer = 0;
            }
        }

    }
}
