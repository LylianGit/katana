using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Ieyasu : Personnage
    {
        private bool piochePremiereCarteDansLaDefausse;
        public Ieyasu() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Ieyasu;
            RecupererPdv();
            piochePremiereCarteDansLaDefausse = false;
        }

        public void ActiverCapacite()
        {
            if (piochePremiereCarteDansLaDefausse == false)
                piochePremiereCarteDansLaDefausse = true;
            else
                piochePremiereCarteDansLaDefausse = false;
        }

        public void Piocher(List<Carte> pioche, int nbCartes, List<Carte> defausse)
        {
            if (piochePremiereCarteDansLaDefausse)
            {
                deck.Add(defausse.First());
                defausse.Remove(defausse.First());
                for (int i = 1; i < nbCartes; i++)
                {
                    deck.Add(pioche.First());
                    pioche.Remove(pioche.First());
                }
            }
            else
            {
                base.Piocher(pioche, nbCartes);
            }

            

        }

    }
}
