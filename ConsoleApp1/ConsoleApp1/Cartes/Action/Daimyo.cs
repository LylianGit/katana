using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Daimyo : CarteAction
    {

        public Daimyo() : base()
        {
            nom = "Daimyo";
        }


        public override void Utiliser(Jeu j)
        {
            Possesseur.Piocher(j.Pioche, 2);

            base.Defausser(j.Defausse, Possesseur.Deck);
        }



    }
}
