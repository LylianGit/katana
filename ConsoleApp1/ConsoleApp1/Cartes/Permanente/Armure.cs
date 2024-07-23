using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Armure : CartePermanente
    {

        public Armure() : base()
        {
            nom = "Armure";
        }

        public override void Utiliser(Jeu j)
        {
            Possesseur.AugmenterArmure(1);
            base.Ranger(Possesseur.Buffs, Possesseur.Deck);
        }


        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            Possesseur.AugmenterArmure(-1);
            base.Defausser(defausse, deck);
        }

    }
}
