using System;

namespace PersonneLibrary
{
    public abstract class Personne
    {
        #region Attributs
        protected int id;
        protected string nom;
        protected string prenom;
        protected DateTime dateDeNaissance;
        protected Service service;
        protected double salaireBrut;
        protected double supplementSalaire;
        protected double tauxImposition;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return id; }
            private set
            {
                if (value < 1)
                    throw new PersonneInvalidAttributeException("L'id doit être supérieur à 0");
                id = value;
            }
        }
        public string Nom
        {
            get { return nom; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new PersonneInvalidAttributeException("Le nom doit être renseigné");
                nom = value.ToUpper();
            }
        }
        public string Prenom
        {
            get { return prenom; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new PersonneInvalidAttributeException("Le prénom doit être renseigné");
                prenom = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        public string Adresse { get; set; }

        public DateTime DateDeNaissance
        {
            get { return dateDeNaissance; }
            private set
            {
                DateTime date = DateTime.Now;
                date = new DateTime(date.Year - 18, date.Month, date.Day);
                // La date de naissance doit être inférieure à (la date du jour -18)
                if (value.CompareTo(date) >= 0)
                    throw new PersonneInvalidAttributeException("La personne doit être majeure");

                dateDeNaissance = value;
            }
        }
        public int Age
        {
            get
            {
                return (int)Math.Floor(DateTime.Now.Subtract(DateDeNaissance).TotalDays / 365);
            }
        }

        public double SalaireBrut
        {
            get { return salaireBrut; }
            set
            {
                if (value < 1500)
                    throw new Exception("Le salaire doit être supérieur à 1.500 €");
                salaireBrut = value;
            }
        }

        public double SalaireNet
        {
            get { return (SalaireBrut + SupplementSalaire) * (1 -TauxImposition); }
        }

        public Service Service
        {
            get { return service; }
            set
            {
                if (value == null)
                    throw new Exception("Le service doit être renseigné");
                service = value;
            }
        }

        
        #endregion

        #region Propriétés abstraites
        public virtual double TauxImposition
        {
            get { return tauxImposition; }
            set
            {
                if (value > 0 && value < 1)
                {
                    tauxImposition = value;
                }
                else
                {
                    throw new Exception("Le taux d'imposition n'est pas correct");
                }
            }
        }

        public virtual double SupplementSalaire
        {
            get;
        }
        #endregion

        #region Affichage
        public virtual string Identite
        {
            get { return $"{id}, {nom}, {prenom}, {Age}, salaire brut : {SalaireBrut:C}€, prime : {SupplementSalaire}, taux impo : {TauxImposition}, {Service.Libelle}"; }
        }
        #endregion

        #region Constructeur
        public Personne(int id, string nom, string prenom, DateTime dateDeNaissance, double salaireBrut, Service service)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            SalaireBrut = salaireBrut;
            Service = service;
        }
        #endregion
 
    }
}
