using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class Service
    {
        #region Attributs
        private int id;
        #endregion

        #region Propriétés "classiques"
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        #endregion

        #region Propriétés automatiques
        public string Libelle { get; set; }
        #endregion

        #region Constructeur
        public Service(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }
        #endregion
    }

}
