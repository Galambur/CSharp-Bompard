using System;

namespace PersonneLibrary
{
    public class Cadre : Personne
    {
        #region Enumérations
        public enum TypeStatus { Aucun, Technique, Administratif, Juridique, Financier }
        #endregion

        #region Attributs
        private double prime;
        private TypeStatus status;
        #endregion

        #region Propriétés
        public double Prime
        {
            get { return prime; }
            set
            {
                if (value>0 && value < 6000)
                {
                    prime = value;
                } else
                {
                    throw new Exception("La prime doit être comprise entre 0 et 6000€ (non inclus");
                }
            }
        }

        public TypeStatus Status 
        { 
            get { return status; } 
            set
            {
                if (value != null)
                {
                    status = value;
                }
                else
                {
                    throw new Exception("Le statut n'a pas été spécifié");
                }
            }
        }
        #endregion

        #region Propriétés abstraites
        public override double TauxImposition
        {
            get { return 0.25; }
        }

        public override double SupplementSalaire
        {
            get { return prime; }
        }
        #endregion

        #region Affichage
        public override string Identite
        {
            get { return $"{id}, {nom}, {prenom}, {Age}, salaire brut : {SalaireBrut:C}€, {Service.Libelle}, prime : {Prime}€, salaire net : {SalaireNet}€, taux impo : {TauxImposition} type : {Status}"; }
        }
        #endregion

        #region Constructeurs
        public Cadre(int id, string nom, string prenom, DateTime dateDeNaissance, double salaireBrut, Service service, double prime, TypeStatus status)
            : base(id, nom, prenom, dateDeNaissance, salaireBrut, service)
        {
            Prime = prime;
            Status = status;
        }
        #endregion
    }
}