using Katana;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katana
{
    class Program
    {        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("Wazak"));
            joueurs.Add(new Joueur("Red"));
            joueurs.Add(new Joueur("ZoZo"));
            Jeu jeu = new Jeu(joueurs);
            bool codeBushidoEnJeu = false;
            bool partieEstfinie = false;
            while (partieEstfinie == false)
            {
                foreach (Joueur joueur in joueurs)
                {
                    if (partieEstfinie)
                        return;
                    jeu.PhaseRecuperation(joueur);
                    jeu.PhasePioche(joueur);
                    Console.Clear();
                    Console.WriteLine("_________________________________________");
                    Console.Write("Tour de " + joueur);
                    Console.WriteLine(" Role : " + joueur.Role.GetNom());
                    Console.WriteLine("_________________________________________");
                    int numCarte = 99;
                    int nbAtkUtilisee = 0; //GetNbAtkParTour
                    
                    
                    while (numCarte != -1 && partieEstfinie == false)
                    {
                        Console.WriteLine("Pioche : " + jeu.Pioche.Count());
                        foreach (Joueur j in joueurs)
                        {

                            Console.WriteLine(joueurs.IndexOf(j) + " -- " + j + " --- ");
                            //Console.WriteLine("     Role : " + j.Role.GetNom());
                            Console.WriteLine("     Personnage : " + j.Personnage);
                            Console.WriteLine("     --- Deck : " + j.Deck.Count + " --- ");
                            if (j == joueur)
                            {
                                foreach (Carte carte in j.Deck)
                                {
                                    Console.WriteLine("         " + j.Deck.IndexOf(carte) + " " + carte.Nom);
                                }
                            }
                            Console.WriteLine("     --- Buffs : " + j.Buffs.Count + " --- ");
                            foreach (Carte c in j.Buffs)
                            {
                                Console.WriteLine("         " + j.Buffs.IndexOf(c) + " " + c);
                                if (c is CodeDuBushido)
                                    codeBushidoEnJeu = true;
                            }
                        }
                        //Choix de la carte à jouer, en tapant son numéro dans la liste :
                        Console.WriteLine(jeu.Fin());
                        Console.WriteLine("Numéro de la carte à utiliser (-1 pour aucune) :");
                        numCarte = Convert.ToInt32(Console.ReadLine());

                        if (numCarte != -1)
                        {
                            //Utilise la carte, selon son type :
                            if (joueur.Deck[numCarte] is CarteArme
                                || (joueur.Deck[numCarte] is CarteAction
                                    && (joueur.Deck[numCarte] is Diversion
                                     || joueur.Deck[numCarte] is Geisha
                                     || joueur.Deck[numCarte] is Meditation))
                                || joueur.Deck[numCarte] is CodeDuBushido)
                            {
                                //Choisit la cible :
                                Console.WriteLine("Numéro du joueur à cibler :");
                                int numJoueur = Convert.ToInt32(Console.ReadLine());

                                //Utilise la carte :
                                if (joueur.Deck[numCarte] is CarteArme)
                                {
                                    if (nbAtkUtilisee < joueur.Personnage.GetNbAtkParTour())
                                    {
                                        joueur.Deck[numCarte].Utiliser(jeu, joueurs[numJoueur]);
                                        if (joueurs[numJoueur].Personnage.EstAttaquer > 0)
                                        {
                                            Console.WriteLine("Joueur " + joueurs[numJoueur] + " : Souhaitez-vous utiliser une parade (0:non 1:oui) :");
                                            int parer = Convert.ToInt32(Console.ReadLine());

                                            //Verif s'il y a une parade dans le deck :
                                            if (!joueurs[numJoueur].Deck.OfType<Parade>().Any())
                                                parer = 0;

                                            if (parer == 0)
                                            {
                                                joueurs[numJoueur].SeDefend(null, jeu.Defausse, jeu.Pioche, joueur);
                                                if (joueurs[numJoueur].APerdu())
                                                    partieEstfinie = true;
                                            }
                                            else if (parer == 1)
                                            {
                                                joueurs[numJoueur].SeDefend(joueurs[numJoueur].Deck.OfType<Parade>().FirstOrDefault(), jeu.Defausse, jeu.Pioche, joueur);
                                            }
                                            nbAtkUtilisee++;
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vous ne pouvez plus attaquer ce tour-ci !!!");
                                        Console.WriteLine("Vous ne pouvez plus attaquer ce tour-ci !!!");
                                        Console.ReadLine();
                                    }

                                }
                                else if (joueur.Deck[numCarte] is Diversion)
                                {
                                    Console.WriteLine("Numéro de la carte à voler :");
                                    int numCarteVoulue = Convert.ToInt32(Console.ReadLine());
                                    joueur.Deck[numCarte].Utiliser(jeu, joueurs[numJoueur], numCarteVoulue);
                                }
                                else if (joueur.Deck[numCarte] is Geisha)
                                {
                                    Console.WriteLine("Défaussez carte permanente ou en main ? (True = permanente, False = en main) :");
                                    bool estPermanente = Convert.ToBoolean(Console.ReadLine());
                                    Console.WriteLine("Numéro de la carte à voler :");
                                    int numCarteVoulue = Convert.ToInt32(Console.ReadLine());
                                    joueur.Deck[numCarte].Utiliser(jeu, joueurs[numJoueur], numCarteVoulue, estPermanente);
                                }
                                else if (joueur.Deck[numCarte] is Meditation)
                                {
                                    joueur.Deck[numCarte].Utiliser(jeu, joueurs[numJoueur]);
                                }
                                else if (joueur.Deck[numCarte] is CodeDuBushido)
                                {
                                    if (codeBushidoEnJeu == false)
                                        joueur.Deck[numCarte].Utiliser(jeu, joueurs[numJoueur]);
                                    else
                                        Console.WriteLine("Un code du bushido est déjà en jeu");
                                }
                            }                            
                            else if (joueur.Deck[numCarte] is Jujitsu) 
                            {
                                foreach (Joueur jo in joueurs)
                                {
                                    if (jo != joueur)
                                    {
                                        if (jo.Deck.Count() > 0 && jo.Personnage.GetPV() > 0)
                                        {
                                            Console.WriteLine("Joueur " + jo + " : Souhaitez-vous défausser une arme (0:non 1:oui) :");
                                            int choixJujitsu = Convert.ToInt32(Console.ReadLine());

                                            //Veut défausser une arme :
                                            if (choixJujitsu == 1)
                                            {
                                                int numCarteArme = -1;

                                                do
                                                {
                                                    Console.WriteLine("Numéro de l'arme (-1 pour annuler) :");
                                                    numCarteArme = Convert.ToInt32(Console.ReadLine());

                                                    if (numCarteArme == -1)
                                                    {
                                                        numCarteArme = 0;
                                                        choixJujitsu = -1;
                                                    }

                                                    if (!(jo.Deck[numCarteArme] is CarteArme) && jo.Choix != -1)
                                                        Console.WriteLine("Ceci n'est pas une arme ! Réessayer.");

                                                } while (!(jo.Deck[numCarteArme] is CarteArme) && jo.Choix != -1);

                                                if (choixJujitsu != -1)
                                                    jo.Choix = numCarteArme;
                                                else
                                                    jo.Choix = -1;
                                            }
                                            else if (choixJujitsu == 0)
                                                jo.Choix = -1;

                                        }

                                    }

                                }
                                joueur.Deck[numCarte].Utiliser(jeu);
                            }
                            else if (joueur.Deck[numCarte] is CriDeGuerre)
                            {
                                foreach (Joueur jo in joueurs)
                                {
                                    if (jo != joueur && jo.Deck.Count() > 0 && jo.Personnage.GetPV() > 0)
                                    {
                                        if (jo.Deck.Count() > 0 && jo.Personnage.GetPV() > 0)
                                        {
                                            Console.WriteLine("Joueur " + jo + " : Souhaitez-vous défausser une parade (0:non 1:oui) :");
                                            jo.Choix = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }

                                }
                                joueur.Deck[numCarte].Utiliser(jeu);
                            }
                            
                            else
                                joueur.Deck[numCarte].Utiliser(jeu);
                            Console.WriteLine("_________________________________________");
                        }
                        else
                        {
                            while (jeu.BesoinDeDefausser(joueur) == true)
                            {
                                foreach (Carte carte in joueur.Deck)
                                {
                                    Console.WriteLine("         " + joueur.Deck.IndexOf(carte) + " " + carte.Nom);
                                }
                                Console.WriteLine("Numéro de la carte à défausser :");
                                numCarte = Convert.ToInt32(Console.ReadLine());
                                jeu.PhaseDefausse(joueur, joueur.Deck[numCarte]);
                            }
                            numCarte = -1;
                        }

                    }
                                
                }

                //Comptez les points et définir l'équipe gagnante :
                Console.WriteLine(jeu.Fin());


            }
            

        }
    
    }
}
