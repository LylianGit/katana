using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class AttaqueRapide : CartePermanente
    {

        public AttaqueRapide() : base()
        {
            nom = "Attaque rapide";
        }

        public override void Utiliser(Jeu j)
        {
            Possesseur.AugmenterAtk(1);
            base.Ranger(Possesseur.Buffs, Possesseur.Deck);
        }

        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            Possesseur.AugmenterAtk(-1);
            base.Defausser(defausse, deck);
        }

    }
}
