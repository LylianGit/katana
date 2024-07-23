using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Concentration : CartePermanente
    {

        public Concentration() : base()
        {
            nom = "Concentration";
        }

        public override void Utiliser(Jeu j)
        {
            Possesseur.AugmenterNbAtk(1);
            base.Ranger(Possesseur.Buffs, Possesseur.Deck);
        }

        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            Possesseur.AugmenterNbAtk(-1);
            base.Defausser(defausse, deck);
        }

    }
}
