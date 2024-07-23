using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Hanzo : Personnage
    {
        public Hanzo() : base()
        {
            pvMax = 4;
            nom = CstPersonnages.Hanzo;
            RecupererPdv();
        }

        public void Parer(CarteArme arme)
        {
            deck.Remove(arme);
        }

        public new void Parer(Carte carte)
        {
            if (carte.GetType().ToString() == "Parade")
                Parade((Parade)carte);
            else if(carte.GetType().ToString() == "Arme")
                Parade((CarteArme)carte);
            else
                Console.WriteLine("Vous ne pouvez pas parer avec ça !");
        }

        protected void Parade(CarteArme arme)
        {
            SetEstAttaquer(0);
            deck.Remove(arme);
        }
    }
}
