using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class Employe : Personne
    {
        #region Attributs
        private int nbRTT;
        private double tauxEmploye;
        #endregion

        #region Proprietes
        public int NbRTT
        {
            get { return nbRTT; }
            set
            {
                if (value >0 && value < 26)
                {
                    nbRTT = value;
                } else
                {
                    throw new Exception("Le nombre de RTT doit être compris entre 0 et 26 (non inclus)");
                }
            }
        }
        #endregion

        #region Propriétés abstraites
        public override double TauxImposition
        {
            get { return tauxEmploye = 0.2; }
        }

        public override double SupplementSalaire
        {
            get { return 0; }
        }
        #endregion

        #region Affichage
        public override string Identite
        {
            get { return $"{id}, {nom}, {prenom}, {Age}, salaire brut : {SalaireBrut:C}€, {Service.Libelle}, nb RTT : {NbRTT}, salaire net : {SalaireNet}€, prime : {SupplementSalaire}, taux impo : {TauxImposition}"; }
        }
        #endregion

        #region Constructeur
        public Employe(int id, string nom, string prenom, DateTime dateDeNaissance, double salaireBrut, Service service, int nbRTT)
            :base(id, nom, prenom, dateDeNaissance, salaireBrut, service)
        {
            NbRTT = nbRTT;
        }
        #endregion

    }
}