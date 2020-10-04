using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class Tache
    {
        #region Attributs
        private int id;
        private string libelle;
        private string information;
        DateTime dateDeb;
        DateTime dateFin;
        protected double cout;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 1)
                    throw new Exception("L'identifiant n'est pas valide");
                id = value;
            }
        }

        public string Libelle
        {
            get { return libelle; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Le libelle n'est pas correct (vide ou invalide)");
                libelle = value;
            }
        }

        public string Information
        {
            get { return information; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("L'information n'est pas correct (vide ou invalide)");
                information = value;
            }
        }

        public DateTime DateDeb
        {
            get { return dateDeb; }
            set
            {
                if (value == null)
                    throw new Exception("La date de début est invalide");
                dateDeb = value;
            }
        }

        public DateTime DateFin
        {
            get { return dateFin; }
            set
            {
                if (value == null)
                    throw new Exception("La date de fin est invalide");
                dateFin = value;
            }
        }

        public double Duree
        {
            get
            {
                double duree = (DateFin - DateDeb).TotalDays;
                return duree;
            }
        }

        public double Cout
        {
            get { return cout; }
            set
            {
                if (value > 10)
                    cout = value;
                else
                    throw new Exception("Le cout n'est pas correct");
            }
        }
        #endregion

        #region Affichage
        public string Identite
        {
            get { return $"{id}, {libelle}, {information}, début : {dateDeb} fin : {dateFin} durée : {Duree}"; }
        }
        #endregion

        #region Constructeurs
        public Tache(int id, string libelle, string information, DateTime dateDeb, DateTime dateFin, double cout)
        {
            Id = id;
            Libelle = libelle;
            Information = information;
            DateDeb = dateDeb;
            DateFin = dateFin;
            Cout = cout;
        }
        #endregion
    }
}
