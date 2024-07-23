using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class CodeDuBushido : CartePermanente
    {

        public CodeDuBushido() : base()
        {
            nom = "Code du bushido";
        }

        /// <summary>
        /// Place la carte devant le joueur ciblé
        /// </summary>
        /// <param name="j"></param>
        /// <param name="cible"></param>
        public override void Utiliser(Jeu j, Joueur cible)
        {
            this.Defausser(cible.Buffs, Possesseur.Deck);
            this.Possesseur = cible;
        }
        /// <summary>
        /// Défausse la 1ère carte de la pioche puis
        /// Retourne vrai si c'est une arme
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool PremiereCartePiocheEstUneArme(Jeu j)
        {
            Possesseur.Piocher(j.Pioche, 1);
            Possesseur.Deck.Last().Defausser(Possesseur.Deck, j.Defausse);
            if (j.Defausse.Last().GetType().BaseType.ToString() == "Katana.CarteArme")
                return true;
            return false;
        }


        /// <summary>
        /// Le joueur doit défausser une arme si PremiereCartePiocheEstUneArme.
        /// Mettre le choix à -1 si le joueur ne défausse pas d'arme, ce qui lui fait défausser un point d'honneur.
        /// Si la carte n'est pas une arme ou que le joueur défausse une arme, la carte va devant le voisin de gauche.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="cible"></param>
        public void PasserOuDefausser(Jeu j, Joueur cible)
        {
            if (j.Defausse.Last().GetType().BaseType.ToString() == "Katana.CarteArme")
            {
                if (Possesseur.Choix != -1)
                {
                    Possesseur.Deck[Possesseur.Choix].Defausser(j.Defausse, Possesseur.Deck);
                    Possesseur = cible;
                }
                else
                {
                    Possesseur.PerdPointDHonneur();
                    Defausser(j.Defausse, Possesseur.Buffs);
                }
            }
            else
            {
                Possesseur = cible;
            }
        }


        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            base.Defausser(defausse, deck);
        }

    }
}
