using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Geisha : CarteAction
    {

        public Geisha() : base()
        {
            nom = "Geisha";
        }


        public override void Utiliser(Jeu j, Joueur joueurCible, int numeroCarte, bool estUneCartePermanente)
        {
            if(estUneCartePermanente)
                joueurCible.Buffs.RemoveAt(numeroCarte);
            else
                joueurCible.Deck.RemoveAt(numeroCarte); 

            base.Defausser(j.Defausse, Possesseur.Deck);
        }



    }
}
