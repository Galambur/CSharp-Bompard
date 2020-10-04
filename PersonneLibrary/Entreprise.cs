using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class Entreprise
    {
        #region Attributs
        private List<Personne> listePersonnes = new List<Personne>();
        #endregion

        #region Propriétés
        public List<Personne> Personnes
        {
            get { return new List<Personne>(listePersonnes); }
        }
        #endregion

        #region CRUD
        public bool AjouterPersonne(Personne personne)
        {
            if (personne == null)
                return false;

            Personne p = RechercherPersonne(personne.Id);
            if (p != null) // La personne existe déjà
                return false;

            listePersonnes.Add(personne);
            return true;
        }

        public bool SupprimerPersonne(Personne personne)
        {
            if (personne == null)
                return false;

            return SupprimerPersonne(personne.Id);
        }
        public bool SupprimerPersonne(int id)
        {
            Personne p = RechercherPersonne(id);
            if (p == null)
                return false;

            listePersonnes.Remove(p);
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public Personne RechercherPersonne(int id)
        {
            return listePersonnes.Find(delegate (Personne personne)
            {
                return personne.Id == id;
            });
        }
        public Personne RechercherPersonne_Linq(int id)
        {
            return listePersonnes.FirstOrDefault(p => p.Id == id);
        }

        public List<Personne> RechercherPersonnesParNom(string nom)
        {
            return listePersonnes.FindAll(delegate (Personne personne)
            {
                return personne.Nom.Equals(nom, StringComparison.InvariantCultureIgnoreCase);
            });
        }
        public List<Personne> RechercherPersonneParNom_Linq(string nom)
        {
            return listePersonnes.Where(p => p.Nom.Equals(nom, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        public List<Personne> RechercherPersonnesCommencePar(string nom)
        {
            return listePersonnes.FindAll(delegate (Personne personne)
            {
                return personne.Nom.StartsWith(nom,
                            StringComparison.InvariantCultureIgnoreCase);
            });
        }
        public List<Personne> RechercherPersonnesCommencePar_Linq(string nom)
        {
            return listePersonnes.Where(p => p.Nom.StartsWith(nom, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        public List<Personne> RechercherPersonnesDuService(string libelle)
        {
            return listePersonnes.FindAll(delegate (Personne personne)
            {
                return personne.Service.Libelle.Equals(libelle, StringComparison.InvariantCultureIgnoreCase);
            });
        }

        public List<Personne> RechercherPersonnesDuService_Linq(string libelle)
        {
            return listePersonnes.Where(p => p.Service.Libelle.Equals(libelle, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        #endregion

        #region Trie
        public void TrierParNom()
        {
            listePersonnes.Sort(delegate (Personne x, Personne y)
            {
                if (x.Nom == null && y.Nom == null) return 0;
                else if (x.Nom == null) return -1;
                else if (y.Nom == null) return 1;
                else return x.Nom.CompareTo(y.Nom);
            });
        }
        public void TrierParNom_Linq()
        {
            listePersonnes.Sort( (p1, p2) => 
                {
                    if (p1.Nom == null && p2.Nom == null) return 0;
                    else if (p1.Nom == null) return -1;
                    else if (p2.Nom == null) return 1;
                    else return p1.Nom.CompareTo(p2.Nom);
                }
            );
        }
        #endregion

        #region Méthodes de debug
        public void AfficherPersonnel()
        {
            Console.WriteLine("Affichage du personnel");
            foreach (Personne p in listePersonnes)
            {
                Console.WriteLine(p.Identite);
            }   
        }
        #endregion
    }

}
