using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PersonneLibrary
{
    public class TacheCout : Tache
    {
        #region Méthodes
        public static double CalculTacheCout(Tache tache)
        {
            double total = tache.Duree * tache.Cout;
            return total;
        }
        #endregion 

        #region Contructeur
        public TacheCout(int id, string libelle, string information, DateTime dateDeb, DateTime dateFin, double cout) 
            :base(id, libelle, information, dateDeb, dateFin, cout)
        {
        }
        #endregion
    }
}
