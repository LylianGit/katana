using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Joueur
    {
        private string pseudo;
        private Personnage? personnage;
        private Role? role;
        private Equipe? equipe;
        private List<Carte> buffs;
        private int choix;
        
        public bool APerdu()
        {
            return role.APerdu();
        }

        public string Pseudo { get => pseudo; set => pseudo = value; }
        public Personnage? Personnage { get => personnage; set => personnage = value; }
        public Role? Role { get => role; set => role = value; }
        public List<Carte> Deck { get => personnage.Deck; set => personnage.Deck = value; }
        public List<Carte> Buffs { get => buffs; set => buffs = value; }
        public int Choix { get => choix; set => choix = value; }

        public Joueur(string pseudo, Personnage p, Role r)
        {
            this.pseudo = pseudo;
            this.personnage = p;
            role = r;
            buffs = new List<Carte>();
        }

        public Joueur(string pseudo)
        {
            this.pseudo = pseudo;
            this.personnage = null;
            role = null;
            buffs = new List<Carte>();
        }

        public int Resultat()
        {
            return role.Resultat();
        }

        public Role GetRole()
        {
            return role;
        }

        public void DonnerEquipe(Equipe equipe)
        {
            this.equipe = equipe;
        }

        public void DonnerRole(Role r)
        {
            role = r;
        }

        public void DonnerPersonnage(Personnage p)
        {
            personnage = p;
        }

        public void Piocher(List<Carte> pioche, int nbCartes)
        {
            personnage.Piocher(pioche, nbCartes);
            for(int i=Deck.Count()-1; i>=Deck.Count()-nbCartes; i--)
            {
                Deck[i].Possesseur = this;
            }
        }

        public void RecupererPdv()
        {
            personnage.RecupererPdv(); 
        }

        public void PerdPV(int dgt)
        {
            personnage.PerdPV(dgt);
        }
        public void AugmenterNbAtk(int val)
        {
            this.personnage.AugmenterNbAtk(val);
        }
        public void AugmenterArmure(int val)
        {
            this.personnage.AugmenterArmure(val);
        }
        public void AugmenterAtk(int val)
        {
            this.personnage.AugmenterAtk(val);
        }
        public void PerdPointDHonneur()
        {
            role.PerdPointDHonneur();
        }
        public bool EstKO()
        {
            return personnage.EstKO();
        }
        public void Choisir(int choix)
        {
            this.choix = choix;
        }
        public bool Choisir(List<Carte> liste, int choix)
        {
            if(choix < liste.Count)
            {
                return true;
            }
            return false;
        }
        public bool Choisir(List<Joueur> liste, int choix)
        {
            if (choix < liste.Count)
            {
                return true;
            }
            return false;
        }

        public bool peutAttaquer(int nbJoueurs, int placementCible, int difficulteArme)
        {
            return personnage.peutAttaquer(nbJoueurs, placementCible, difficulteArme);
        }
        public void Attaquer(Personnage cible, int difficulteArme, int degatsArme)
        {
            personnage.Attaquer(cible, difficulteArme, degatsArme);
        }

        public void SeDefend(Parade parade, List<Carte> defausse, List<Carte> pioche, Joueur attaquant)
        {
            personnage.SeDefend(parade, defausse, pioche, attaquant.Personnage);
            if (EstKO())
                role.DonnePointDHonneur(attaquant);
                
        }

        public override string ToString()
        {
            return (pseudo + " " + role.GetPointDHonneur() + " PdH");
        }
    }
}
