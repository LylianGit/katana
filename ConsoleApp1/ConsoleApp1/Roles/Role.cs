using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class Role // 7 cartes
    {
        protected string nom;
        protected int multiplicateur;
        protected bool roi;
        protected int nbPointDHonneur;
        protected bool aPerdu;
        protected Equipe equipe;

        public Role()
        {
            multiplicateur = 1;
            roi = false;
            nbPointDHonneur = 2;
            aPerdu = false;
        }

        public Role(int multiplicateur)
        {
            this.multiplicateur = multiplicateur;
            roi = false;
            nbPointDHonneur = 2;
            aPerdu = false;
        }

        public override string ToString()
        {
            return nom + "(x" + multiplicateur + ")";
        }

        public int Resultat()
        {
            return nbPointDHonneur * multiplicateur;
        }

        public bool APerdu()
        {
            return aPerdu;
        }

        public string GetNom()
        {
            return nom;
        }

        public Equipe GetEquipe()
        {
            return equipe;
        }

        public void PerdPointDHonneur()
        {
            nbPointDHonneur--;
            if (nbPointDHonneur <= 0)
                aPerdu = true;
        }

        public void GagnePointDHonneur()
        {
            nbPointDHonneur++;
        }

        public void DonnePointDHonneur(Joueur attaquant)
        {
            PerdPointDHonneur();
            attaquant.Role.GagnePointDHonneur();
        }

        public int GetPointDHonneur()
        {
            return nbPointDHonneur;
        }
    }
}
