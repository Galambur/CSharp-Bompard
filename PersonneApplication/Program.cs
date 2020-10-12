using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersonneLibrary;

namespace PersonneApplication
{
    class Program
    {
        static Entreprise gestion = new Entreprise();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Un jeu de test
            Service production = new Service(1, "Production");
            Service compta = new Service(1, "Comptabilité");
            Service direction = new Service(1, "Direction");

            Entreprise entreprise = new Entreprise();

            entreprise.AjouterPersonne(new Employe(1, "DUPONT", "Charles", new DateTime(1998, 04, 12), 1600, production, 14));
            entreprise.AjouterPersonne(new Employe(2, "KERBAN", "Henry", new DateTime(1981, 09, 24), 1500, production, 7));
            entreprise.AjouterPersonne(new Employe(3, "CHAMPOT", "Paul", new DateTime(1981, 09, 17), 1500, production, 6));
            entreprise.AjouterPersonne(new Cadre(4, "JOULIE", "Alexandre", new DateTime(1987, 11, 21), 2100, compta, 100, Cadre.TypeStatus.Aucun));
            entreprise.AjouterPersonne(new Cadre(5, "MITAUT", "Marcel", new DateTime(1972, 03, 04), 6000, direction, 3000, Cadre.TypeStatus.Financier));

            // Affichage des personnes
            entreprise.AfficherPersonnel();
            // Affichage des personnes du service "production"
            Console.WriteLine("\nAffichage du personnel du service Production");
            AffichePersonnes(entreprise.RechercherPersonnesDuService_Linq("production"));

            Console.WriteLine("\nTrie par Nom Prénom");
            entreprise.TrierParNom_Linq();
            // Affichage des personnes
            entreprise.AfficherPersonnel();


            // Création d'une liste de taches
            ListeTache taches = new ListeTache();

            taches.AjouterTache(new Tache(1, "Ranger", "Ranger le bureau", new DateTime(2020, 09, 28), new DateTime(2020, 09, 30), 20.0));
            taches.AjouterTache(new Tache(2, "Nettoyer", "Nettoyer les locaux", new DateTime(2020, 10, 15), new DateTime(2020, 10, 16), 500.0));
            taches.AjouterTache(new Tache(3, "Construire", "Construire une table pour la salle de repos", new DateTime(2020, 09, 12), new DateTime(2020, 12, 05), 15.0));
            taches.AfficherTaches();

            double total = TacheCout.CalculTacheCout(taches.RechercherTache(1));
            Console.WriteLine($"le total est de {total}");
        }
        
        public static void AffichePersonnes(List<Personne> liste)
        {
            Console.WriteLine("Affichage du personnel");
            foreach (Personne p in liste)
            {
                Console.WriteLine(p.Nom);
            }
        }

        public static void AfficherListeTache(List<Tache> liste)
        {
            Console.WriteLine("Affichage des taches : ");
            foreach (Tache t in liste)
            {
                Console.WriteLine(t.Libelle);
            }
        }


    }
 }
