using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class CartePermanente : Carte
    {

        public CartePermanente() : base()
        {

        }

        public string GetNom()
        {
            return nom;
        }

        public void Utiliser()
        {
            //if(PeutAtk(int dif))
            // p.EstAttaquer(dif);
        }

        public void Utiliser(Joueur lanceur) { }

        public override void Utiliser(Jeu j)
        {
            this.Defausser(Possesseur.Buffs, Possesseur.Deck);
        }
        public override void Utiliser(Jeu j, Joueur cible) { }
        public override void Utiliser(Jeu j, Joueur cible, int numCarte) { }
        public override void Utiliser(Jeu j, Joueur cible, int numCarte, bool estPermanente) { }

        public void Ranger(List<Carte> buffs, List<Carte> deck)
        {
            buffs.Add(this);
            deck.Remove(this);
        }

        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            defausse.Add(this);
            deck.Remove(this);
            this.Possesseur = null;
        }

    }
}
