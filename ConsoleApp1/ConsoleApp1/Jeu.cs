using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{

    public class Jeu
    {
        List<Carte> pioche = new List<Carte>();
        List<Carte> defausse = new List<Carte>();
        List<Personnage> personnages = new List<Personnage>();
        List<Role> roles = new List<Role>();
        List<Joueur> joueurs = new List<Joueur>();
        List<Equipe> equipes = new List<Equipe>();

        public List<Carte> Pioche { get => pioche; set => pioche = value; }
        public List<Carte> Defausse { get => defausse; set => defausse = value; }
        public List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }

        public Jeu(List<Joueur> joueurs)
        {
            this.joueurs = joueurs;

            Equipe Ninjas = new Ninjas();
            Equipe ShogunEtSamourai = new ShogunEtSamourai();
            Equipe ERonin = new ERonin();
            equipes.Add(Ninjas);
            equipes.Add(ShogunEtSamourai);
            equipes.Add(ERonin);

            switch (joueurs.Count)
            {
                case 3:
                    roles.Add(new Shogun(2));
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());                    
                    break;
                case 4:
                    roles.Add(new Shogun());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja(2));
                    roles.Add(new Samourai(2));
                    break;
                case 5:
                    roles.Add(new Shogun());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());
                    roles.Add(new Samourai());
                    roles.Add(new Ronin(2));
                    break;
                case 6:
                    roles.Add(new Shogun());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());
                    roles.Add(new Samourai(2));
                    roles.Add(new Ronin(3));
                    break;
                case 7:
                    roles.Add(new Shogun());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());
                    roles.Add(new Ninja());
                    roles.Add(new Samourai());
                    roles.Add(new Samourai());
                    roles.Add(new Ronin(3));
                    break;
                default: 
                    Console.WriteLine("Erreur dans le nombre de joueurs");
                    break;
            }
            


            personnages.Add(new Musashi());
            personnages.Add(new Kojiro());
            personnages.Add(new Hanzo());
            personnages.Add(new Chiyome());
            personnages.Add(new Benkei());
            personnages.Add(new Goemon());
            personnages.Add(new Hideyoshi());
            personnages.Add(new Ushiwaka());
            personnages.Add(new Tomoe());
            personnages.Add(new Ginchiyo());
            personnages.Add(new Ieyasu());
            personnages.Add(new Nobunaga());

            distribuer_Roles_Aléatoires(roles, joueurs);
            distribuer_Persos_Aléatoires(personnages, joueurs);
            charger_Pioche();
            distribuer_cartes();                     
        }

        private void distribuer_cartes()
        {
            int idShogun = joueurs.IndexOf((Joueur)joueurs.Where(joueur => joueur.GetRole() is Shogun).FirstOrDefault());
            Joueur tempjoueur;
            while (idShogun != 0)
            {
                tempjoueur = joueurs[0];
                joueurs.Remove(joueurs[0]);
                joueurs.Add(tempjoueur);
                idShogun = joueurs.IndexOf((Joueur)joueurs.Where(joueur => joueur.GetRole() is Shogun));
            }

            foreach (Joueur j in joueurs)
            {
                //Console.WriteLine(j);
                switch (joueurs.IndexOf(j))
                {
                    case 0:
                        j.Piocher(pioche, 4);
                        break;
                    case 1:
                    case 2:
                        j.Piocher(pioche, 5);
                        break;
                    case 3:
                    case 4:
                        j.Piocher(pioche, 6);
                        break;
                    case 5:
                    case 6:
                        j.Piocher(pioche, 7);
                        break;
                }
            }
        }

        private void charger_Pioche()
        {
            for(int i = 0; i < 4; i++)
                pioche.Add(new CriDeGuerre());
            for(int i = 0; i < 3; i++)
                pioche.Add(new Daimyo());
            for (int i = 0; i < 5; i++)
                pioche.Add(new Diversion());
            for (int i = 0; i < 6; i++)
                pioche.Add(new Geisha());
            for (int i = 0; i < 3; i++)
                pioche.Add(new Meditation());
            for (int i = 0; i < 15; i++)
                pioche.Add(new Parade());
            for (int i = 0; i < 4; i++)
                pioche.Add(new CeremonieDuThe());
            for (int i = 0; i < 3; i++)
                pioche.Add(new Jujitsu());
            
            for (int i = 0; i < 3; i++)
                pioche.Add(new AttaqueRapide());
            for (int i = 0; i < 2; i++)
                pioche.Add(new CodeDuBushido());
            for (int i = 0; i < 4; i++)
                pioche.Add(new Armure());
            for (int i = 0; i < 6; i++)
                pioche.Add(new Concentration());

            pioche.Add(new CarteArme("Nodachi", 4, 1));
            for (int i = 0; i < 2; i++)
                pioche.Add(new CarteArme("Naginata", 4, 1));
            pioche.Add(new CarteArme("Nagayari", 4, 2));
            pioche.Add(new CarteArme("Tanegashima", 5, 1));
            pioche.Add(new CarteArme("Daikyû", 5, 2));
            for (int i = 0; i < 5; i++)
                pioche.Add(new CarteArme("Bô", 2, 1));
            for (int i = 0; i < 4; i++)
                pioche.Add(new CarteArme("Kusarigama", 2, 2));
            pioche.Add(new CarteArme("Katana", 2, 3));
            for (int i = 0; i < 3; i++)
                pioche.Add(new CarteArme("Shuriken", 3, 1));
            pioche.Add(new CarteArme("Kanabô", 3, 2));
            for (int i = 0; i < 6; i++)
                pioche.Add(new CarteArme("Bokken", 1, 1));
            for (int i = 0; i < 5; i++)
                pioche.Add(new CarteArme("Kiseru", 1, 2));
            pioche.Add(new CarteArme("Wakizashi", 1, 3));

            Shuffle(pioche);
        }
        
        /// <summary>
        /// Mélange une liste
        /// </summary>
        /// <typeparam name="Carte"></typeparam>
        /// <param name="list"></param>
        private void Shuffle<Carte>(IList<Carte> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void distribuer_Roles_Aléatoires(List<Role> roles, List<Joueur> joueurs)
        {
            var rand = new Random();
            int nbAleatoire;
            
            foreach(Joueur joueur in joueurs)
            {
                nbAleatoire = rand.Next(0, roles.Count);
                joueur.DonnerRole(roles[nbAleatoire]);
                roles.Remove(roles[nbAleatoire]);
            }

            var sho = joueurs.Where(j => j.Role.GetNom() == CstRoles.Shogun).FirstOrDefault();
            joueurs.Remove(joueurs.Where(j => j.Role.GetNom() == CstRoles.Shogun).Last());
            joueurs.Insert(0, sho);
        }

        private void distribuer_Persos_Aléatoires(List<Personnage> persos, List<Joueur> joueurs)
        {
            var rand = new Random();
            int nbAleatoire;

            int count = 0;
            foreach (Joueur joueur in joueurs)
            {                
                nbAleatoire = rand.Next(0, persos.Count);
                joueur.DonnerPersonnage(persos[nbAleatoire]);
                persos.Remove(persos[nbAleatoire]);
                joueur.Personnage.Placement = count;
                count++;
            }

            Personnage.Count = count;
        }

        public void PhaseRecuperation(Joueur joueur)
        {
            if (joueur.EstKO())
                joueur.RecupererPdv();
        }

        public void PhasePioche(Joueur joueur)
        {
            joueur.Piocher(Pioche, joueur.Personnage.GetNbCartesAPiochees());
        }

        //Utiliser PhaseDefausse si true :
        public bool BesoinDeDefausser(Joueur joueur)
        {
            return joueur.Deck.Count() > 7;
        }

        public void PhaseDefausse(Joueur joueur, List<Carte> cartes)
        {
            foreach (Carte carte in cartes)
                carte.Defausser(defausse, joueur.Deck);
        }

        public void PhaseDefausse(Joueur joueur, Carte carte)
        {
            carte.Defausser(defausse, joueur.Deck);
        }



        /// <summary>
        /// Comptez les points et définir l'équipe gagnante
        /// </summary>
        /// <returns></returns>
        public string Fin()
        {
            //Afficher les points :
            string resultat = "";
            foreach (Equipe equipe in equipes)
            {
                equipe.AjouterJoueurs(joueurs);
                resultat += equipe + " : " + equipe.GetNbPoints() + " \n";
            }

            //Définir le gagnant :
            Equipe equipeGagnante = equipes.OrderByDescending(e => e.GetNbPoints()).First();
            return resultat + " L'équipe " + equipeGagnante + " est gagnante.";
        }

    }
}
