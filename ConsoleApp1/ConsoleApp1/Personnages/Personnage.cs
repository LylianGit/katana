using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class Personnage // 12 cartes
    {

        public static int Count = 0;

        protected int pvMax;
        protected int pv;
        protected string nom;
        protected int placement;
        protected int armure;
        protected int degatsBonus;
        protected int nbAtkParTour;
        protected List<Carte> deck;
        public int EstAttaquer;
        protected int tour;
        protected int nbCartesAPiochees;

        public int dgtInfliges;

        public int Tour { get => tour; set => tour = value; }
        public int Pv { get => pvMax; set => pvMax = value; }
        public List<Carte> Deck { get => deck; set => deck = value; }
        public int Placement { get => placement; set => placement = value; }

        public bool EstKO()
        {
            return pv <= 0;
        }

        public int GetPV()
        {
            return pv;
        }
        public int GetNbCartesAPiochees()
        {
            return nbCartesAPiochees;
        }
        public int GetNbAtkParTour()
        {
            return nbAtkParTour;
        }
        public int getPlacement()
        {
            return placement;
        }
        public string GetNom()
        {
            return nom;
        }
        public int GetArmure()
        {
            return armure;
        }

        public int GetEstAttaquer()
        {
            return EstAttaquer;
        }
        public void SetEstAttaquer(int dgt)
        {
            EstAttaquer = dgt;
        }




        public Personnage()
        {
            nom = "";
            armure = 0;
            degatsBonus = 0;
            nbAtkParTour = 1;
            EstAttaquer = 0;
            nbCartesAPiochees = 2;
            dgtInfliges = 0;
            deck = new List<Carte>();
        }




        public void Piocher(List<Carte> pioche, int nbCartes)
        {
            for(int i = 0; i < nbCartes; i++)
            {
                deck.Add(pioche.First());               
                pioche.Remove(pioche.First());
            }
            
        }
        public void AugmenterNbAtk(int val) 
        {
            nbAtkParTour += val;
        }
        public void AugmenterArmure(int val)
        {
            armure += val;
        }
        public void AugmenterAtk(int val)
        {
            degatsBonus += val;
        }
        public void RecupererPdv()
        {
            this.pv = pvMax;
        }
        public void ModifierPv(int pdv)
        {
            pv += pdv;
        }
        public override string ToString()
        {
            return ("nom:" + nom + " pv:" + pv + "/" + pvMax);
        }

        public void PerdPV(int dgt)
        {
            PerdPV(dgt, false);
        }

        //param2 pour chiyome
        public void PerdPV(int dgt, bool atkDArme)
        {
            PerdPV(dgt, atkDArme, new List<Carte>());
        }

        // param2 et 3 pour ushiwaka
        public void PerdPV(int dgt, bool atkDArme, List<Carte> pioche)
        {
            ModifierPv(-dgt);
        }

        public bool peutAttaquer(int nbJoueurs, int placementCible, int difficulteArme)
        {
            if(this.placement > placementCible) // moi 2 > cible 0 
            {
                if (this.placement - placementCible <= (nbJoueurs - this.placement) + placementCible)
                    return difficulteArme >= this.placement - placementCible;
                else
                    return difficulteArme >= (nbJoueurs - this.placement) + placementCible;

            }
            else if (this.placement < placementCible)
            {
                if (placementCible - this.placement <= (this.placement + nbJoueurs) - placementCible)
                    return difficulteArme >= placementCible - this.placement;
                else
                    return difficulteArme >= (this.placement + nbJoueurs) - placementCible;
            }
            else
            {
                return false; //Ne peut pas s'attaquer lui-même
            }

            

            /*int diff1 = 0;
            int diff2 = 0;
            int diff3 = 0;
            int diff4 = 0;
            diff1 = cible.getPlacement() - placement; 
            diff2 = Count - cible.getPlacement() + placement; 
            diff3 = Count - placement + cible.getPlacement();
            diff4 = placement - cible.getPlacement();
            int diff = 0;
            if (diff1 <= 3 && diff1 >= 0)
                diff = diff1;
            else if (diff2 <= 3 && diff2 >= 0)
                diff = diff2;
            else if (diff3 <= 3 && diff3 >= 0)
                diff = diff3;
            else
                diff = diff4;

            if (difficulteArme < diff + cible.GetArmure())
            {
                Console.WriteLine("Difficulté de " + diff + cible.GetArmure() + " requise");
                return false;
            }
            return true;*/
        }

        public void Attaquer(Personnage cible, int difficulteArme, int degatsArme)
        {
            //if (peutAttaquer(cible, difficulteArme))
            //{
            cible.SetEstAttaquer(degatsArme + degatsBonus);
            //}
        }


        /// <summary>
        /// Mettre null en param1 si ne se défend pas
        /// </summary>
        /// <param name="parade">Null si ne se défend pas</param>
        /// <param name="defausse"></param>
        /// <param name="pioche"></param>
        /// <param name="attaquant"></param>
        public void SeDefend(Parade parade, List<Carte> defausse, List<Carte> pioche, Personnage attaquant)
        {
            if(EstAttaquer > 0)
            {
                if (parade == null)
                {
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

        public bool peutSeDefendre()
        {
            return true;
        }


        public void Parer(Carte carte)
        {
            if (carte.GetType() == typeof(Parade))
                Parade((Parade)carte);
            else
                Console.WriteLine("Vous ne pouvez pas parer avec ça !");
        }

        protected void Parade(Parade parade)
        {
            SetEstAttaquer(0);
            deck.Remove(parade);
        }


        public int Diff(int placementCible)
        {
            int diff1 = 0;
            int diff2 = 0;
            int diff3 = 0;
            diff1 = placementCible - placement; //sens horaire
            diff2 = Count - placement + placementCible; //sens anti-horaire
            diff3 = placement - placementCible;
            int diff = 0;
            if (diff1 <= diff2 && diff1 >= 0)
                diff = diff1;
            else if (diff2 <= diff3 && diff2 >= 0)
                diff = diff2;
            else
                diff = diff3;

            return diff;
        }

        public (int,bool) DiffAttendue(int placementCible, int diffAttendue)
        {
            int diff1 = 0;
            int diff2 = 0;
            int diff3 = 0;
            int diff4 = 0;
            diff1 = placementCible - placement; //sens horaire
            diff2 = Count - placementCible + placement; //sens anti-horaire
            diff3 = Count - placement + placementCible;
            diff4 = placement - placementCible;
            int diff = 0;
            if (diff1 <= 3 && diff1 >= 0)
                diff = diff1;
            else if (diff2 <= 3 && diff2 >= 0)
                diff = diff2;
            else if (diff3 <= 3 && diff3 >= 0)
                diff = diff3;
            else
                diff = diff4;

            return (diff, Math.Equals(diff, diffAttendue));
        }

    }
}
