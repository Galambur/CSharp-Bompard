using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class ListeTache
    {
        #region Attributs
        protected List<Tache> listeTaches = new List<Tache>();
        #endregion

        #region CRUD
        public bool AjouterTache(Tache tache)
        {
            if (tache == null)
                return false;

            Tache t = RechercherTache(tache.Id);
            if (t != null) // La tache existe déjà
                return false;

            listeTaches.Add(tache);
            return true;
        }

        public bool SupprimerTache(Tache tache)
        {
            if (tache == null)
                return false;

            return SupprimerTache(tache.Id);
        }
        public bool SupprimerTache(int id)
        {
            Tache tache = RechercherTache(id);
            if (tache == null)
                return false;

            listeTaches.Remove(tache);
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public Tache RechercherTache(int id)
        {
            return listeTaches.Find(delegate (Tache tache)
            {
                return tache.Id == id;
            });
        }

        public List<Tache> RechercherTacheParLibelle(string libelle)
        {
            return listeTaches.FindAll(delegate (Tache tache)
            {
                return tache.Libelle.Equals(libelle, StringComparison.InvariantCultureIgnoreCase);
            });
        }

        public List<Tache> RechercherTachesCommencePar(string nom)
        {
            return listeTaches.FindAll(delegate (Tache tache)
            {
                return tache.Libelle.StartsWith(nom,
                            StringComparison.InvariantCultureIgnoreCase);
            });
        }
        #endregion

        #region Methodes de débug
        public void AfficherTaches()
        {
            Console.WriteLine("Affichage des taches");
            foreach(Tache tache in listeTaches)
            {
                Console.WriteLine($"{tache.Id} Libelle : {tache.Libelle}, informations : {tache.Information}, cout : {tache.Cout}");
            }
        }
        #endregion
    }
}
